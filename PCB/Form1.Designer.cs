namespace PCB_BEE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.start_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.num_bees_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itration_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.feeder_arrang_checkbox = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.load_btn = new System.Windows.Forms.Button();
            this.num_comps_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.num_feeders_textBox = new System.Windows.Forms.TextBox();
            this.route_ngh_checkbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.manualRadio = new System.Windows.Forms.RadioButton();
            this.randomRadio = new System.Windows.Forms.RadioButton();
            this.n1_numBox = new System.Windows.Forms.NumericUpDown();
            this.n1_label = new System.Windows.Forms.Label();
            this.n2_numBox = new System.Windows.Forms.NumericUpDown();
            this.n2_label = new System.Windows.Forms.Label();
            this.e_numBox = new System.Windows.Forms.NumericUpDown();
            this.m_label = new System.Windows.Forms.Label();
            this.m_numBox = new System.Windows.Forms.NumericUpDown();
            this.e_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.opts_comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.type_comboBox = new System.Windows.Forms.ComboBox();
            this.turret_textBox = new System.Windows.Forms.TextBox();
            this.turrent_speed = new System.Windows.Forms.Label();
            this.draw_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n1_numBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2_numBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_numBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.richTextBox1.Location = new System.Drawing.Point(333, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(609, 388);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type of PCB machine";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_btn
            // 
            this.start_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.start_btn.BackColor = System.Drawing.Color.Khaki;
            this.start_btn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.start_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_btn.Location = new System.Drawing.Point(770, 430);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(172, 43);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "START";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of BEES ( n )";
            // 
            // num_bees_textbox
            // 
            this.num_bees_textbox.Location = new System.Drawing.Point(222, 25);
            this.num_bees_textbox.Name = "num_bees_textbox";
            this.num_bees_textbox.Size = new System.Drawing.Size(61, 20);
            this.num_bees_textbox.TabIndex = 5;
            this.num_bees_textbox.TextChanged += new System.EventHandler(this.num_bees_textbox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Times of iteration";
            // 
            // itration_textbox
            // 
            this.itration_textbox.Location = new System.Drawing.Point(222, 53);
            this.itration_textbox.Name = "itration_textbox";
            this.itration_textbox.Size = new System.Drawing.Size(61, 20);
            this.itration_textbox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Opts to find neighbours";
            // 
            // feeder_arrang_checkbox
            // 
            this.feeder_arrang_checkbox.AutoSize = true;
            this.feeder_arrang_checkbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.feeder_arrang_checkbox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.feeder_arrang_checkbox.ForeColor = System.Drawing.Color.Black;
            this.feeder_arrang_checkbox.Location = new System.Drawing.Point(9, 137);
            this.feeder_arrang_checkbox.Name = "feeder_arrang_checkbox";
            this.feeder_arrang_checkbox.Size = new System.Drawing.Size(149, 18);
            this.feeder_arrang_checkbox.TabIndex = 10;
            this.feeder_arrang_checkbox.Text = "Feeder arrangement";
            this.feeder_arrang_checkbox.UseVisualStyleBackColor = true;
            this.feeder_arrang_checkbox.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // load_btn
            // 
            this.load_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.load_btn.AutoEllipsis = true;
            this.load_btn.BackColor = System.Drawing.Color.Khaki;
            this.load_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_btn.Location = new System.Drawing.Point(333, 431);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(164, 42);
            this.load_btn.TabIndex = 12;
            this.load_btn.Text = "Load Board and Feeders";
            this.load_btn.UseVisualStyleBackColor = false;
            this.load_btn.Visible = false;
            this.load_btn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // num_comps_textBox
            // 
            this.num_comps_textBox.Enabled = false;
            this.num_comps_textBox.Location = new System.Drawing.Point(222, 53);
            this.num_comps_textBox.Name = "num_comps_textBox";
            this.num_comps_textBox.ReadOnly = true;
            this.num_comps_textBox.Size = new System.Drawing.Size(61, 20);
            this.num_comps_textBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "No. of components on the board";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "No. of feeders";
            // 
            // num_feeders_textBox
            // 
            this.num_feeders_textBox.Enabled = false;
            this.num_feeders_textBox.Location = new System.Drawing.Point(222, 79);
            this.num_feeders_textBox.Name = "num_feeders_textBox";
            this.num_feeders_textBox.ReadOnly = true;
            this.num_feeders_textBox.Size = new System.Drawing.Size(61, 20);
            this.num_feeders_textBox.TabIndex = 16;
            // 
            // route_ngh_checkbox
            // 
            this.route_ngh_checkbox.AutoSize = true;
            this.route_ngh_checkbox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.route_ngh_checkbox.ForeColor = System.Drawing.Color.Black;
            this.route_ngh_checkbox.Location = new System.Drawing.Point(9, 81);
            this.route_ngh_checkbox.Name = "route_ngh_checkbox";
            this.route_ngh_checkbox.Size = new System.Drawing.Size(190, 18);
            this.route_ngh_checkbox.TabIndex = 18;
            this.route_ngh_checkbox.Text = "Find neighbours for routes";
            this.route_ngh_checkbox.UseVisualStyleBackColor = true;
            this.route_ngh_checkbox.CheckedChanged += new System.EventHandler(this.route_ngh_checkbox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.manualRadio);
            this.groupBox1.Controls.Add(this.randomRadio);
            this.groupBox1.Controls.Add(this.n1_numBox);
            this.groupBox1.Controls.Add(this.n1_label);
            this.groupBox1.Controls.Add(this.n2_numBox);
            this.groupBox1.Controls.Add(this.n2_label);
            this.groupBox1.Controls.Add(this.e_numBox);
            this.groupBox1.Controls.Add(this.m_label);
            this.groupBox1.Controls.Add(this.m_numBox);
            this.groupBox1.Controls.Add(this.e_label);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 152);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // manualRadio
            // 
            this.manualRadio.AutoSize = true;
            this.manualRadio.Checked = true;
            this.manualRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualRadio.ForeColor = System.Drawing.Color.Yellow;
            this.manualRadio.Location = new System.Drawing.Point(9, 19);
            this.manualRadio.Name = "manualRadio";
            this.manualRadio.Size = new System.Drawing.Size(78, 21);
            this.manualRadio.TabIndex = 22;
            this.manualRadio.TabStop = true;
            this.manualRadio.Text = "Manual";
            this.manualRadio.UseVisualStyleBackColor = true;
            // 
            // randomRadio
            // 
            this.randomRadio.AutoSize = true;
            this.randomRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomRadio.ForeColor = System.Drawing.Color.Yellow;
            this.randomRadio.Location = new System.Drawing.Point(188, 19);
            this.randomRadio.Name = "randomRadio";
            this.randomRadio.Size = new System.Drawing.Size(85, 21);
            this.randomRadio.TabIndex = 23;
            this.randomRadio.Text = "Random";
            this.randomRadio.UseVisualStyleBackColor = true;
            this.randomRadio.CheckedChanged += new System.EventHandler(this.randomRadio_CheckedChanged);
            // 
            // n1_numBox
            // 
            this.n1_numBox.Location = new System.Drawing.Point(222, 125);
            this.n1_numBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n1_numBox.Name = "n1_numBox";
            this.n1_numBox.Size = new System.Drawing.Size(61, 20);
            this.n1_numBox.TabIndex = 34;
            this.n1_numBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // n1_label
            // 
            this.n1_label.AutoSize = true;
            this.n1_label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.n1_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.n1_label.Location = new System.Drawing.Point(6, 125);
            this.n1_label.Name = "n1_label";
            this.n1_label.Size = new System.Drawing.Size(209, 14);
            this.n1_label.TabIndex = 28;
            this.n1_label.Text = "n1 ( A number between 1 to n2)";
            // 
            // n2_numBox
            // 
            this.n2_numBox.Location = new System.Drawing.Point(222, 99);
            this.n2_numBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n2_numBox.Name = "n2_numBox";
            this.n2_numBox.Size = new System.Drawing.Size(61, 20);
            this.n2_numBox.TabIndex = 33;
            this.n2_numBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n2_numBox.ValueChanged += new System.EventHandler(this.n2_numBox_ValueChanged);
            // 
            // n2_label
            // 
            this.n2_label.AutoSize = true;
            this.n2_label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.n2_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.n2_label.Location = new System.Drawing.Point(6, 99);
            this.n2_label.Name = "n2_label";
            this.n2_label.Size = new System.Drawing.Size(205, 14);
            this.n2_label.TabIndex = 29;
            this.n2_label.Text = "n2 ( A number between 1 to n )";
            // 
            // e_numBox
            // 
            this.e_numBox.Location = new System.Drawing.Point(222, 72);
            this.e_numBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.e_numBox.Name = "e_numBox";
            this.e_numBox.Size = new System.Drawing.Size(61, 20);
            this.e_numBox.TabIndex = 32;
            this.e_numBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_label
            // 
            this.m_label.AutoSize = true;
            this.m_label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.m_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.m_label.Location = new System.Drawing.Point(6, 48);
            this.m_label.Name = "m_label";
            this.m_label.Size = new System.Drawing.Size(200, 14);
            this.m_label.TabIndex = 30;
            this.m_label.Text = "m ( A number between 1 to n )";
            // 
            // m_numBox
            // 
            this.m_numBox.Location = new System.Drawing.Point(222, 47);
            this.m_numBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_numBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numBox.Name = "m_numBox";
            this.m_numBox.Size = new System.Drawing.Size(61, 20);
            this.m_numBox.TabIndex = 22;
            this.m_numBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numBox.ValueChanged += new System.EventHandler(this.m_numBox_ValueChanged);
            // 
            // e_label
            // 
            this.e_label.AutoSize = true;
            this.e_label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.e_label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.e_label.Location = new System.Drawing.Point(6, 73);
            this.e_label.Name = "e_label";
            this.e_label.Size = new System.Drawing.Size(199, 14);
            this.e_label.TabIndex = 31;
            this.e_label.Text = "e ( A number between 1 to m )";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.opts_comboBox);
            this.groupBox2.Controls.Add(this.feeder_arrang_checkbox);
            this.groupBox2.Controls.Add(this.route_ngh_checkbox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.num_bees_textbox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.itration_textbox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 168);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bee Parameters";
            // 
            // opts_comboBox
            // 
            this.opts_comboBox.AllowDrop = true;
            this.opts_comboBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.opts_comboBox.Enabled = false;
            this.opts_comboBox.FormattingEnabled = true;
            this.opts_comboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.opts_comboBox.Location = new System.Drawing.Point(222, 103);
            this.opts_comboBox.Name = "opts_comboBox";
            this.opts_comboBox.Size = new System.Drawing.Size(61, 21);
            this.opts_comboBox.TabIndex = 24;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.type_comboBox);
            this.groupBox3.Controls.Add(this.turret_textBox);
            this.groupBox3.Controls.Add(this.turrent_speed);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.num_comps_textBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.num_feeders_textBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 134);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Board & Feeders information";
            // 
            // type_comboBox
            // 
            this.type_comboBox.AllowDrop = true;
            this.type_comboBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.type_comboBox.FormattingEnabled = true;
            this.type_comboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.type_comboBox.Location = new System.Drawing.Point(222, 25);
            this.type_comboBox.Name = "type_comboBox";
            this.type_comboBox.Size = new System.Drawing.Size(61, 21);
            this.type_comboBox.TabIndex = 23;
            this.type_comboBox.SelectedIndexChanged += new System.EventHandler(this.type_comboBox_SelectedIndexChanged);
            // 
            // turret_textBox
            // 
            this.turret_textBox.Enabled = false;
            this.turret_textBox.Location = new System.Drawing.Point(222, 107);
            this.turret_textBox.Name = "turret_textBox";
            this.turret_textBox.ReadOnly = true;
            this.turret_textBox.Size = new System.Drawing.Size(61, 20);
            this.turret_textBox.TabIndex = 18;
            // 
            // turrent_speed
            // 
            this.turrent_speed.AutoSize = true;
            this.turrent_speed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.turrent_speed.ForeColor = System.Drawing.SystemColors.InfoText;
            this.turrent_speed.Location = new System.Drawing.Point(6, 109);
            this.turrent_speed.Name = "turrent_speed";
            this.turrent_speed.Size = new System.Drawing.Size(138, 14);
            this.turrent_speed.TabIndex = 17;
            this.turrent_speed.Text = "Speed of Turret head";
            // 
            // draw_btn
            // 
            this.draw_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.draw_btn.BackColor = System.Drawing.Color.Khaki;
            this.draw_btn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.draw_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.draw_btn.Location = new System.Drawing.Point(553, 431);
            this.draw_btn.Name = "draw_btn";
            this.draw_btn.Size = new System.Drawing.Size(172, 43);
            this.draw_btn.TabIndex = 22;
            this.draw_btn.Text = "Draw";
            this.draw_btn.UseVisualStyleBackColor = false;
            this.draw_btn.Visible = false;
            this.draw_btn.Click += new System.EventHandler(this.draw_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(954, 484);
            this.Controls.Add(this.draw_btn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.load_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCB assembly ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n1_numBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n2_numBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_numBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox num_bees_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itration_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox feeder_arrang_checkbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.TextBox num_comps_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox num_feeders_textBox;
        private System.Windows.Forms.CheckBox route_ngh_checkbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton randomRadio;
        private System.Windows.Forms.RadioButton manualRadio;
        private System.Windows.Forms.Label e_label;
        private System.Windows.Forms.Label m_label;
        private System.Windows.Forms.Label n2_label;
        private System.Windows.Forms.Label n1_label;
        private System.Windows.Forms.NumericUpDown n1_numBox;
        private System.Windows.Forms.NumericUpDown n2_numBox;
        private System.Windows.Forms.NumericUpDown e_numBox;
        private System.Windows.Forms.NumericUpDown m_numBox;
        private System.Windows.Forms.Button draw_btn;
        private System.Windows.Forms.Label turrent_speed;
        private System.Windows.Forms.TextBox turret_textBox;
        private System.Windows.Forms.ComboBox type_comboBox;
        private System.Windows.Forms.ComboBox opts_comboBox;
    }
}

