using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace OperatingSystemSim
{

    public class Program
    {
        public delegate void ClassForTextBox(int id, string command, string text = "", PCB personalPCB = null);
        public static event ClassForTextBox ControlTextBoxes;

        public delegate void MyClass(string s); 
        public static event MyClass DisplayNotification;

        public delegate void ClassForProgressBars(int id,string command,int length=0);
        public static event ClassForProgressBars UpdateProgressBars;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            registers.Add("ax", 0);
            registers.Add("bx", 0);
            registers.Add("cx", 0);
            registers.Add("dx", 0);

            settingsForm = new Form2();
            settingsForm.StartPosition = FormStartPosition.Manual;
            processesForm = new Form3();
            processesForm.StartPosition = FormStartPosition.Manual;
            mainForm = new Form1();
          
            Application.Run(mainForm);
        }

        public static class Global
        {
            public static int filter = 0;
            public static Stopwatch sw = new Stopwatch();

            public static bool isClockAlive = false;
            public static bool isSchedulerWaiting = true;


            public static bool contextSwitch = false;
            public static int currentSlice = 0;
            public static int jobNum = 0;
            public static long currentTime = 0;
            public static long idNext = -1;
            public static string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\AsmJobs@");
            
            public static long asmCounter = 0;
            public static int readyThreads = 0;
            public static string schedulingAlgoType = "Round-Robin";
            public static string memAlgoType = "First Fit";
            public static int inputRequestsNum = 0;
            
        }


        public static int maxMemUse = 0;
        public static int totalMemUse = 0;

        public static Node<string> jobsToRun;
        public static Node<string> jobsAlreadyRead = null;
        public static Dictionary<string, int> registers = new Dictionary<string, int>();
        public static Semaphore _inputSem = new Semaphore(0, 4);


        public static Form1 mainForm;
        public static Form2 settingsForm;
        public static Form3 processesForm;

        private static Dictionary<string, int> varibles = new Dictionary<string, int>();
        private static Stack<object> stack = new Stack<object>();
        private static Semaphore _pool = new Semaphore(0, 100);
        private static Semaphore _notificationSem = new Semaphore(1, 1);
        private static Semaphore _schedulerSem = new Semaphore(1, 1);
        public static Node<PCB> processList;
        public static Node<PCB> allprocesses;

        private static MemoryAdress[] memory = new MemoryAdress[1000];

        private static Thread clockThread;
        private static Thread schdulerThread;

        public static Semaphore _systemSleep = new Semaphore(0, 1);
        public static bool timeToSleep = false;
        public static int processSleepingNum=0;
        public static int sliceSize = 5;
        private static int schedulingSliceNum = 0;
        private static int nextFitPointer = 0;
        

        static void NextFit(PCB p)
        {
            bool hasLocated = false;

            for (int i = nextFitPointer; i < memory.Length && !hasLocated; i++)
            {
                if (memory[i].GetReleased())
                {
                    bool portionLongEnough = true;
                    for (int j = i; j < p.GetMemoryExpectedUsage() && portionLongEnough; j++)
                    {
                        if (!memory[j].GetReleased())
                        {
                            portionLongEnough = false;
                        }
                    }

                    //If can allocate.
                    if (portionLongEnough)
                    {
                        for (int j = i; j < p.GetMemoryExpectedUsage(); j++)
                        {
                            memory[j].SetOwnerID(p.GetID());
                            memory[j].SetReleased(false);
                            nextFitPointer = j;
                           
                        }
                        hasLocated = true;
                        p.SetBaseRegister(i);
                        nextFitPointer++;
                        
                        p.SetLimitRegister(p.GetMemoryExpectedUsage());
                    }
                }
            }

            for (int i = p.GetBaseRegister(); i < p.GetBaseRegister() + p.GetJobLength() / 100 + 1; i++)
            {
                memory[i].SetAllocated(true);
                p.SetMemoryUsage(p.GetMemoryUsage() + 1);
            }

            totalMemUse += p.GetMemoryExpectedUsage();

            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " memory adress: " + p.GetBaseRegister());
            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " expected memory usage: " + p.GetMemoryExpectedUsage());
            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " is using: " + p.GetBaseRegister() + "-" + (p.GetBaseRegister() + p.GetJobLength() / 100));
        }

        static void FirstFit(PCB p)
        {
            bool hasLocated = false;

            for (int i = 0; i < memory.Length && !hasLocated; i++) 
            {
                if(memory[i].GetReleased())
                {
                    bool portionLongEnough = true;
                    for (int j = i; j < p.GetMemoryExpectedUsage() && portionLongEnough; j++) 
                    {
                        if (!memory[j].GetReleased()) 
                        {
                            portionLongEnough = false;
                        }
                    }

                    //If can allocate.
                    if(portionLongEnough)
                    {
                        for (int j = i; j < p.GetMemoryExpectedUsage(); j++)
                        {
                            memory[j].SetOwnerID(p.GetID());
                            memory[j].SetReleased(false);
                            
                        }
                        hasLocated = true;
                        p.SetBaseRegister(i);
                        p.SetLimitRegister(p.GetMemoryExpectedUsage());
                    }
                }
            }

            for (int i = p.GetBaseRegister(); i < p.GetBaseRegister()+p.GetJobLength() / 100 + 1; i++) 
            {
                memory[i].SetAllocated(true);
                p.SetMemoryUsage(p.GetMemoryUsage() + 1);
            }

            totalMemUse += p.GetMemoryExpectedUsage();

            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " memory adress: " + p.GetBaseRegister());
            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " expected memory usage: " + p.GetMemoryExpectedUsage());
            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " is using: " + p.GetBaseRegister()+"-"+(p.GetBaseRegister()+p.GetJobLength()/100));
        }

        static void MemoryRelease(PCB p)
        {
            for (int i = p.GetBaseRegister(); i < p.GetLimitRegister(); i++) 
            {
                memory[i].SetReleased(true);
            }
            WriteNotification(Global.currentSlice, "Thread " + p.GetID() + " released its memory.");
        }

        static void AppendJobToAlready(string path)
        {
            if (jobsAlreadyRead == null)
                jobsAlreadyRead = new Node<string>(path);
            else
            {
                Node<string> temp = jobsAlreadyRead;

                while (temp.GetNext() != null)
                    temp = temp.GetNext();
                temp.SetNext(new Node<string>(path));
            }
        }
        
        static string NewJobFromJobsToRun()
        {
            Node<string> temp = jobsToRun;

           

            while(jobsToRun!=null)
            { 
                Node<string> p = jobsAlreadyRead;
                bool flag = true;
                while (p != null && flag)  
                {
                    if (p.GetValue() == temp.GetValue())
                        flag = false;
                    else

                        p = p.GetNext();
                }

                if(flag)
                {
                    AppendJobToAlready(temp.GetValue());
                    return temp.GetValue();
                }
                temp = temp.GetNext();
            }
            return null;
        }


        public static void Start()
        {
            Reset();
            Thread clock = new Thread(Clock);
            //WriteNotification(0, "Clock init");
            clock.Start();
            clockThread = clock;

            int jobListenerLength = 0;
            if (Global.schedulingAlgoType == "Longest Remaining Time")
            {
                jobListenerLength = -1;
            }
            else jobListenerLength = 10000;


            PCB p = new PCB("Job Listener",'j', jobListenerLength,Global.currentSlice);
            Thread jobListener = new Thread(new ParameterizedThreadStart(JobListener));
            p.SetProcess(jobListener);
            //WriteNotification(Global.sw.ElapsedMilliseconds, "Job Listener init");
            jobListener.Start(p);
            AppendJob(p);


            Thread scheduler = new Thread(Scheduler);
            //WriteNotification(Global.sw.ElapsedMilliseconds, "Scheduler init");
            scheduler.Start();
            schdulerThread = scheduler;
        }

        public static void Stop()
        {
            
            Global.isClockAlive = false;
        }

        public static void Reset()
        {
            totalMemUse = 0;
            maxMemUse = 0;
            _pool = new Semaphore(0, 100);
            _notificationSem = new Semaphore(1, 1);

            nextFitPointer = 0;

            for(int i=0;i<memory.Length;i++)
            {
                memory[i] = new MemoryAdress();
            }

            PCB.jobCounter = 0;
            foreach (KeyValuePair<string, int> kvp in registers.ToList())
            {
                registers[kvp.Key] = 0;
            }
            Global.contextSwitch = false;
            Global.currentSlice = 0;
            Global.jobNum = 0;
            Global.currentTime = 0;
            Global.idNext = -1;
            Global.asmCounter = 0;
            Global.readyThreads = 0;
            Global.inputRequestsNum = 0;
            processList = null;
            allprocesses = null;
            
            _inputSem = new Semaphore(0, 4);

            varibles = new Dictionary<string, int>();//
            stack = new Stack<object>();//
           
            _schedulerSem = new Semaphore(1, 1);

            Global.isClockAlive = true;
            jobsAlreadyRead = null;
        }


        static void BackRegisters(PCB p)
        {
           
            Dictionary<string, int> reg = p.GetRegistersState();

            foreach (string key in reg.Keys.ToList())
            {
                registers[key] = reg[key];
            }

            stack.Clear();

            //And back variables
            varibles = null;
            varibles = p.GetVariablesState();

            //And back stack:)
            stack.Clear();
            Stack<object> t = new Stack<object>();
            Stack<object> s = p.GetStackState();

            while (s.Count > 0)
            {
                t.Push(s.Pop());
            }

            while (t.Count > 0)
            {
                stack.Push(t.Pop());
            }
        }

        static int GetListLength(Node<PCB> list)
        {
            int counter = 0;
            Node<PCB> t = list;
            while(t!=null)
            {
                counter++;
                t = t.GetNext();
            }
            return counter;
        }

        static int GetFileLength(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int counter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                    counter++;
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                if(line.Length==2 && line[0]=="loop")
                {
                    bool f = true;
                    int iterations = 0;
                    for (int j = 0; j < lines.Length && f; j++) 
                    {
                        if (lines[j] != "" && lines[j].Split(' ').Length == 1 && (lines[j].Split(' ')[0].Substring(0, lines[j].Split(' ')[0].Length - 1)) == line[1]) 
                        {
                            string[] l = lines[j - 1].Split(' ');
                           
                            if (l.Length == 2 && l[0] == "mov")
                            {
                                l = l[1].Split(',');
                                if (l.Length == 2 && l[0] == "cx" && int.TryParse(l[1], out int n)) 
                                {
                                    iterations = int.Parse(l[1]);
                                    counter += (iterations - 1) * (i - j);
                                    f = false;
                                }
                                else return -1;
                                
                            }
                            else return -1;
                                
                        }
                        if (lines[j] == line[0] + " " + line[1] && line.Length == lines[j].Split(' ').Length)
                        {
                            return -1;
                        }
                    }
                }
            }
            return counter;
        }


        static void Clock()
        {
            Global.sw.Reset();
            Global.sw.Start();
            WriteNotification(Global.currentSlice, "Clock running");

            while (Global.isClockAlive)
            {
                if (Global.sw.ElapsedMilliseconds - Global.currentTime > sliceSize)
                {
                    Global.contextSwitch = true;
                    while (Global.contextSwitch)
                    {

                    }
                }
            }
            WriteNotification(Global.currentSlice, "Clock terminated");
        }

        static int GetNodeLength(Node<string> lst)
        {
            Node<string> p = lst;
            int counter = 0;
            while (p != null)
            {
                counter++;
                p = p.GetNext();
            }
            return counter;
        }

        static int MemAllocRequest(string path)
        {
            int mem = 0;
            string[] lines = File.ReadAllLines(path);

            int i = 0;
            bool searchLoop = false;
            int iterations=0;
            while (i<lines.Length)
            {
                if (lines[i] != "")
                {
                    string[] line = lines[i].Split(' ');//loop line
                    if (line[0] == "memalloc")
                    {
                        if (int.TryParse(line[1], out int d))
                        {
                            mem += int.Parse(line[1]);
                        }
                        else return -1;
                    }

                    else if (line.Length == 1 && line[0][line[0].Length - 1] == ':')
                    {
                        if (i > 0)
                        {
                            string[] iterLine = lines[i - 1].Split(' ');

                            if (iterLine[0] == "mov" && iterLine.Length == 2)
                            {
                                string[] param = iterLine[1].Split(',');
                                if (param.Length == 2 && param[0] == "cx" && int.TryParse(param[1], out int d))
                                {
                                    iterations = int.Parse(param[1]);
                                    searchLoop = true;
                                }
                            }
                        }
                    }


                    if (searchLoop)
                    {
                        int memLoop = 0;
                        bool loopTerminated = false;
                        for (int j = i + 1; j < lines.Length && !loopTerminated; j++)
                        {
                            if (lines[j] != "")
                            {
                                string[] ml = lines[j].Split(' ');

                                if (ml.Length == 2 && ml[0] == "memalloc" && int.TryParse(ml[1], out int m))
                                {
                                    memLoop += int.Parse(ml[1]);
                                }
                                else if (ml.Length == 2 && ml[0] == "loop" && (ml[1] + ':') == line[0])
                                    loopTerminated = true;
                            }
                            i = j;
                        }
                        if (loopTerminated)
                            mem += (memLoop * iterations);
                        else mem += memLoop;
                        searchLoop = false;
                        memLoop = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                else i++;
            }
            return mem;
        }

        static void JobListener(object p)
        {
            PCB personalPCB = (PCB)p;
            
            WriteNotification(Global.currentSlice, "Job Listener ready");
            Global.jobNum++;
            personalPCB.SetState("ready");

            Waiting(personalPCB.GetID(), false, personalPCB);

            personalPCB.SetState("running");
           
            WriteNotification(Global.currentSlice, "Job Listener running");
            Random rnd = new Random();

            while (Global.isClockAlive)
            {
                
                PCB job = null;

                if (GetNodeLength(jobsToRun) > Global.asmCounter)
                {
                    string path = NewJobFromJobsToRun();
                    int length = GetFileLength(path);
                    if (length != -1)
                    {
                        int memory = MemAllocRequest(path) + (length / 100 + 1);
                        job = new PCB(path.Substring(path.LastIndexOf("AsmJobs@") + 9),'a', length, Global.currentSlice, new Node<string>(path), memory);
                        UpdateProgressBars(job.GetID(), "GET-LENGTH",length);

                       
                        if (Global.memAlgoType == "First Fit")
                            FirstFit(job);
                        else if (Global.memAlgoType == "Next Fit")
                            NextFit(job);
                    }
                    else Console.WriteLine("Error while loading: "+path);

                    
                    Global.asmCounter++;
                }


                if (Global.contextSwitch)
                {
                    
                    WriteNotification(Global.currentSlice, "Job Listener ready");
                    
                    personalPCB.SetState("ready");
                    
                    Waiting(personalPCB.GetID(), true, personalPCB);
                    if (timeToSleep)
                    {
                        processSleepingNum++;
                        _systemSleep.WaitOne();
                        processSleepingNum--;
                    }


                    personalPCB.SetState("running");
                   
                    WriteNotification(Global.currentSlice, "Job Listener running");
                }

                if (job != null)
                {
                   
                    WriteNotification(Global.currentSlice, "A new job was found");
                    Thread t = null;

                    AppendJob(job);
                    if (job.GetProcessType() == 'a')
                    {
                        t = new Thread(new ParameterizedThreadStart(RunAsm));
                    }

                    job.SetProcess(t);
                    
                    WriteNotification(Global.currentSlice, ("Thread " + job.GetID() + " init"));
                    t.Start(job);

                    Thread.Sleep(1);
                }

                if (Global.contextSwitch || job == null)
                {

                    Global.contextSwitch = true;
                   
                    WriteNotification(Global.currentSlice, "Job Listener ready");

                    personalPCB.SetState("ready");

                   
                    Waiting(personalPCB.GetID(), true, personalPCB);
                    if (timeToSleep)
                    {
                        processSleepingNum++;
                        _systemSleep.WaitOne();
                        processSleepingNum--;
                    }


                    personalPCB.SetState("running");
                  
                    WriteNotification(Global.currentSlice, "Job Listener running");
                }
            }

            Global.jobNum--;

            Global.contextSwitch = true;
            
           
            WriteNotification(Global.currentSlice, "Job Listener terminated");
            personalPCB.SetSliceTerminated(Global.currentSlice);

            _schedulerSem.Release();
        }

        
        static void Scheduler()
        {
         
            WriteNotification(Global.currentSlice, "Scheduler ready");
            _schedulerSem.WaitOne();

            int countMemUse = 0;
            Node<PCB> t;
            while (Global.isClockAlive||Global.jobNum>0)
            {
                Global.currentSlice++;
              
                WriteNotification(Global.currentSlice, "Scheduler running");
             
                WriteNotification(Global.currentSlice, "Scheduler found " + Global.jobNum + " jobs");

                t= processList;
         
                while (t != null) 
                {
                    if(t.GetValue().GetProcessType()=='a')
                    {
                       
                        countMemUse += t.GetValue().GetMemoryUsage();
                        
                    }
                    t = t.GetNext();
                }
                
                if (countMemUse > maxMemUse)
                    maxMemUse = countMemUse;
                countMemUse = 0;


                if (Global.schedulingAlgoType == "Round-Robin")
                {

                    Global.contextSwitch = false;
                    Global.currentTime = Global.sw.ElapsedMilliseconds;

                    _pool.Release();
                }
                else if (Global.schedulingAlgoType == "Longest Remaining Time")
                {
                    LongestRemainingTime();
                    Global.contextSwitch = false;
                    Global.currentTime = Global.sw.ElapsedMilliseconds;
                    _pool.Release(Global.readyThreads);
                }
                else if (Global.schedulingAlgoType == "Shortest Remaining Time")
                {
                    ShortestRemainingTime();
                    Global.contextSwitch = false;
                    Global.currentTime = Global.sw.ElapsedMilliseconds;
                    _pool.Release(Global.readyThreads);
                }
                else if(Global.schedulingAlgoType=="Shortest Job First")
                {
                    ShortestJobFirst();
                    Global.contextSwitch = false;
                    Global.currentTime = Global.sw.ElapsedMilliseconds;
                    _pool.Release(Global.readyThreads);
                }

                WriteNotification(Global.currentSlice, "Scheduler ready");


                Global.isSchedulerWaiting = true;
                _schedulerSem.WaitOne();
                Global.isSchedulerWaiting = false;
                if(!Global.isClockAlive&&Global.inputRequestsNum>0)
                {
                    _inputSem.Release(Global.inputRequestsNum);
                }
                   
                if (timeToSleep)
                {
                    processSleepingNum++;
                    _systemSleep.WaitOne();
                    processSleepingNum--;
                }
            }

            WriteNotification(Global.currentSlice, "Scheduler Terminated");
        }


        static void LongestRemainingTime()
        {

            schedulingSliceNum++;
            
            if (schedulingSliceNum % 4 == 0)
                Global.idNext = 0;
            
            else
            {
                Node<PCB> p = processList;
                int maxLength = -2;
                PCB nextJob = null;
               
                while (p != null)
                {
                    if (p.GetValue().GetState() == "ready" && p.GetValue().GetRemainingLength() > maxLength)
                    {
                        nextJob = p.GetValue();
                        maxLength = p.GetValue().GetRemainingLength();
                    }
                    p = p.GetNext();
                }
                Global.idNext = nextJob.GetID();
                registers = nextJob.GetRegistersState();
            }
        }

        static void ShortestRemainingTime()
        {
            schedulingSliceNum++;
            if (schedulingSliceNum % 4 == 0)
                Global.idNext = 0;
            else
            {
                Node<PCB> p = processList;
                int minLength = 100000;
                PCB nextJob = null;
                while (p != null)
                {
                    if (p.GetValue().GetState() == "ready" && p.GetValue().GetRemainingLength() < minLength)
                    {
                        nextJob = p.GetValue();
                        minLength = p.GetValue().GetRemainingLength();
                    }
                    p = p.GetNext();
                }
                Global.idNext = nextJob.GetID();

                registers = nextJob.GetRegistersState();
            }
        }

        static void ShortestJobFirst()
        {
            schedulingSliceNum++;
            if (schedulingSliceNum % 4 == 0)
                Global.idNext = 0;
            else
            {
                Node<PCB> p = processList;
                int minLength = 100000;
                PCB nextJob = null;
                while (p != null)
                {
                    if (p.GetValue().GetState() == "ready" && p.GetValue().GetJobLength() < minLength)
                    {
                        nextJob = p.GetValue();
                        minLength = p.GetValue().GetJobLength();
                    }
                    p = p.GetNext();
                }
                Global.idNext = nextJob.GetID();

                registers = nextJob.GetRegistersState();
            }
        }


        static void RunAsm(object j)
        {
            PCB personalPCB = (PCB)j;

           
            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " ready");
            Global.jobNum++;
            personalPCB.SetState("ready");
         
            Waiting(personalPCB.GetID(), false, personalPCB);
            BackRegisters(personalPCB);
            personalPCB.SetState("running");
           
          
            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " running");
            bool flag = true;

            personalPCB.SetState("suspended");
            
            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " suspended, opening a file");

            _schedulerSem.Release();
            string[] lines = File.ReadAllLines(personalPCB.GetFiles().GetValue());

            
            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " ready");
            personalPCB.SetState("ready");


        
            Waiting(personalPCB.GetID(), false, personalPCB);
            BackRegisters(personalPCB);
            if (timeToSleep)
            {
                processSleepingNum++;
                _systemSleep.WaitOne();
                processSleepingNum--;
            }
            


            personalPCB.SetState("running");
          
            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " running");

            int commandsCounter = 0;
            int i = 0;
            while (i < lines.Length && flag && Global.isClockAlive)  
            {
                if (lines[i] != "")
                {

                    flag = RunLine(lines[i].Split(' '), i, personalPCB, lines);
                    if(flag)
                    {
                        personalPCB.SetRemainingJobLength(personalPCB.GetRemainingLength() - 1);
                        commandsCounter++;

                        UpdateProgressBars(personalPCB.GetID(), "PERFORM-STEP");

                        if (commandsCounter % sliceSize == 0)
                        {

                           
                            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " ready");
                            personalPCB.SetState("ready");

                            personalPCB.SetRegistersState(registers);
                            personalPCB.SetStackState(stack);
                            personalPCB.SetVariablesState(varibles);
                            Waiting(personalPCB.GetID(), true, personalPCB);
                            if (timeToSleep)
                            {
                                processSleepingNum++;
                                _systemSleep.WaitOne();
                                processSleepingNum--;
                            }


                            BackRegisters(personalPCB);

                            personalPCB.SetState("running");
                          
                            WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " running");
                        }
                    }
                }
                else
                {
                    personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine()+1);
                }
                i = personalPCB.GetNextCommandLine();
            }

            WriteNotification(Global.currentSlice, ("Thread " + personalPCB.GetID() + " terminated"));
            personalPCB.SetState("terminated");
            MemoryRelease(personalPCB);
            personalPCB.SetSliceTerminated(Global.currentSlice);

            RemoveJob(personalPCB.GetID());

            Global.jobNum--;

            personalPCB.SetRegistersState(registers);
            personalPCB.SetStackState(stack);
            personalPCB.SetVariablesState(varibles);

            Global.contextSwitch = true;

            _schedulerSem.Release();  
        }

        

        static void Waiting(int id, bool contextSwitch, PCB p)
        {
            Global.readyThreads++;

            if (contextSwitch) 
            {
                _schedulerSem.Release();
            }

            do
            {
                _pool.WaitOne();
            }
            while (Global.schedulingAlgoType != "Round-Robin" && Global.idNext != id );
            Global.currentSlice++;
            p.IncRunningSlices();
            Global.readyThreads--;
        }


        static bool RunLine(string[] line, int lineNum, PCB personalPCB, string [] lines)
        {

            if (line[0] == "DATASEG" || line[0] == "CODSEG")
            {
                personalPCB.SetSegment(line[0]);
                personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                return true;
            }

            else if (personalPCB.GetSegment() == "CODSEG")
            {
                if (line[0] == "mov")
                {
                    string[] parameters = line[1].Split(',');
                    char[] fu = CheckCommand(parameters);
                    if (fu[0] == 'r')
                    {
                        if (fu[1] == 'r')
                            registers[parameters[0]] = registers[parameters[1]];
                        else if (fu[1] == 'v')
                            registers[parameters[0]] = varibles[parameters[1]];
                        else registers[parameters[0]] = int.Parse(parameters[1]);

                        
                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                    else if (fu[0] == 'v')
                    {
                        if (fu[1] == 'r')
                            varibles[parameters[0]] = registers[parameters[1]];
                        else varibles[parameters[0]] = int.Parse(parameters[1]);

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                }
                else if(line[0]=="memalloc")
                {
                    if(line.Length==2&&int.TryParse(line[1],out int w))
                    {
                        personalPCB.SetMemoryUsage(personalPCB.GetMemoryUsage() + int.Parse(line[1]));
                        int i = personalPCB.GetBaseRegister();
                        while(memory[i].GetAllocated()&&i<personalPCB.GetBaseRegister()+personalPCB.GetLimitRegister())
                        {
                            i++;
                        }
                        
                        for (int c = 0; c < int.Parse(line[1]); c++) 
                        {
                            memory[i].SetAllocated(true);
                            i++;
                        }
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " is using: " +(i-int.Parse(line[1]))+ "-" +(i-1));
                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }

                   
                }
                else if (line[0] == "add")
                {
                    string[] parameters = line[1].Split(',');
                    char[] fu = CheckCommand(parameters);

                    if (fu[0] == 'r')
                    {
                        if (fu[1] == 'r')
                            registers[parameters[0]] += registers[parameters[1]];
                        else if (fu[1] == 'v')
                            registers[parameters[0]] += varibles[parameters[1]];
                        else registers[parameters[0]] += int.Parse(parameters[1]);

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                    if (fu[0] == 'v')
                    {
                        if (fu[1] == 'r')
                            registers[parameters[0]] += registers[parameters[1]];
                        else registers[parameters[0]] += int.Parse(parameters[1]);

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                }

                else if (line[0] == "sub")
                {
                    string[] parameters = line[1].Split(',');
                    char[] fu = CheckCommand(parameters);

                    if (fu[0] == 'r')
                    {
                        if (fu[1] == 'r')
                            registers[parameters[0]] -= registers[parameters[1]];
                        else if (fu[1] == 'v')
                            registers[parameters[0]] -= varibles[parameters[1]];
                        else registers[parameters[0]] -= int.Parse(parameters[1]);

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                    if (fu[0] == 'v')
                    {
                        if (fu[1] == 'r')
                            registers[parameters[0]] -= registers[parameters[1]];
                        else registers[parameters[0]] -= int.Parse(parameters[1]);

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                }

                else if (line[0] == "push")
                {
                    if (registers.TryGetValue(line[1], out int value))
                    {
                        stack.Push(registers[line[1]]);

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }

                    return false;
                }
                else if (line[0] == "pop")
                {
                    if (registers.TryGetValue(line[1], out int value))
                    {
                        registers[line[1]] = Convert.ToInt32(stack.Pop());

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }

                    return false;
                }
                else if (line[0] == "inc")
                {
                    if (registers.TryGetValue(line[1], out int value))
                    {
                        registers[line[1]] = Convert.ToInt32(registers[line[1]]) + 1;

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }

                    return false;
                }
                else if (line[0] == "dec")
                {
                    if (registers.TryGetValue(line[1], out int value))
                    {
                        registers[line[1]] = Convert.ToInt32(registers[line[1]]) - 1;

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }

                    return false;
                }
                else if (line[0] == "int" && line[1] == "21")
                {

                    if (registers["ax"] == 2)
                    {
                        personalPCB.SetState("suspended");
                       
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " suspended, output");

                        personalPCB.SetVariablesState(varibles);
                        personalPCB.SetRegistersState(registers);
                        personalPCB.SetStackState(stack);
                        _schedulerSem.Release();

                        ControlTextBoxes(personalPCB.GetID(), "PRINT", registers["dx"].ToString());
                       
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " ready");
                        personalPCB.SetState("ready");
                        
                        Waiting(personalPCB.GetID(), false, personalPCB);
                        BackRegisters(personalPCB);
                        personalPCB.SetState("running");
                       
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " running");

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }
                    if (registers["ax"] == 1)
                    {
                        personalPCB.SetState("suspended");
                       
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " suspended, input");

                        personalPCB.SetVariablesState(varibles);
                        personalPCB.SetRegistersState(registers);
                        personalPCB.SetStackState(stack);
                        _schedulerSem.Release();

                        ControlTextBoxes(personalPCB.GetID(), "INPUT","",personalPCB);

                        Global.inputRequestsNum++;
                        _inputSem.WaitOne();
                        Global.inputRequestsNum--;

                        
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " ready");
                        personalPCB.SetState("ready");
                        
                        Waiting(personalPCB.GetID(), false, personalPCB);
                        BackRegisters(personalPCB);

                        personalPCB.SetState("running");
                       
                        WriteNotification(Global.currentSlice, "Thread " + personalPCB.GetID() + " running");

                        personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                        return true;
                    }

                    return false;
                }
                else if (line.Length == 1 && line[0][line[0].Length - 1] == ':')
                {
                    personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                    return true;
                }
                else if (line[0] == "loop" && line.Length == 2) 
                {
                    
                    if (registers["cx"] <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        registers["cx"]--;
                        if (registers["cx"]==0)
                        {
                            personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                            return true;
                        }

                        for (int i = 0; i < lines.Length; i++)
                        {

                            if(lines[i]!=""&& lines[i].Split(' ').Length==1&&(lines[i].Split(' ')[0].Substring(0, lines[i].Split(' ')[0].Length-1))==line[1])
                            {
                                personalPCB.SetNextCommandLine(i+1);
                                return true;
                            }
                            if (lines[i] == line[0] + " " + line[1] && line.Length == lines[i].Split(' ').Length) 
                                return false;
                        }
                    }
                    return true;
                }

            }

            else if (personalPCB.GetSegment() == "DATASEG")
            {
                if ((line[1] == "db" || line[1] == "dw") && int.TryParse(line[2], out int d))
                {
                    varibles.Add(line[0], int.Parse(line[2]));

                    personalPCB.SetNextCommandLine(personalPCB.GetNextCommandLine() + 1);
                    return true;
                }
            }


            Console.WriteLine("Error, line number {0}: {1} is invalid command.", lineNum, line[0]);
            return false;
        }

        static char[] CheckCommand(string[] parameters)
        {
            char[] paramTypes = new char[2];
            if (registers.TryGetValue(parameters[0], out int a))
            {
                paramTypes[0] = 'r';
                if (registers.TryGetValue(parameters[1], out int c))
                {
                    paramTypes[1] = 'r';
                    return paramTypes;
                }
                if (varibles.TryGetValue(parameters[1], out int v))
                {
                    paramTypes[1] = 'v';
                    return paramTypes;
                }
                if (int.TryParse(parameters[1], out int d))
                {
                    paramTypes[1] = 'c';
                    return paramTypes;
                }
                return null;
            }
            if (registers.TryGetValue(parameters[1], out int b))
            {
                paramTypes[1] = 'r';

                if (varibles.TryGetValue(parameters[0], out int v))
                {
                    paramTypes[0] = 'v';
                    return paramTypes;
                }
                return null;
            }
            if (varibles.TryGetValue(parameters[0], out int f))
            {
                paramTypes[0] = 'v';          
                if (int.TryParse(parameters[1], out int d))
                {
                    paramTypes[1] = 'c';
                    return paramTypes;
                }
            }
            return null;
        }

        static void AppendJob(PCB p)
        {
            if (processList == null)
                processList = new Node<PCB>(p);
            else
            {
                Node<PCB> temp = processList;

                while (temp.GetNext() != null)
                    temp = temp.GetNext();
                temp.SetNext(new Node<PCB>(p));
            }

            if (allprocesses == null)
                allprocesses = new Node<PCB>(p);
            else
            {
                Node<PCB> temp = allprocesses;

                while (temp.GetNext() != null)
                    temp = temp.GetNext();
                temp.SetNext(new Node<PCB>(p));
            }
        }

        static void RemoveJob(int id)
        {
            Node<PCB> temp = processList;
            if (temp.GetValue().GetID() == id)
            {
                processList = processList.GetNext();
                temp.SetNext(null);
            }
            else
            {
                while (temp.GetNext().GetValue().GetID() != id)
                {
                    temp = temp.GetNext();
                }
                Node<PCB> d = temp.GetNext();
                temp.SetNext(d.GetNext());
                d.SetNext(null);
            }
        }


        static void WriteNotification(object time, object text)
        {
            //0- defult
            //1- job listener only new job was found
            //2- job listener only new job was found & without scheduler

            _notificationSem.WaitOne();

            using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + @"\Notifications.txt"))
            {
                sw.WriteLine("Notification Slice: {0} --> {1}", time, text);
            }
            

            if (Global.filter == 0)
            {
                DisplayNotification("Notification Slice: " + time + " --> " + text + "\r\n");
            }
            else if (Global.filter == 1)
            {
                string[] t = Convert.ToString(text).Split(' ');
                if (t[1] != "Listener")
                {
                    DisplayNotification("Notification Slice: " + time + " --> " + text + "\r\n");
                }
            }
            else if (Global.filter == 2)
            {
                string[] t = Convert.ToString(text).Split(' ');
                if (t[0] != "Scheduler"&& t[1] != "Listener")
                {
                    DisplayNotification("Notification Slice: " + time + " --> " + text + "\r\n");
                }
            }

            _notificationSem.Release();
        }
    }
}
