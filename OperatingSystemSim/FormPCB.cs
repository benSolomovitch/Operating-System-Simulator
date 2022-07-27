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
    public partial class FormPCB : Form
    {
        private PCB p;

        public FormPCB(PCB p)
        {
            this.p = p;
            InitializeComponent();
        }

        private void FormPCB_Load(object sender, EventArgs e)
        {
            //First Page
            label2.Text = this.p.GetID().ToString();
            label4.Text = this.p.GetName();
            label6.Text = this.p.GetJobLength().ToString();
            label28.Text = this.p.GetState();
            label8.Text = this.p.GetRemainingLength().ToString();

            //Seconed Page
            Dictionary<string, int> reg = this.p.GetRegistersState();
            label10.Text = reg["ax"].ToString();
            label12.Text = reg["bx"].ToString();
            label14.Text = reg["cx"].ToString();
            label16.Text = reg["dx"].ToString();

            //Third Page
            label18.Text = this.p.GetSliceStart().ToString();
            if (this.p.GetSliceTerminated() == -1)
            {
                label20.Text = "Still Running";
                label22.Text = "Still Running";
                label24.Text = "Still Running";
                label26.Text = "Still Running";
            }
            else
            {
                int total= this.p.GetSliceTerminated() - this.p.GetSliceStart();
                label20.Text = this.p.GetSliceTerminated().ToString();
                label22.Text = this.p.GetRunningSlices().ToString();
                label24.Text = (total - this.p.GetRunningSlices()).ToString();
                label26.Text = total.ToString();
            }
        }
    }
}
