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
            this.check16 = new System.Windows.Forms.CheckBox();
            this.checkaA = new System.Windows.Forms.CheckBox();
            this.checkNNF = new System.Windows.Forms.CheckBox();
            this.checkDEH = new System.Windows.Forms.CheckBox();
            this.checkClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(477, 12);
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
            this.buttonHexify.Location = new System.Drawing.Point(12, 61);
            this.buttonHexify.Name = "buttonHexify";
            this.buttonHexify.Size = new System.Drawing.Size(540, 33);
            this.buttonHexify.TabIndex = 1;
            this.buttonHexify.Text = "Hexify !!";
            this.buttonHexify.UseVisualStyleBackColor = true;
            this.buttonHexify.Click += new System.EventHandler(this.buttonHexify_Click);
            // 
            // textOpen
            // 
            this.textOpen.AllowDrop = true;
            this.textOpen.Location = new System.Drawing.Point(12, 15);
            this.textOpen.Name = "textOpen";
            this.textOpen.ReadOnly = true;
            this.textOpen.Size = new System.Drawing.Size(459, 20);
            this.textOpen.TabIndex = 2;
            this.textOpen.Text = "Open File to Hexify...";
            this.textOpen.TextChanged += new System.EventHandler(this.textOpen_TextChanged);
            // 
            // labelVER
            // 
            this.labelVER.AutoSize = true;
            this.labelVER.Location = new System.Drawing.Point(519, 96);
            this.labelVER.Name = "labelVER";
            this.labelVER.Size = new System.Drawing.Size(43, 13);
            this.labelVER.TabIndex = 3;
            this.labelVER.Text = "ver. 1.0";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // check16
            // 
            this.check16.AutoSize = true;
            this.check16.Location = new System.Drawing.Point(12, 41);
            this.check16.Name = "check16";
            this.check16.Size = new System.Drawing.Size(106, 17);
            this.check16.TabIndex = 4;
            this.check16.Text = "Allign to 16 bytes";
            this.check16.UseVisualStyleBackColor = true;
            // 
            // checkaA
            // 
            this.checkaA.AutoSize = true;
            this.checkaA.Location = new System.Drawing.Point(124, 41);
            this.checkaA.Name = "checkaA";
            this.checkaA.Size = new System.Drawing.Size(57, 17);
            this.checkaA.TabIndex = 5;
            this.checkaA.Text = "a <> A";
            this.checkaA.UseVisualStyleBackColor = true;
            // 
            // checkNNF
            // 
            this.checkNNF.AutoSize = true;
            this.checkNNF.Location = new System.Drawing.Point(187, 41);
            this.checkNNF.Name = "checkNNF";
            this.checkNNF.Size = new System.Drawing.Size(82, 17);
            this.checkNNF.TabIndex = 6;
            this.checkNNF.Text = "No new File";
            this.checkNNF.UseVisualStyleBackColor = true;
            // 
            // checkDEH
            // 
            this.checkDEH.AutoSize = true;
            this.checkDEH.Location = new System.Drawing.Point(275, 41);
            this.checkDEH.Name = "checkDEH";
            this.checkDEH.Size = new System.Drawing.Size(72, 17);
            this.checkDEH.TabIndex = 7;
            this.checkDEH.Text = "De-Hexify";
            this.checkDEH.UseVisualStyleBackColor = true;
            // 
            // checkClose
            // 
            this.checkClose.AutoSize = true;
            this.checkClose.Location = new System.Drawing.Point(472, 41);
            this.checkClose.Name = "checkClose";
            this.checkClose.Size = new System.Drawing.Size(74, 17);
            this.checkClose.TabIndex = 8;
            this.checkClose.Text = "Close App";
            this.checkClose.UseVisualStyleBackColor = true;
            // 
            // Hexifyer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 111);
            this.Controls.Add(this.checkClose);
            this.Controls.Add(this.checkDEH);
            this.Controls.Add(this.checkNNF);
            this.Controls.Add(this.checkaA);
            this.Controls.Add(this.check16);
            this.Controls.Add(this.labelVER);
            this.Controls.Add(this.textOpen);
            this.Controls.Add(this.buttonHexify);
            this.Controls.Add(this.buttonOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hexifyer";
            this.Text = "Hexifyer";
            this.Load += new System.EventHandler(this.Hexifyer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonHexify;
        private System.Windows.Forms.TextBox textOpen;
        private System.Windows.Forms.Label labelVER;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.CheckBox check16;
        private System.Windows.Forms.CheckBox checkaA;
        private System.Windows.Forms.CheckBox checkNNF;
        private System.Windows.Forms.CheckBox checkDEH;
        private System.Windows.Forms.CheckBox checkClose;
    }
}

