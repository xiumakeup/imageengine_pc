namespace TestDemo
{
    partial class SoftskinForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.softskinHScrollBar1 = new CCWin.SkinControl.SkinHScrollBar();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.softskinHScrollBar1);
            this.groupBox1.Controls.Add(this.skinButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 195);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // softskinHScrollBar1
            // 
            this.softskinHScrollBar1.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.softskinHScrollBar1.BackNormal = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.softskinHScrollBar1.BackPressed = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(202)))), ((int)(((byte)(239)))));
            this.softskinHScrollBar1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.softskinHScrollBar1.Border = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(210)))), ((int)(((byte)(249)))));
            this.softskinHScrollBar1.Fore = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(135)))), ((int)(((byte)(192)))));
            this.softskinHScrollBar1.InnerBorder = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.softskinHScrollBar1.Location = new System.Drawing.Point(27, 83);
            this.softskinHScrollBar1.Maximum = 109;
            this.softskinHScrollBar1.Name = "softskinHScrollBar1";
            this.softskinHScrollBar1.Size = new System.Drawing.Size(151, 17);
            this.softskinHScrollBar1.TabIndex = 4;
            this.softskinHScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.skinHScrollBar1_Scroll);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(58, 153);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(75, 23);
            this.skinButton1.TabIndex = 3;
            this.skinButton1.Text = "确定";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "磨皮强度：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SoftskinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 237);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(212, 237);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(212, 237);
            this.Name = "SoftskinForm";
            this.Text = "磨皮";
            this.TitleCenter = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CCWin.SkinControl.SkinHScrollBar softskinHScrollBar1;
        private CCWin.SkinControl.SkinButton skinButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;

    }
}