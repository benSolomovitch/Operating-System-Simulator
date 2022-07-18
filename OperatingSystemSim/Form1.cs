using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;


namespace OperatingSystemSim
{
    public partial class Form1 : Form
    {
        private ProgressBar[] progressBars = new ProgressBar[4];
        private TextBox[] textBoxes = new TextBox[4];
        private Button[] pcbButtons = new Button[4];
        private int[] inputLength = new int[4];
        private bool enter = false;
        private PCB[] inputRequests = new PCB[4];
        private string path;
        

        public Form1()
        {
            
            InitializeComponent();

            
            Program.DisplayNotification += (string s) => NotificationTextBox(s);
            Program.UpdateProgressBars += (int id, string command,int length) => ProgressBarStep(id, command,length);
            Program.ControlTextBoxes += (int id, string command, string text, PCB personalPCB) => ProcessesTextBox(id, command, text, personalPCB);

            progressBars[0] = progressBar1;
            progressBars[1] = progressBar2;
            progressBars[2] = progressBar3;
            progressBars[3] = progressBar4;


            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;

            pcbButtons[0] = button1;
            pcbButtons[1] = button2;
            pcbButtons[2] = button3;
            pcbButtons[3] = button4;

            for (int i = 0; i < 4; i++)
            {
                textBoxes[i].KeyDown += TextBoxCheckEnter;
                textBoxes[i].KeyPress += TextBoxPressed;
            }


            Label[] processesLabels = { this.label15, this.label24, this.label22, this.label21 };
            //Page3
            for (int i = 0; i < 4; i++)
                processesLabels[i].Text="";

            this.label17.Text = "";
            this.label19.Text = "";
            this.label23.Text = "";


            File.WriteAllText(@"C:\Users\Ben\Desktop\example\Notifications.txt", "");
        }

        delegate void SetTextBoxesCallback(int id, string command, string text, PCB personalPCB);
        public void ProcessesTextBox( int id=-1,string command="",string text = "",PCB personalPCB=null)
        {
            if (this.NotificationsBox.InvokeRequired)
            {
                SetTextBoxesCallback d = new SetTextBoxesCallback(ProcessesTextBox);
                this.Invoke(d, new object[] { id, command, text, personalPCB });
            }
            else
            {
                if (command == "PRINT")
                    textBoxes[id - 1].AppendText(text+"\r\n");
                else if (command == "INPUT")
                {
                    this.inputRequests[id - 1] = personalPCB;
                    textBoxes[id - 1].AppendText(">>");
                    textBoxes[id - 1].MaxLength = textBoxes[id - 1].TextLength + 1;
                    textBoxes[id - 1].SelectionStart = textBoxes[id - 1].TextLength;
                    textBoxes[id - 1].ReadOnly = false; 
                }
            }
        }

        delegate void SetNotificationsCallback(string text);
        public void NotificationTextBox(string e)
        {
            if (this.NotificationsBox.InvokeRequired)
            {
                SetNotificationsCallback d = new SetNotificationsCallback(NotificationTextBox);
                this.Invoke(d, new object[] { e });
            }
            else
            {
                NotificationsBox.AppendText(e);
                NotificationsBox.Update();
            }
        }

        delegate void SetProgressBarCallBack(int id, string command,int length);
        public void ProgressBarStep(int id,string command,int length=0)
        {
            if (this.progressBars[id-1].InvokeRequired)
            {
                SetProgressBarCallBack d = new SetProgressBarCallBack(ProgressBarStep);
                this.Invoke(d, new object[] { id,command,length });
            }
            else
            {
                if (command == "PERFORM-STEP")
                {
                    progressBars[Convert.ToInt32(id) - 1].PerformStep();
                }
                else if (command == "GET-LENGTH")
                {
                    progressBars[Convert.ToInt32(id) - 1].Maximum=length;
                }
            }
        }

        private void buttonRunStop_Click(object sender, EventArgs e)
        {
            if(this.buttonRunStop.BackColor==Color.LimeGreen)
            {
                File.WriteAllText(@"C:\Users\Ben\Desktop\example\Notifications.txt", "");
                this.NotificationsBox.Text = "";


                for (int j = 0; j < this.textBoxes.Length; j++)
                {
                    textBoxes[j].Enabled = true;
                    textBoxes[j].Text = "";
                }

                for (int i = 0; i < this.pcbButtons.Length; i++)
                {
                    this.pcbButtons[i].Enabled = false;
                }

                for (int i = 0; i < this.progressBars.Length; i++) 
                {
                    this.progressBars[i].Value = 0;
                }

                Program.Start();
                this.trackBar1.Enabled = false;
                this.buttonRunStop.BackColor = Color.OrangeRed;
                this.buttonPauseResume.Enabled = true;
        
            }
            else
            {
                for (int j = 0; j < this.textBoxes.Length; j++)
                {
                    textBoxes[j].ReadOnly = true;
                    textBoxes[j].Enabled = false;
                }

                int i = 0;
                Node<PCB> t = Program.allprocesses;
                while(t!=null)
                {
                    if (t.GetValue().GetProcessType() == 'a') 
                    {
                        pcbButtons[i].Enabled = true;
                        i++;
                    }
                    
                    t = t.GetNext();
                }

                if(Program.timeToSleep)
                {
                    Program.timeToSleep = false;
                    Program._systemSleep.Release();
                }
                Program.Stop();
                this.buttonPauseResume.Enabled = false;
                this.buttonRunStop.BackColor = Color.LimeGreen;
                this.trackBar1.Enabled = true;
                this.buttonSave.Enabled = true;
                WriteStatistics();
         
            }
        }

