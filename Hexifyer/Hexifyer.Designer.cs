namespace Hexifyer
{
    partial class Hexifyer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hexifyer));
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonHexify = new System.Windows.Forms.Button();
            this.textOpen = new System.Windows.Forms.TextBox();
            this.labelVER = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.checkaA = new System.Windows.Forms.CheckBox();
            this.checkNNF = new System.Windows.Forms.CheckBox();
            this.checkDEH = new System.Windows.Forms.CheckBox();
            this.checkClose = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioH16 = new System.Windows.Forms.RadioButton();
            this.radioH8 = new System.Windows.Forms.RadioButton();
            this.radioH4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioB16 = new System.Windows.Forms.RadioButton();
            this.radioB8 = new System.Windows.Forms.RadioButton();
            this.radioB2 = new System.Windows.Forms.RadioButton();
            this.radioB1 = new System.Windows.Forms.RadioButton();
            this.radioB4 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(427, 13);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonHexify
            // 
            this.buttonHexify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHexify.Location = new System.Drawing.Point(12, 89);
            this.buttonHexify.Name = "buttonHexify";
            this.buttonHexify.Size = new System.Drawing.Size(490, 33);
            this.buttonHexify.TabIndex = 1;
            this.buttonHexify.Text = "Hexify !!";
            this.buttonHexify.UseVisualStyleBackColor = true;
            this.buttonHexify.Click += new System.EventHandler(this.buttonHexify_Click);
            // 
            // textOpen
            // 
            this.textOpen.AllowDrop = true;
            this.textOpen.BackColor = System.Drawing.SystemColors.WindowText;
            this.textOpen.ForeColor = System.Drawing.Color.Yellow;
            this.textOpen.Location = new System.Drawing.Point(12, 15);
            this.textOpen.Name = "textOpen";
            this.textOpen.ReadOnly = true;
            this.textOpen.Size = new System.Drawing.Size(409, 20);
            this.textOpen.TabIndex = 2;
            this.textOpen.Text = "Open File to Hexify...";
            this.textOpen.TextChanged += new System.EventHandler(this.textOpen_TextChanged);
            // 
            // labelVER
            // 
            this.labelVER.AutoSize = true;
            this.labelVER.Location = new System.Drawing.Point(463, 124);
            this.labelVER.Name = "labelVER";
            this.labelVER.Size = new System.Drawing.Size(43, 13);
            this.labelVER.TabIndex = 3;
            this.labelVER.Text = "ver. 1.1";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // checkaA
            // 
            this.checkaA.AutoSize = true;
            this.checkaA.Location = new System.Drawing.Point(321, 68);
            this.checkaA.Name = "checkaA";
            this.checkaA.Size = new System.Drawing.Size(57, 17);
            this.checkaA.TabIndex = 5;
            this.checkaA.Text = "a <> A";
            this.checkaA.UseVisualStyleBackColor = true;
            // 
            // checkNNF
            // 
            this.checkNNF.AutoSize = true;
            this.checkNNF.Location = new System.Drawing.Point(321, 44);
            this.checkNNF.Name = "checkNNF";
            this.checkNNF.Size = new System.Drawing.Size(82, 17);
            this.checkNNF.TabIndex = 6;
            this.checkNNF.Text = "No new File";
            this.checkNNF.UseVisualStyleBackColor = true;
            // 
            // checkDEH
            // 
            this.checkDEH.AutoSize = true;
            this.checkDEH.Location = new System.Drawing.Point(409, 67);
            this.checkDEH.Name = "checkDEH";
            this.checkDEH.Size = new System.Drawing.Size(72, 17);
            this.checkDEH.TabIndex = 7;
            this.checkDEH.Text = "De-Hexify";
            this.checkDEH.UseVisualStyleBackColor = true;
            // 
            // checkClose
            // 
            this.checkClose.AutoSize = true;
            this.checkClose.Location = new System.Drawing.Point(409, 44);
            this.checkClose.Name = "checkClose";
            this.checkClose.Size = new System.Drawing.Size(74, 17);
            this.checkClose.TabIndex = 8;
            this.checkClose.Text = "Close App";
            this.checkClose.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioH16);
            this.groupBox1.Controls.Add(this.radioH8);
            this.groupBox1.Controls.Add(this.radioH4);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 40);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hex Allign";
            // 
            // radioH16
            // 
            this.radioH16.AutoSize = true;
            this.radioH16.Location = new System.Drawing.Point(79, 17);
            this.radioH16.Name = "radioH16";
            this.radioH16.Size = new System.Drawing.Size(37, 17);
            this.radioH16.TabIndex = 2;
            this.radioH16.TabStop = true;
            this.radioH16.Text = "16";
            this.radioH16.UseVisualStyleBackColor = true;
            // 
            // radioH8
            // 
            this.radioH8.AutoSize = true;
            this.radioH8.Location = new System.Drawing.Point(43, 17);
            this.radioH8.Name = "radioH8";
            this.radioH8.Size = new System.Drawing.Size(31, 17);
            this.radioH8.TabIndex = 1;
            this.radioH8.TabStop = true;
            this.radioH8.Text = "8";
            this.radioH8.UseVisualStyleBackColor = true;
            // 
            // radioH4
            // 
            this.radioH4.AutoSize = true;
            this.radioH4.Location = new System.Drawing.Point(6, 17);
            this.radioH4.Name = "radioH4";
            this.radioH4.Size = new System.Drawing.Size(31, 17);
            this.radioH4.TabIndex = 0;
            this.radioH4.TabStop = true;
            this.radioH4.Text = "4";
            this.radioH4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioB16);
            this.groupBox2.Controls.Add(this.radioB8);
            this.groupBox2.Controls.Add(this.radioB2);
            this.groupBox2.Controls.Add(this.radioB1);
            this.groupBox2.Controls.Add(this.radioB4);
            this.groupBox2.Location = new System.Drawing.Point(140, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 41);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Byte Allign";
            // 
            // radioB16
            // 
            this.radioB16.AutoSize = true;
            this.radioB16.Location = new System.Drawing.Point(135, 17);
            this.radioB16.Name = "radioB16";
            this.radioB16.Size = new System.Drawing.Size(37, 17);
            this.radioB16.TabIndex = 4;
            this.radioB16.TabStop = true;
            this.radioB16.Text = "16";
            this.radioB16.UseVisualStyleBackColor = true;
            // 
            // radioB8
            // 
            this.radioB8.AutoSize = true;
            this.radioB8.Location = new System.Drawing.Point(102, 17);
            this.radioB8.Name = "radioB8";
            this.radioB8.Size = new System.Drawing.Size(31, 17);
            this.radioB8.TabIndex = 3;
            this.radioB8.TabStop = true;
            this.radioB8.Text = "8";
            this.radioB8.UseVisualStyleBackColor = true;
            // 
            // radioB2
            // 
            this.radioB2.AutoSize = true;
            this.radioB2.Location = new System.Drawing.Point(36, 17);
            this.radioB2.Name = "radioB2";
            this.radioB2.Size = new System.Drawing.Size(31, 17);
            this.radioB2.TabIndex = 1;
            this.radioB2.TabStop = true;
            this.radioB2.Text = "2";
            this.radioB2.UseVisualStyleBackColor = true;
            // 
            // radioB1
            // 
            this.radioB1.AutoSize = true;
            this.radioB1.Location = new System.Drawing.Point(4, 17);
            this.radioB1.Name = "radioB1";
            this.radioB1.Size = new System.Drawing.Size(31, 17);
            this.radioB1.TabIndex = 0;
            this.radioB1.TabStop = true;
            this.radioB1.Text = "1";
            this.radioB1.UseVisualStyleBackColor = true;
            // 
            // radioB4
            // 
            this.radioB4.AutoSize = true;
            this.radioB4.Location = new System.Drawing.Point(69, 17);
            this.radioB4.Name = "radioB4";
            this.radioB4.Size = new System.Drawing.Size(31, 17);
            this.radioB4.TabIndex = 2;
            this.radioB4.TabStop = true;
            this.radioB4.Text = "4";
            this.radioB4.UseVisualStyleBackColor = true;
            // 
            // Hexifyer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(513, 140);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkClose);
            this.Controls.Add(this.checkDEH);
            this.Controls.Add(this.checkNNF);
            this.Controls.Add(this.checkaA);
            this.Controls.Add(this.labelVER);
            this.Controls.Add(this.textOpen);
            this.Controls.Add(this.buttonHexify);
            this.Controls.Add(this.buttonOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hexifyer";
            this.Text = "Hexifyer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hexifyer_FormClosing);
            this.Load += new System.EventHandler(this.Hexifyer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonHexify;
        private System.Windows.Forms.TextBox textOpen;
        private System.Windows.Forms.Label labelVER;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.CheckBox checkaA;
        private System.Windows.Forms.CheckBox checkNNF;
        private System.Windows.Forms.CheckBox checkDEH;
        private System.Windows.Forms.CheckBox checkClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioH16;
        private System.Windows.Forms.RadioButton radioH8;
        private System.Windows.Forms.RadioButton radioH4;
        private System.Windows.Forms.RadioButton radioB16;
        private System.Windows.Forms.RadioButton radioB8;
        private System.Windows.Forms.RadioButton radioB2;
        private System.Windows.Forms.RadioButton radioB1;
        private System.Windows.Forms.RadioButton radioB4;
    }
}

