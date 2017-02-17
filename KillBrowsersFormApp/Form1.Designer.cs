namespace KillBrowsersFormApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.ShowLogButton = new System.Windows.Forms.Button();
            this.KillButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.bkIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // ShowLogButton
            // 
            this.ShowLogButton.Location = new System.Drawing.Point(93, 12);
            this.ShowLogButton.Name = "ShowLogButton";
            this.ShowLogButton.Size = new System.Drawing.Size(75, 23);
            this.ShowLogButton.TabIndex = 0;
            this.ShowLogButton.Text = "Show Logs";
            this.ShowLogButton.UseVisualStyleBackColor = true;
            // 
            // KillButton
            // 
            this.KillButton.Location = new System.Drawing.Point(12, 12);
            this.KillButton.Name = "KillButton";
            this.KillButton.Size = new System.Drawing.Size(75, 23);
            this.KillButton.TabIndex = 1;
            this.KillButton.Text = "Kill Browsers";
            this.KillButton.UseVisualStyleBackColor = true;
            this.KillButton.Click += new System.EventHandler(this.KillButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(174, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            // 
            // bkIcon
            // 
            this.bkIcon.Text = "Browser Killer";
            this.bkIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 44);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.KillButton);
            this.Controls.Add(this.ShowLogButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Browser Killer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DoubleClick += new System.EventHandler(this.bkIcon_DoubleClick);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowLogButton;
        private System.Windows.Forms.Button KillButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.NotifyIcon bkIcon;
    }
}

