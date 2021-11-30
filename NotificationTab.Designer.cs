namespace DeliciousPartnerApp
{
    partial class NotificationTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationTab));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tcPending = new System.Windows.Forms.TabPage();
            this.panelPending = new System.Windows.Forms.Panel();
            this.tcDone = new System.Windows.Forms.TabPage();
            this.panelDone = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tcPending.SuspendLayout();
            this.tcDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tcPending);
            this.tabControl1.Controls.Add(this.tcDone);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(744, 483);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tcPending
            // 
            this.tcPending.Controls.Add(this.panelPending);
            this.tcPending.Location = new System.Drawing.Point(4, 22);
            this.tcPending.Name = "tcPending";
            this.tcPending.Padding = new System.Windows.Forms.Padding(3);
            this.tcPending.Size = new System.Drawing.Size(736, 457);
            this.tcPending.TabIndex = 0;
            this.tcPending.Text = "Pending Notification(s)";
            this.tcPending.UseVisualStyleBackColor = true;
            // 
            // panelPending
            // 
            this.panelPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPending.Location = new System.Drawing.Point(6, 6);
            this.panelPending.Name = "panelPending";
            this.panelPending.Size = new System.Drawing.Size(727, 448);
            this.panelPending.TabIndex = 0;
            // 
            // tcDone
            // 
            this.tcDone.Controls.Add(this.panelDone);
            this.tcDone.Location = new System.Drawing.Point(4, 22);
            this.tcDone.Name = "tcDone";
            this.tcDone.Padding = new System.Windows.Forms.Padding(3);
            this.tcDone.Size = new System.Drawing.Size(736, 457);
            this.tcDone.TabIndex = 1;
            this.tcDone.Text = "Done Notification(s)";
            this.tcDone.UseVisualStyleBackColor = true;
            // 
            // panelDone
            // 
            this.panelDone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDone.Location = new System.Drawing.Point(5, 4);
            this.panelDone.Name = "panelDone";
            this.panelDone.Size = new System.Drawing.Size(727, 448);
            this.panelDone.TabIndex = 1;
            // 
            // NotificationTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 507);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NotificationTab_Load);
            this.tabControl1.ResumeLayout(false);
            this.tcPending.ResumeLayout(false);
            this.tcDone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tcPending;
        private System.Windows.Forms.TabPage tcDone;
        private System.Windows.Forms.Panel panelPending;
        private System.Windows.Forms.Panel panelDone;
    }
}