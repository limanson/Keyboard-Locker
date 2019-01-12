namespace Keyboard_Locker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainButton = new System.Windows.Forms.Button();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.LicenseLabel = new System.Windows.Forms.Label();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TipLabel = new System.Windows.Forms.Label();
            this.ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainButton
            // 
            this.MainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainButton.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainButton.Location = new System.Drawing.Point(70, 20);
            this.MainButton.Name = "MainButton";
            this.MainButton.Size = new System.Drawing.Size(250, 100);
            this.MainButton.TabIndex = 0;
            this.MainButton.Text = "Lock";
            this.MainButton.UseVisualStyleBackColor = true;
            this.MainButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainButton_Click);
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WarningLabel.Location = new System.Drawing.Point(40, 164);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(320, 18);
            this.WarningLabel.TabIndex = 1;
            this.WarningLabel.Text = "※ (Ctrl + Alt + Delete) Still working.";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LicenseLabel
            // 
            this.LicenseLabel.AutoSize = true;
            this.LicenseLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LicenseLabel.Location = new System.Drawing.Point(106, 192);
            this.LicenseLabel.Name = "LicenseLabel";
            this.LicenseLabel.Size = new System.Drawing.Size(168, 14);
            this.LicenseLabel.TabIndex = 2;
            this.LicenseLabel.Text = "Create by Villan © 2019";
            this.LicenseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.ContextMenuStrip = this.ContextMenuStrip1;
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Text = "Keyboard Locker";
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenWindowToolStripMenuItem,
            this.LockToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(151, 70);
            this.ContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // OpenWindowToolStripMenuItem
            // 
            this.OpenWindowToolStripMenuItem.Name = "OpenWindowToolStripMenuItem";
            this.OpenWindowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.OpenWindowToolStripMenuItem.Text = "Open Window";
            this.OpenWindowToolStripMenuItem.Click += new System.EventHandler(this.OpenWindowToolStripMenuItem_Click);
            // 
            // LockToolStripMenuItem
            // 
            this.LockToolStripMenuItem.Name = "LockToolStripMenuItem";
            this.LockToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.LockToolStripMenuItem.Text = "Lock";
            this.LockToolStripMenuItem.Click += new System.EventHandler(this.LockToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // TipLabel
            // 
            this.TipLabel.AutoSize = true;
            this.TipLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TipLabel.Location = new System.Drawing.Point(22, 135);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(344, 18);
            this.TipLabel.TabIndex = 3;
            this.TipLabel.Text = "Quickly triple press \"Ctrl\" to lock/unlock";
            this.TipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(384, 215);
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.LicenseLabel);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.MainButton);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Locker";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button MainButton;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Label LicenseLabel;
        private System.Windows.Forms.NotifyIcon NotifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem OpenWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        private System.Windows.Forms.Label TipLabel;
    }
}

