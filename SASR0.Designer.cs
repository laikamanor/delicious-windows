namespace DeliciousPartnerApp
{
    partial class SASR0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SASR0));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpBranch = new System.Windows.Forms.TabPage();
            this.panelBranch = new System.Windows.Forms.Panel();
            this.tpCustomer = new System.Windows.Forms.TabPage();
            this.panelCustomer = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpBranch.SuspendLayout();
            this.tpCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpBranch);
            this.tabControl1.Controls.Add(this.tpCustomer);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 521);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpBranch
            // 
            this.tpBranch.Controls.Add(this.panelBranch);
            this.tpBranch.Location = new System.Drawing.Point(4, 22);
            this.tpBranch.Name = "tpBranch";
            this.tpBranch.Padding = new System.Windows.Forms.Padding(3);
            this.tpBranch.Size = new System.Drawing.Size(779, 495);
            this.tpBranch.TabIndex = 0;
            this.tpBranch.Text = "Branch";
            this.tpBranch.UseVisualStyleBackColor = true;
            // 
            // panelBranch
            // 
            this.panelBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBranch.Location = new System.Drawing.Point(3, 3);
            this.panelBranch.Name = "panelBranch";
            this.panelBranch.Size = new System.Drawing.Size(773, 489);
            this.panelBranch.TabIndex = 0;
            // 
            // tpCustomer
            // 
            this.tpCustomer.Controls.Add(this.panelCustomer);
            this.tpCustomer.Location = new System.Drawing.Point(4, 22);
            this.tpCustomer.Name = "tpCustomer";
            this.tpCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomer.Size = new System.Drawing.Size(779, 495);
            this.tpCustomer.TabIndex = 1;
            this.tpCustomer.Text = "Customer";
            this.tpCustomer.UseVisualStyleBackColor = true;
            // 
            // panelCustomer
            // 
            this.panelCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomer.Location = new System.Drawing.Point(3, 3);
            this.panelCustomer.Name = "panelCustomer";
            this.panelCustomer.Size = new System.Drawing.Size(773, 489);
            this.panelCustomer.TabIndex = 1;
            // 
            // SASR0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 536);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SASR0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Amount Summary Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SASR0_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpBranch.ResumeLayout(false);
            this.tpCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpBranch;
        private System.Windows.Forms.TabPage tpCustomer;
        private System.Windows.Forms.Panel panelBranch;
        private System.Windows.Forms.Panel panelCustomer;
    }
}