        private void WriteStatistics()
        {
            Node<PCB> t = Program.allprocesses;
            int sumLength = 0;
            int sumTotalSlices = 0;
            int sumWaitingSlices = 0;
            int total;
            int counter = 0;
            while (t != null)
            {
                if (t.GetValue().GetProcessType() == 'a')
                {
                    counter++;
                    sumLength += t.GetValue().GetJobLength();
                    total = t.GetValue().GetSliceTerminated() - t.GetValue().GetSliceStart();
                    sumTotalSlices += total;
                    sumWaitingSlices += total - t.GetValue().GetRunningSlices();

                }
                t = t.GetNext();
            }



            //Page1
            this.label2.Text = "None";//Running Name
            this.label4.Text = DateTime.Now.ToString();//Date
            this.label6.Text = Program.Global.schedulingAlgoType;//Scheduling Algorithm
            this.label8.Text = counter.ToString();//Processes Amount
            this.label28.Text = Program.sliceSize.ToString();//Slice Size
            
            //Page2
            if(counter!=0)
            {
                this.label10.Text = Math.Round((double)(sumLength / counter), 2).ToString();//Average Process Length
                this.label12.Text = Math.Round((double)(sumTotalSlices / counter), 2).ToString();//Average Total Slices
                this.label14.Text = Math.Round((double)(sumWaitingSlices / counter), 2).ToString();//Average Waiting Time
            }
            else
            {
                this.label10.Text = "--";//Average Process Length
                this.label12.Text = "--";//Average Total Slices
                this.label14.Text = "--";//Average Waiting Time
            }

            Label[] processesLabels = { this.label15, this.label24,this.label22,this.label21 };
            
            //Page3
            t = Program.allprocesses;
            int i = 0;
            while (t != null)
            {
                if (t.GetValue().GetProcessType() == 'a')
                {
                    processesLabels[i].Text = t.GetValue().GetName();
                    i++;
                }
                t = t.GetNext();
            }

            //Page4
            label17.Text = Program.Global.memAlgoType;
            label19.Text = Program.maxMemUse.ToString();
            label23.Text = Program.totalMemUse.ToString();
        }
       

        private void buttonPauseResume_Click(object sender, EventArgs e)
        {
            if(!Program.timeToSleep)
            {
                
                Program.timeToSleep = true;
                for (int i = 0; i < this.textBoxes.Length; i++)
                    textBoxes[i].Enabled = false;
                this.trackBar1.Enabled = true;

                int j = 0;
                Node<PCB> t = Program.allprocesses;
                while (t != null)
                {
                    if (t.GetValue().GetProcessType() == 'a')
                    {
                        pcbButtons[j].Enabled = true;
                        j++;
                    }

                    t = t.GetNext();
                }
            }

            else
            {
                for (int i = 0; i < this.pcbButtons.Length; i++)
                {
                    this.pcbButtons[i].Enabled = false;
                }

                this.trackBar1.Enabled = false;
                for (int i = 0; i < this.textBoxes.Length; i++)
                    textBoxes[i].Enabled = true;
                Program.timeToSleep = false;
                Program._systemSleep.Release();
            }
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //0- defult
            //1- job listener only new job was found
            //2- if there is only 1 job don't write
            //3- without scheduler

            Program.Global.filter = this.trackBar1.Value;

            this.NotificationsBox.Text = "";
            string[] lines = File.ReadAllLines(@"C:\Users\Ben\Desktop\example\Notifications.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (Program.Global.filter == 0)
                {
                    NotificationsBox.AppendText(lines[i] + "\r\n");
                }
                else if (Program.Global.filter == 1)
                {
                    bool flag = true;
                    string[] t = Convert.ToString(lines[i]).Split(' ');
                    for (int j = 0; j < t.Length&&flag; j++)
                    {
                        if (t[j] == "Listener")
                        {
                            flag = false;
                            
                        }
                    }
                    if(flag)
                        NotificationsBox.AppendText(lines[i] + "\r\n");
                }
                
                else if (Program.Global.filter == 2)
                {
                    bool flag = true;
                    string[] t = Convert.ToString(lines[i]).Split(' ');
                    for (int j = 0; j < t.Length && flag; j++)
                    {
                        if (t[j] == "Listener"||t[j]=="Scheduler")
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                        NotificationsBox.AppendText(lines[i] + "\r\n");
                }
            }
        }

        private void TextBoxPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (this.enter)
            {
                e.Handled = true;
                t.ReadOnly = true;
                t.MaxLength = 32767;
                
                int index = Array.IndexOf(this.textBoxes, t);
                inputRequests[index].SetRegistersState("ax", t.Text[t.Text.Length - 1]);
                t.AppendText("\r\n");

                Program._inputSem.Release();
            }
            else
            {
                if (char.IsDigit(e.KeyChar) && t.SelectionStart == t.MaxLength - 1)
                    e.Handled = false;
                else if (e.KeyChar == (char)Keys.Back && t.SelectionStart == t.MaxLength)
                    e.Handled = false;
                else e.Handled = true;
            }
        }

