using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatingSystemSim
{
    public partial class PopUpForm3 : Form
    {
        private string path = "";
        private string type;
        private string folder;
        private int charsCounter;

        public PopUpForm3(string type,string folder)
        {
            this.folder = folder;
            this.type = type;
            InitializeComponent();
            this.button1.DialogResult = DialogResult.OK;
            textBox1.KeyPress += TextBoxPressed;
            charsCounter = 0;
        }

        private void PopUpForm3_Load(object sender, EventArgs e)
        {
            label1.Text = "Choose a name to the " + type;
        }

        public string GetPath()
        {
            return this.path;
        }

        private void TextBoxPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (char.IsLetterOrDigit(e.KeyChar) && this.charsCounter < 7)
            {
                this.charsCounter++;
                e.Handled = false;
            }
            else if(e.KeyChar == (char)Keys.Back)
            {
                if (this.charsCounter > 0)
                    this.charsCounter--;
                e.Handled = false;
            }
            else
            { 
                e.Handled = true;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            {
                this.path = this.folder+ textBox1.Text + ".txt";
                Console.WriteLine(this.path);
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }   
        }
    }
}
