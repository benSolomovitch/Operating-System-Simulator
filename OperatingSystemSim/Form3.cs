using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OperatingSystemSim
{
    public partial class Form3 : Form
    {
        private string path = "";

        public Form3()
        {
            InitializeComponent();
            this.toolStripLabel1.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         
            Program.mainForm.Location = this.Location;
            Program.mainForm.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(Program.settingsForm==null)
            {
                //Form2 f = new Form2();
                //Program.settingsForm = f;
            }

            Program.settingsForm.UpdateFilesList();
            Program.settingsForm.Location = this.Location;
            Program.settingsForm.Show();
            this.Hide();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(path=="")
            {
                PopUpForm3 f = new PopUpForm3("process", Directory.GetCurrentDirectory() + @"\AsmJobs@\");
                DialogResult dialogresult = f.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    f.Dispose();
                    this.path = f.GetPath();
                    using (StreamWriter sw = File.AppendText(this.path))
                    {
                        sw.WriteLine(this.textBox1.Text);
                    }
                    this.toolStripLabel1.Text = this.path.Substring(this.path.LastIndexOf("AsmJobs@") + 9);
                }
            }

            else
            {
                File.WriteAllText(this.path, this.textBox1.Text);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenForm3 f = new OpenForm3(Directory.GetCurrentDirectory() + @"\AsmJobs@", "AsmJobs@");
            DialogResult dialogresult = f.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                f.Dispose();
                this.textBox1.Text = "";
                this.path = f.GetPath();
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                    this.textBox1.AppendText(lines[i]+"\r\n");
                this.toolStripLabel1.Text = this.path.Substring(this.path.LastIndexOf("AsmJobs@") + 9);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Delete
            if(this.path!="")
            {
                DeleteForm f = new DeleteForm("This File will be deleted permanently");
                DialogResult dialogresult = f.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    f.Dispose();
                    File.Delete(this.path);
                    this.path = "";
                    this.textBox1.Text = "";
                    this.toolStripLabel1.Text = "";
                }
                else f.Dispose();
            }

           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.path = "";
            this.toolStripLabel1.Text = "";
            this.textBox1.Text = "";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (!Program.Global.isClockAlive)
            {
                DeleteForm f = new DeleteForm("Sure you want to exit?");
                DialogResult dialogresult = f.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    f.Dispose();
                    if (Program.Global.isClockAlive)
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
