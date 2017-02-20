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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ShowLogButton = new System.Windows.Forms.Button();
            this.KillButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.bkIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.KillCountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ShowLogButton
            // 
            this.ShowLogButton.Location = new System.Drawing.Point(124, 33);
            this.ShowLogButton.Margin = new System.Windows.Forms.Padding(4);
            this.ShowLogButton.Name = "ShowLogButton";
            this.ShowLogButton.Size = new System.Drawing.Size(100, 28);
            this.ShowLogButton.TabIndex = 0;
            this.ShowLogButton.Text = "Show Logs";
            this.ShowLogButton.UseVisualStyleBackColor = true;
            this.ShowLogButton.Click += new System.EventHandler(this.ShowLogButton_Click);
            // 
            // KillButton
            // 
            this.KillButton.Location = new System.Drawing.Point(16, 33);
            this.KillButton.Margin = new System.Windows.Forms.Padding(4);
            this.KillButton.Name = "KillButton";
            this.KillButton.Size = new System.Drawing.Size(100, 28);
            this.KillButton.TabIndex = 1;
            this.KillButton.Text = "Kill Browsers";
            this.KillButton.UseVisualStyleBackColor = true;
            this.KillButton.Click += new System.EventHandler(this.KillButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(232, 33);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(100, 28);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // bkIcon
            // 
            this.bkIcon.BalloonTipText = "Browser Killer minimizes to the system tray.";
            this.bkIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("bkIcon.Icon")));
            this.bkIcon.Text = "Browser Killer";
            this.bkIcon.Visible = true;
            this.bkIcon.DoubleClick += new System.EventHandler(this.bkIcon_DoubleClick);
            // 
            // KillCountTextBox
            // 
            this.KillCountTextBox.Location = new System.Drawing.Point(148, 4);
            this.KillCountTextBox.Name = "KillCountTextBox";
            this.KillCountTextBox.ReadOnly = true;
            this.KillCountTextBox.Size = new System.Drawing.Size(184, 22);
            this.KillCountTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Browser Kill Count:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 70);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KillCountTextBox);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.KillButton);
            this.Controls.Add(this.ShowLogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Browser Killer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.DoubleClick += new System.EventHandler(this.bkIcon_DoubleClick);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowLogButton;
        private System.Windows.Forms.Button KillButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.NotifyIcon bkIcon;
        private System.Windows.Forms.TextBox KillCountTextBox;
        private System.Windows.Forms.Label label1;
    }
}

