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
    public partial class OpenForm3 : Form
    {

        private string folderPath;
        private string folder;

        
        private string[] files;
        private string path = "";

        public OpenForm3(string folderPath, string folder)
        {
            this.folderPath = folderPath;
            this.folder = folder;

            this.files = Directory.GetFiles(this.folderPath);

            InitializeComponent();
            
        }

        public string GetPath()
        {
            return this.path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = comboBox1.Text.Split(' ')[0];
            bool flag = false;

            for (int i = 0; i < this.files.Length && !flag; i++) 
            {
                if (file == files[i])
                    flag = true;
            }

            if (!flag)
                this.DialogResult = DialogResult.None;
            else
            {
                this.path = this.folderPath+"\\" + file+".txt";
            }
        }

        private void OpenForm3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < files.Length; i++)
            {
                DateTime date = File.GetCreationTime(files[i]);
                files[i] = files[i].Substring(files[i].LastIndexOf(this.folder) + this.folder.Length+1);
                files[i] = files[i].Substring(0, files[i].Length - 4);
                
                comboBox1.Items.Add(files[i]+"  ---  "+date);
            }
        }
    }
}
