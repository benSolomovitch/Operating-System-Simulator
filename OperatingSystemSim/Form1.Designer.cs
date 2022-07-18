namespace OperatingSystemSim
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NotificationsBox = new System.Windows.Forms.TextBox();
            this.buttonRunStop = new System.Windows.Forms.Button();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotificationsBox
            // 
            this.NotificationsBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NotificationsBox.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotificationsBox.Location = new System.Drawing.Point(438, 363);
            this.NotificationsBox.Multiline = true;
            this.NotificationsBox.Name = "NotificationsBox";
            this.NotificationsBox.ReadOnly = true;
            this.NotificationsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotificationsBox.Size = new System.Drawing.Size(350, 80);
            this.NotificationsBox.TabIndex = 0;
            // 
            // buttonRunStop
            // 
            this.buttonRunStop.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonRunStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRunStop.Location = new System.Drawing.Point(447, 36);
            this.buttonRunStop.Name = "buttonRunStop";
            this.buttonRunStop.Size = new System.Drawing.Size(72, 23);
            this.buttonRunStop.TabIndex = 1;
            this.buttonRunStop.Text = "Run/Stop";
            this.buttonRunStop.UseVisualStyleBackColor = false;
            this.buttonRunStop.Click += new System.EventHandler(this.buttonRunStop_Click);
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonPauseResume.Enabled = false;
            this.buttonPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPauseResume.Location = new System.Drawing.Point(525, 36);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(91, 23);
            this.buttonPauseResume.TabIndex = 4;
            this.buttonPauseResume.Text = "Pause/Resume";
            this.buttonPauseResume.UseVisualStyleBackColor = false;
            this.buttonPauseResume.Click += new System.EventHandler(this.buttonPauseResume_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Enabled = false;
            this.progressBar2.Location = new System.Drawing.Point(3, 33);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(315, 23);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 6;
            // 
            // progressBar3
            // 
            this.progressBar3.Enabled = false;
            this.progressBar3.Location = new System.Drawing.Point(3, 63);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(315, 23);
            this.progressBar3.Step = 1;
            this.progressBar3.TabIndex = 7;
            // 
            // progressBar4
            // 
            this.progressBar4.Enabled = false;
            this.progressBar4.Location = new System.Drawing.Point(3, 93);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(315, 23);
            this.progressBar4.Step = 1;
            this.progressBar4.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(315, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(350, 65);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(3, 74);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(350, 65);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox3.Location = new System.Drawing.Point(3, 145);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(350, 65);
            this.textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox4.Location = new System.Drawing.Point(3, 216);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(350, 65);
            this.textBox4.TabIndex = 13;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(438, 312);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeftLayout = true;
            this.trackBar1.Size = new System.Drawing.Size(350, 45);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 24);
            this.toolStripButton1.Text = "Main";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(76, 24);
            this.toolStripButton5.Text = "Processes";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(66, 24);
            this.toolStripButton3.Text = "Settings";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(359, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 65);
            this.button1.TabIndex = 16;
            this.button1.Text = "PCB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(359, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 65);
            this.button2.TabIndex = 17;
            this.button2.Text = "PCB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(359, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 65);
            this.button3.TabIndex = 18;
            this.button3.Text = "PCB";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(359, 216);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 65);
            this.button4.TabIndex = 19;
            this.button4.Text = "PCB";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(622, 36);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(65, 23);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(693, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "History";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 285);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.progressBar1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.progressBar2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.progressBar3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.progressBar4, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 321);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(350, 122);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(239, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Time";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label14, 1, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(227, 166);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Average Process Length:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(117, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 36);
            this.label11.TabIndex = 2;
            this.label11.Text = "Average Total Slices:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(117, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 18);
            this.label12.TabIndex = 3;
            this.label12.Text = "12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 36);
            this.label13.TabIndex = 4;
            this.label13.Text = "Average Waiting Slices:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(117, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 18);
            this.label14.TabIndex = 5;
            this.label14.Text = "14";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(239, 178);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label28, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label27, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 166);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(117, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "8";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(117, 145);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 16);
            this.label28.TabIndex = 9;
            this.label28.Text = "label28";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(4, 145);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 16);
            this.label27.TabIndex = 8;
            this.label27.Text = "Slice Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Processes Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scheduling Algorithm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(117, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Date:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(498, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(247, 204);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(239, 178);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Processes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label21, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label22, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label24, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(227, 166);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Name:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(4, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(124, 16);
            this.label21.TabIndex = 4;
            this.label21.Text = "Processes Amount:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(137, 16);
            this.label22.TabIndex = 2;
            this.label22.Text = "Scheduling Algorithm:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(4, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 16);
            this.label24.TabIndex = 6;
            this.label24.Text = "Date:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(239, 178);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Memory";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label17, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label19, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label20, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label23, 1, 2);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(227, 166);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 54);
            this.label16.TabIndex = 0;
            this.label16.Text = "Memory Allocation Algorithm:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(117, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 18);
            this.label17.TabIndex = 1;
            this.label17.Text = "17";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 36);
            this.label18.TabIndex = 2;
            this.label18.Text = "Max Memory Usage:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(117, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 18);
            this.label19.TabIndex = 3;
            this.label19.Text = "19";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 111);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 36);
            this.label20.TabIndex = 4;
            this.label20.Text = "Total Memory Usage:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(117, 111);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 18);
            this.label23.TabIndex = 5;
            this.label23.Text = "23";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonPauseResume);
            this.Controls.Add(this.buttonRunStop);
            this.Controls.Add(this.NotificationsBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NotificationsBox;
        private System.Windows.Forms.Button buttonRunStop;
        private System.Windows.Forms.Button buttonPauseResume;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
    }
}

