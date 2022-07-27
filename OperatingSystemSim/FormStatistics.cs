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
    public partial class FormStatistics : Form
    {
        private string path;

        public FormStatistics(string path)
        {
            this.path = path;
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(path);

            //Page1
            this.label2.Text = lines[0].Substring(5);//Date//Running Name
            this.label4.Text = lines[1].Substring(5);//Date
            this.label6.Text = lines[2].Split(':')[1];//Scheduling Algorithm
            this.label8.Text = lines[3].Split(':')[1];//Processes Amount
            this.label28.Text = lines[4].Split(':')[1];//Slice Size

            //Page2
            this.label10.Text = lines[5].Split(':')[1];//Average Process Length
            this.label12.Text = lines[6].Split(':')[1];//Average Total Slice
            this.label14.Text = lines[7].Split(':')[1];//Average Waiting Slice

            //Page3
            this.label15.Text = lines[8].Substring(lines[8].LastIndexOf("Text: ")+6);
            this.label24.Text=lines[9].Substring(lines[9].LastIndexOf("Text: ") + 6);
            this.label22.Text= lines[10].Substring(lines[10].LastIndexOf("Text: ") + 6);
            this.label21.Text= lines[11].Substring(lines[11].LastIndexOf("Text: ") + 6);

            //Page4
            this.label17.Text = lines[12].Substring(lines[12].LastIndexOf("Text: ") + 6);
            this.label19.Text = lines[13].Substring(lines[13].LastIndexOf("Text: ") + 6);
            this.label23.Text = lines[14].Substring(lines[14].LastIndexOf("Text: ") + 6);
        }
    }
}
