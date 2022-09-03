namespace PCB_BEE
{
    partial class DrawFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bestFit_btn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 508);
            this.panel1.TabIndex = 0;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // bestFit_btn
            // 
            this.bestFit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bestFit_btn.BackColor = System.Drawing.Color.Khaki;
            this.bestFit_btn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bestFit_btn.ForeColor = System.Drawing.Color.DarkCyan;
            this.bestFit_btn.Location = new System.Drawing.Point(969, 515);
            this.bestFit_btn.Name = "bestFit_btn";
            this.bestFit_btn.Size = new System.Drawing.Size(116, 131);
            this.bestFit_btn.TabIndex = 1;
            this.bestFit_btn.Text = "Find best fitness";
            this.bestFit_btn.UseVisualStyleBackColor = false;
            this.bestFit_btn.Click += new System.EventHandler(this.bestFit_btn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(11, 517);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(952, 131);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.DarkCyan;
            this.panel2.Location = new System.Drawing.Point(546, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 508);
            this.panel2.TabIndex = 3;
            // 
            // DrawFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1086, 649);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bestFit_btn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Draw";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bestFit_btn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
    }
}