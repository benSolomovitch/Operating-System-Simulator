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
    public partial class Form2 : Form
    {
        public Form2()
        {
           
            InitializeComponent();
           
            comboBox1.SelectedIndex=0;
            comboBox2.SelectedIndex = 0;
            textBox1.KeyPress += TextBoxPressed;
            textBox1.Text = Program.sliceSize.ToString();
            checkedListBox1.ItemCheck += CheckedListBox1_ItemChecked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0)
            {
                Program.sliceSize = Convert.ToInt32(textBox1.Text);
                Program.Global.schedulingAlgoType = (string)comboBox1.SelectedItem;
                Program.Global.memAlgoType = (string)comboBox2.SelectedItem;

                Program.mainForm.Location = this.Location;
                Program.mainForm.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) != 0) 
            {
                Program.sliceSize = Convert.ToInt32(textBox1.Text);
                Program.Global.schedulingAlgoType = (string)comboBox1.SelectedItem;
                Program.Global.memAlgoType = (string)comboBox2.SelectedItem;
                if(Program.processesForm==null)
                {
                    Form3 f = new Form3();
                    Program.processesForm = f;
                }
                
                Program.processesForm.Location = this.Location;
                Program.processesForm.Show();
                this.Hide();
            }
            else
            {
                label4.Visible = true;
            }
        }



        private void TextBoxPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            label4.Visible = false;
            TextBox t = (TextBox)sender;
            
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) 
                e.Handled = false;
            
            else e.Handled = true;
            
        }

        

        public void UpdateFilesList()
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--) 
            {
                checkedListBox1.Items.Remove(checkedListBox1.Items[i]);   
            }


            Program.Global.files = Directory.GetFiles(@"C:\Users\Ben\Desktop\example\AsmJobs@");
            for (int i = 0; i < Program.Global.files.Length; i++)
            {
                this.checkedListBox1.Items.Add(Program.Global.files[i].Substring(Program.Global.files[i].LastIndexOf("AsmJobs@") + 9));
                Node<string> f = Program.jobsToRun;
                bool flag = true;
                while (f != null && flag) 
                {
                    if (f.GetValue().Substring(f.GetValue().LastIndexOf("AsmJobs@") + 9) == checkedListBox1.Items[i].ToString()) 
                    {
                        checkedListBox1.SetItemChecked(i, true);
                        flag = false;
                    }
                    f = f.GetNext();
                }
            }
        }

        private void CheckedListBox1_ItemChecked(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox chk = sender as CheckedListBox;
            if (e.NewValue == CheckState.Checked)
            {
                if (chk.CheckedItems.Count > 3) 
                    e.NewValue = CheckState.Unchecked;
                else
                {
                    AppendJob(Program.Global.files[e.Index]);
                }
            }
            else
            {
                if(!Program.Global.isClockAlive)
                {
                    RemoveJob(Program.Global.files[e.Index]);
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                }
            }   
        }

        private void AppendJob(string name)
        {
            Node<string> f = Program.jobsToRun;
            bool flag = true;
            while (f != null && flag) 
            {
                if (f.GetValue() == name)
                    flag = false;
                f = f.GetNext();
            }
            if (flag)
            {
                if (Program.jobsToRun == null)
                    Program.jobsToRun = new Node<string>(name);
                else
                {
                    Node<string> temp = Program.jobsToRun;

                    while (temp.GetNext() != null)
                        temp = temp.GetNext();
                    temp.SetNext(new Node<string>(name));
                }
            }
        }

        static void RemoveJob(string name)
        {
            Node<string> temp = Program.jobsToRun;
            if (temp.GetValue() == name)
            {
                
                Program.jobsToRun = Program.jobsToRun.GetNext();
                temp.SetNext(null);
            }
            else
            {
                while (temp.GetNext().GetValue() != name) 
                {
                    temp = temp.GetNext();
                }
                Node<string> d = temp.GetNext();
                temp.SetNext(d.GetNext());
                d.SetNext(null);
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