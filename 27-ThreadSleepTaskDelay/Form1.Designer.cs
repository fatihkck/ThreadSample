namespace _27_ThreadSleepTaskDelay
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
            this.ThreadSleep = new System.Windows.Forms.Button();
            this.TaskDelay = new System.Windows.Forms.Button();
            this.CancelTaskDelay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ThreadSleep
            // 
            this.ThreadSleep.Location = new System.Drawing.Point(195, 77);
            this.ThreadSleep.Name = "ThreadSleep";
            this.ThreadSleep.Size = new System.Drawing.Size(279, 39);
            this.ThreadSleep.TabIndex = 0;
            this.ThreadSleep.Text = "Thread Sleep";
            this.ThreadSleep.UseVisualStyleBackColor = true;
            this.ThreadSleep.Click += new System.EventHandler(this.ThreadSleep_Click);
            // 
            // TaskDelay
            // 
            this.TaskDelay.Location = new System.Drawing.Point(195, 148);
            this.TaskDelay.Name = "TaskDelay";
            this.TaskDelay.Size = new System.Drawing.Size(279, 45);
            this.TaskDelay.TabIndex = 1;
            this.TaskDelay.Text = "Task Delay";
            this.TaskDelay.UseVisualStyleBackColor = true;
            this.TaskDelay.Click += new System.EventHandler(this.TaskDelay_Click);
            // 
            // CancelTaskDelay
            // 
            this.CancelTaskDelay.Location = new System.Drawing.Point(195, 218);
            this.CancelTaskDelay.Name = "CancelTaskDelay";
            this.CancelTaskDelay.Size = new System.Drawing.Size(279, 51);
            this.CancelTaskDelay.TabIndex = 2;
            this.CancelTaskDelay.Text = " Cancel Task Delay";
            this.CancelTaskDelay.UseVisualStyleBackColor = true;
            this.CancelTaskDelay.Click += new System.EventHandler(this.CancelTaskDelay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 386);
            this.Controls.Add(this.CancelTaskDelay);
            this.Controls.Add(this.TaskDelay);
            this.Controls.Add(this.ThreadSleep);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ThreadSleep;
        private System.Windows.Forms.Button TaskDelay;
        private System.Windows.Forms.Button CancelTaskDelay;
    }
}

