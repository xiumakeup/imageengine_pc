namespace TestDemo
{
    partial class EyewarpForm
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
            this.eyeWarpHScrollBar = new CCWin.SkinControl.SkinHScrollBar();
            this.eyeWarpButton1 = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eyeWarpHScrollBar);
            this.groupBox1.Controls.Add(this.eyeWarpButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 153);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // eyeWarpHScrollBar
            // 
            this.eyeWarpHScrollBar.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.eyeWarpHScrollBar.BackNormal = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.eyeWarpHScrollBar.BackPressed = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(202)))), ((int)(((byte)(239)))));
            this.eyeWarpHScrollBar.Base = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.eyeWarpHScrollBar.Border = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(210)))), ((int)(((byte)(249)))));
            this.eyeWarpHScrollBar.Fore = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(135)))), ((int)(((byte)(192)))));
            this.eyeWarpHScrollBar.InnerBorder = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.eyeWarpHScrollBar.Location = new System.Drawing.Point(17, 81);
            this.eyeWarpHScrollBar.Maximum = 109;
            this.eyeWarpHScrollBar.Name = "eyeWarpHScrollBar";
            this.eyeWarpHScrollBar.Size = new System.Drawing.Size(151, 17);
            this.eyeWarpHScrollBar.TabIndex = 4;
            this.eyeWarpHScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.eyeWarpHScrollBar_Scroll);
            // 
            // eyeWarpButton1
            // 
            this.eyeWarpButton1.BackColor = System.Drawing.Color.Transparent;
            this.eyeWarpButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.eyeWarpButton1.DownBack = null;
            this.eyeWarpButton1.Location = new System.Drawing.Point(55, 115);
            this.eyeWarpButton1.MouseBack = null;
            this.eyeWarpButton1.Name = "eyeWarpButton1";
            this.eyeWarpButton1.NormlBack = null;
            this.eyeWarpButton1.Size = new System.Drawing.Size(75, 23);
            this.eyeWarpButton1.TabIndex = 3;
            this.eyeWarpButton1.Text = "确定";
            this.eyeWarpButton1.UseVisualStyleBackColor = false;
            this.eyeWarpButton1.Click += new System.EventHandler(this.eyeWarpButton1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "程度：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EyewarpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 196);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(198, 196);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(198, 196);
            this.Name = "EyewarpForm";
            this.Text = "大眼";
            this.TitleCenter = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CCWin.SkinControl.SkinHScrollBar eyeWarpHScrollBar;
        private CCWin.SkinControl.SkinButton eyeWarpButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}