namespace _17_AsyncAwaitSample
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
            this.executeSync = new System.Windows.Forms.Button();
            this.executeAsync = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ProcessFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // executeSync
            // 
            this.executeSync.Location = new System.Drawing.Point(83, 24);
            this.executeSync.Name = "executeSync";
            this.executeSync.Size = new System.Drawing.Size(546, 44);
            this.executeSync.TabIndex = 0;
            this.executeSync.Text = "Normal Execute";
            this.executeSync.UseVisualStyleBackColor = true;
            this.executeSync.Click += new System.EventHandler(this.executeSync_Click);
            // 
            // executeAsync
            // 
            this.executeAsync.Location = new System.Drawing.Point(83, 93);
            this.executeAsync.Name = "executeAsync";
            this.executeAsync.Size = new System.Drawing.Size(546, 44);
            this.executeAsync.TabIndex = 1;
            this.executeAsync.Text = "Async Execute";
            this.executeAsync.UseVisualStyleBackColor = true;
            this.executeAsync.Click += new System.EventHandler(this.executeAsync_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 221);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(546, 182);
            this.textBox1.TabIndex = 2;
            // 
            // ProcessFile
            // 
            this.ProcessFile.Location = new System.Drawing.Point(83, 156);
            this.ProcessFile.Name = "ProcessFile";
            this.ProcessFile.Size = new System.Drawing.Size(546, 44);
            this.ProcessFile.TabIndex = 3;
            this.ProcessFile.Text = "Progess File";
            this.ProcessFile.UseVisualStyleBackColor = true;
            this.ProcessFile.Click += new System.EventHandler(this.ProcessFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 443);
            this.Controls.Add(this.ProcessFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.executeAsync);
            this.Controls.Add(this.executeSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button executeSync;
        private System.Windows.Forms.Button executeAsync;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ProcessFile;
    }
}

