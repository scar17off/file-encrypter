namespace FileEncrypter
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
            this.keyInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inputDirectory = new System.Windows.Forms.TextBox();
            this.outputDirectory = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.encryptingProgressBar = new System.Windows.Forms.ProgressBar();
            this.keyInput2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.inputDirectory2 = new System.Windows.Forms.TextBox();
            this.outputDirectory2 = new System.Windows.Forms.TextBox();
            this.decryptingProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // keyInput
            // 
            this.keyInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyInput.Location = new System.Drawing.Point(48, 37);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(285, 20);
            this.keyInput.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(320, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputDirectory
            // 
            this.inputDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputDirectory.Location = new System.Drawing.Point(13, 94);
            this.inputDirectory.Name = "inputDirectory";
            this.inputDirectory.ReadOnly = true;
            this.inputDirectory.Size = new System.Drawing.Size(320, 20);
            this.inputDirectory.TabIndex = 2;
            this.inputDirectory.Click += new System.EventHandler(this.inputDirectory_Click);
            // 
            // outputDirectory
            // 
            this.outputDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputDirectory.Location = new System.Drawing.Point(13, 121);
            this.outputDirectory.Name = "outputDirectory";
            this.outputDirectory.ReadOnly = true;
            this.outputDirectory.Size = new System.Drawing.Size(320, 20);
            this.outputDirectory.TabIndex = 3;
            this.outputDirectory.Click += new System.EventHandler(this.outputDirectory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(23, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 286);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // encryptingProgressBar
            // 
            this.encryptingProgressBar.Location = new System.Drawing.Point(13, 439);
            this.encryptingProgressBar.Name = "encryptingProgressBar";
            this.encryptingProgressBar.Size = new System.Drawing.Size(320, 23);
            this.encryptingProgressBar.TabIndex = 5;
            // 
            // keyInput2
            // 
            this.keyInput2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyInput2.Location = new System.Drawing.Point(375, 37);
            this.keyInput2.Name = "keyInput2";
            this.keyInput2.Size = new System.Drawing.Size(284, 20);
            this.keyInput2.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(320, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Open folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // inputDirectory2
            // 
            this.inputDirectory2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputDirectory2.Location = new System.Drawing.Point(339, 94);
            this.inputDirectory2.Name = "inputDirectory2";
            this.inputDirectory2.ReadOnly = true;
            this.inputDirectory2.Size = new System.Drawing.Size(320, 20);
            this.inputDirectory2.TabIndex = 8;
            this.inputDirectory2.Click += new System.EventHandler(this.inputDirectory2_Click);
            // 
            // outputDirectory2
            // 
            this.outputDirectory2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputDirectory2.Location = new System.Drawing.Point(339, 121);
            this.outputDirectory2.Name = "outputDirectory2";
            this.outputDirectory2.ReadOnly = true;
            this.outputDirectory2.Size = new System.Drawing.Size(320, 20);
            this.outputDirectory2.TabIndex = 9;
            this.outputDirectory2.Click += new System.EventHandler(this.outputDirectory2_Click);
            // 
            // decryptingProgressBar
            // 
            this.decryptingProgressBar.Location = new System.Drawing.Point(339, 439);
            this.decryptingProgressBar.Name = "decryptingProgressBar";
            this.decryptingProgressBar.Size = new System.Drawing.Size(320, 23);
            this.decryptingProgressBar.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Encrypt folder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(339, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Decrypt folder";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Key:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(339, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Key:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(350, 147);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(300, 286);
            this.textBox4.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 474);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptingProgressBar);
            this.Controls.Add(this.outputDirectory2);
            this.Controls.Add(this.inputDirectory2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.keyInput2);
            this.Controls.Add(this.encryptingProgressBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.outputDirectory);
            this.Controls.Add(this.inputDirectory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.keyInput);
            this.Name = "Form1";
            this.Text = "FileEncrypter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keyInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inputDirectory;
        private System.Windows.Forms.TextBox outputDirectory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar encryptingProgressBar;
        private System.Windows.Forms.TextBox keyInput2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox inputDirectory2;
        private System.Windows.Forms.TextBox outputDirectory2;
        private System.Windows.Forms.ProgressBar decryptingProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
    }
}