        private void TextBoxCheckEnter(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.enter = false;

            if (e.KeyCode == Keys.Enter)
            {
                this.enter = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Program.settingsForm == null)
            {
                Form2 f = new Form2();
                Program.settingsForm = f;
            }


            Program.settingsForm.UpdateFilesList();
            Program.settingsForm.Location = this.Location;
            Program.settingsForm.Show();
            this.Hide();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            if (Program.processesForm == null)
            {
                Form3 f = new Form3();
                Program.processesForm = f;
            }
            
            Program.processesForm.Location = this.Location;
            Program.processesForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Node<PCB> t = Program.allprocesses;
            bool flag = true;
            while(flag)
            {
                if (t.GetValue().GetID() == 1)
                    flag = false;
                else
                    t = t.GetNext();
            }

            FormPCB f = new FormPCB(t.GetValue());
            f.Location = this.Location;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Node<PCB> t = Program.allprocesses;
            bool flag = true;
            while (flag)
            {
                if (t.GetValue().GetID() == 2)
                    flag = false;
                else
                    t = t.GetNext();
            }

            FormPCB f = new FormPCB(t.GetValue());
            f.Location = this.Location;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Node<PCB> t = Program.allprocesses;
            bool flag = true;
            while (flag)
            {
                if (t.GetValue().GetID() == 3)
                    flag = false;
                else
                    t = t.GetNext();
            }

            FormPCB f = new FormPCB(t.GetValue());
            f.Location = this.Location;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Node<PCB> t = Program.allprocesses;
            bool flag = true;
            while (flag)
            {
                if (t.GetValue().GetID() == 4)
                    flag = false;
                else
                    t = t.GetNext();
            }

            FormPCB f = new FormPCB(t.GetValue());
            f.Location = this.Location;
            f.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
           
            PopUpForm3 f = new PopUpForm3("last running",  @"C:\Users\Ben\Desktop\example\LastRunnings@\");
            DialogResult dialogresult = f.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                f.Dispose();

                this.path = f.GetPath();

                label2.Text = this.path.Substring(this.path.LastIndexOf('\\') + 1);

                using (StreamWriter sw = File.AppendText(this.path))
                {
                    sw.WriteLine(label1.Text + label2.Text);
                    sw.WriteLine(label7.Text + label4.Text);
                    sw.WriteLine(label3.Text + label6.Text);
                    sw.WriteLine(label5.Text + label8.Text);
                    sw.WriteLine(label27.Text + label28.Text);

                    sw.WriteLine(label9.Text + label10.Text);
                    sw.WriteLine(label11.Text + label12.Text);
                    sw.WriteLine(label13.Text + label14.Text);
                    sw.WriteLine(this.label15);
                    sw.WriteLine(this.label24);
                    sw.WriteLine(this.label22);
                    sw.WriteLine(this.label21);

                    //Page4
                    sw.WriteLine(this.label17);
                    sw.WriteLine(this.label19);
                    sw.WriteLine(this.label23);
                }
            }
            this.buttonSave.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenForm3 f = new OpenForm3(@"C:\Users\Ben\Desktop\example\LastRunnings@", "LastRunnings@");
            DialogResult dialogresult = f.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                f.Dispose();
                this.path = f.GetPath();
              
              
                FormStatistics formStat = new FormStatistics(this.path);
                formStat.Location = this.Location;
                formStat.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
            label28.Text = "";
            label10.Text = "";
            label12.Text = "";
            label14.Text = "";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (!Program.Global.isClockAlive)
            {
                DeleteForm f = new DeleteForm("Sure you want to exit?");
                DialogResult dialogresult = f.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    f.Dispose();
                    if(Program.Global.isClockAlive)
                    {
                        if (Program.timeToSleep)
                        {
                            Program.timeToSleep = false;
                            Program._systemSleep.Release();
                        }
                        Program.Stop();
                    }
                    Environment.Exit(0);
                    Application.Exit();
                }
                else f.Dispose();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Closes the entire program by clicking on the X
            //arg: e

            Environment.Exit(0);
            Application.Exit();
        }

       
    }
}