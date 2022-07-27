using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OperatingSystemSim
{
    public class PCB
    {
        private string name;
        public static int jobCounter = 0;
        private string state;
        
        private int jobLength;
        private int ID;
        private Node<string> files;
        private char type;
        private string segment = "";

        private int memoryExpectedUsage = 0;
        private int memoryAdress;
        private int memoryUsage = 0;

        private int nextCommandLine = 0;
        private Thread process;
        private int sliceStart = -1;
        private int sliceTerminated = -1;
        private int runningSlices = 0;
        private int remainingLength = 0;

        private int baseRegister;
        private int limitRegister;

        private Dictionary<string, int> registersState = new Dictionary<string, int>();
        private Stack<object> stack = new Stack<object>();
        private Dictionary<string, int> variablesState = new Dictionary<string, int>();

        public PCB(string name,char type, int jobLength, int sliceStart, Node<string> files = null, int memoryExpectedUsage = 0, Thread process = null, int baseRegister = 0, int limitRegister = 0)
        {
            this.name = name;
            this.type = type;
            this.state = "init";
            this.jobLength = jobLength;
            this.remainingLength = jobLength;
            this.ID = jobCounter;
            this.memoryExpectedUsage = memoryExpectedUsage;
            this.sliceStart = sliceStart;
            this.baseRegister = baseRegister;
            this.limitRegister = limitRegister;

            jobCounter++;
            this.files = files;
            registersState.Add("ax", 0);
            registersState.Add("bx", 0);
            registersState.Add("cx", 0);
            registersState.Add("dx", 0);
            this.process = process;
        }

        public void SetBaseRegister(int baseRegister)
        {
            this.baseRegister = baseRegister;
        }

        public void SetLimitRegister(int limitRegister)
        {
            this.limitRegister = limitRegister;
        }
        
        public void IncRunningSlices()
        {
            this.runningSlices++;
        }

        public void SetSliceTerminated(int sliceTerminated)
        {
            this.sliceTerminated = sliceTerminated;
        }

        public void SetProcess(Thread process)
        {
            this.process = process;
        }

        public void SetNextCommandLine(int line)
        {
            this.nextCommandLine = line;
        }

        public void SetMemoryAdress(int adress)
        {
            this.memoryAdress = adress;
        }

        public void SetSegment(string segment)
        {
            this.segment = segment;
        }

        public void SetState(string state)
        {
            this.state = state;
        }

        public void SetRegistersState(Dictionary<string, int> registersStat)
        {
            foreach (string key in this.registersState.Keys.ToList())
            {
                this.registersState[key] = registersStat[key];
            }
        }

        public void SetRegistersState(string regName, int value)
        {
            this.registersState[regName] = value;
        }

        public void SetVariablesState(Dictionary<string, int> variablesState)
        {
            foreach (string key in variablesState.Keys.ToList())
            {
                if (!this.variablesState.ContainsKey(key))
                    this.variablesState.Add(key, variablesState[key]);
                else
                    this.variablesState[key] = variablesState[key];
            }
        }

        public void SetStackState(Stack<object> s)
        {
            this.stack.Clear();

            Stack<object> p = new Stack<object>();
            while(s.Count>0)
            {
                p.Push(s.Pop());
            }

            while(p.Count>0)
            {
                this.stack.Push(p.Pop());
            }
        }

        public void SetMemoryUsage(int mem)
        {
            this.memoryUsage = mem;
        }

        public int GetMemoryUsage()
        {
            return this.memoryUsage;
        }

        public string GetName()
        {
            return this.name;
        }

        public Dictionary<string,int> GetVariablesState()
        {
            return this.variablesState;
        }

        public int GetBaseRegister()
        {
            return this.baseRegister;
        }

        public int GetLimitRegister()
        {
            return this.limitRegister;
        }

        public int GetRunningSlices()
        {
            return this.runningSlices;
        }

        public int GetSliceStart()
        {
            return this.sliceStart;
        }

        public int GetSliceTerminated()
        {
            return this.sliceTerminated;
        }

        public Thread GetProcess()
        {
            return this.process;
        }

        public int GetNextCommandLine()
        {
            return this.nextCommandLine;
        }

        public int GetMemoryExpectedUsage()
        {
            return this.memoryExpectedUsage;
        }

        public int GetMemoryAdress()
        {
            return this.memoryAdress;
        }

        public Node<string> GetFiles()
        {
            return this.files;
        }

        public void AppendFile(string file)
        {
            if (this.files == null)
                this.files = new Node<string>(file);
            else
            {
                Node<string> p = this.files;

                while (p.GetNext() != null)
                    p = p.GetNext();
                p.SetNext(new Node<string>(file));
            }
        }

        public void SetRemainingJobLength(int jobLength)
        {
            this.remainingLength = jobLength;
        }

        public string GetSegment()
        {
            return this.segment;
        }

        public int GetJobLength()
        {
            return this.jobLength;
        }

        public int GetRemainingLength()
        {
            return this.remainingLength;
        }

        public string GetState()
        {
            return this.state;
        }

        public Dictionary<string, int> GetRegistersState()
        {
            return this.registersState;
        }

        public int GetID()
        {
            return this.ID;
        }

        public char GetProcessType()
        {
            return this.type;
        }

        public Stack<object> GetStackState()
        {
            return this.stack;
        }
    }
}
