namespace DeliciousPartnerApp
{
    partial class SOATab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOATab));
            this.tcSOA = new System.Windows.Forms.TabControl();
            this.tabForSOA = new System.Windows.Forms.TabPage();
            this.panelForSOA = new System.Windows.Forms.Panel();
            this.tabSOA = new System.Windows.Forms.TabPage();
            this.panelSOA = new System.Windows.Forms.Panel();
            this.tabClosedSOA = new System.Windows.Forms.TabPage();
            this.panelClosedSOA = new System.Windows.Forms.Panel();
            this.tcSOA.SuspendLayout();
            this.tabForSOA.SuspendLayout();
            this.tabSOA.SuspendLayout();
            this.tabClosedSOA.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSOA
            // 
            this.tcSOA.Controls.Add(this.tabForSOA);
            this.tcSOA.Controls.Add(this.tabSOA);
            this.tcSOA.Controls.Add(this.tabClosedSOA);
            this.tcSOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSOA.Location = new System.Drawing.Point(0, 0);
            this.tcSOA.Name = "tcSOA";
            this.tcSOA.SelectedIndex = 0;
            this.tcSOA.Size = new System.Drawing.Size(633, 446);
            this.tcSOA.TabIndex = 2;
            this.tcSOA.SelectedIndexChanged += new System.EventHandler(this.tcSOA_SelectedIndexChanged);
            // 
            // tabForSOA
            // 
            this.tabForSOA.Controls.Add(this.panelForSOA);
            this.tabForSOA.Location = new System.Drawing.Point(4, 22);
            this.tabForSOA.Name = "tabForSOA";
            this.tabForSOA.Padding = new System.Windows.Forms.Padding(3);
            this.tabForSOA.Size = new System.Drawing.Size(625, 420);
            this.tabForSOA.TabIndex = 0;
            this.tabForSOA.Text = "For SOA";
            this.tabForSOA.UseVisualStyleBackColor = true;
            // 
            // panelForSOA
            // 
            this.panelForSOA.AutoScroll = true;
            this.panelForSOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForSOA.Location = new System.Drawing.Point(3, 3);
            this.panelForSOA.Name = "panelForSOA";
            this.panelForSOA.Size = new System.Drawing.Size(619, 414);
            this.panelForSOA.TabIndex = 1;
            // 
            // tabSOA
            // 
            this.tabSOA.Controls.Add(this.panelSOA);
            this.tabSOA.Location = new System.Drawing.Point(4, 22);
            this.tabSOA.Name = "tabSOA";
            this.tabSOA.Padding = new System.Windows.Forms.Padding(3);
            this.tabSOA.Size = new System.Drawing.Size(625, 420);
            this.tabSOA.TabIndex = 1;
            this.tabSOA.Text = "Open SOA";
            this.tabSOA.UseVisualStyleBackColor = true;
            // 
            // panelSOA
            // 
            this.panelSOA.AutoScroll = true;
            this.panelSOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSOA.Location = new System.Drawing.Point(3, 3);
            this.panelSOA.Name = "panelSOA";
            this.panelSOA.Size = new System.Drawing.Size(619, 414);
            this.panelSOA.TabIndex = 2;
            // 
            // tabClosedSOA
            // 
            this.tabClosedSOA.Controls.Add(this.panelClosedSOA);
            this.tabClosedSOA.Location = new System.Drawing.Point(4, 22);
            this.tabClosedSOA.Name = "tabClosedSOA";
            this.tabClosedSOA.Size = new System.Drawing.Size(625, 420);
            this.tabClosedSOA.TabIndex = 2;
            this.tabClosedSOA.Text = "Closed SOA";
            this.tabClosedSOA.UseVisualStyleBackColor = true;
            // 
            // panelClosedSOA
            // 
            this.panelClosedSOA.AutoScroll = true;
            this.panelClosedSOA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClosedSOA.Location = new System.Drawing.Point(0, 0);
            this.panelClosedSOA.Name = "panelClosedSOA";
            this.panelClosedSOA.Size = new System.Drawing.Size(625, 420);
            this.panelClosedSOA.TabIndex = 3;
            // 
            // SOATab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 446);
            this.Controls.Add(this.tcSOA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SOATab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SOA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SOATab_Load);
            this.tcSOA.ResumeLayout(false);
            this.tabForSOA.ResumeLayout(false);
            this.tabSOA.ResumeLayout(false);
            this.tabClosedSOA.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcSOA;
        private System.Windows.Forms.TabPage tabForSOA;
        private System.Windows.Forms.Panel panelForSOA;
        private System.Windows.Forms.TabPage tabSOA;
        private System.Windows.Forms.Panel panelSOA;
        private System.Windows.Forms.TabPage tabClosedSOA;
        private System.Windows.Forms.Panel panelClosedSOA;
    }
}