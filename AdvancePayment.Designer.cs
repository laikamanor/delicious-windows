namespace DeliciousPartnerApp
{
    partial class AdvancePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancePayment));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpInDeposit = new System.Windows.Forms.TabPage();
            this.panelInDeposit = new System.Windows.Forms.Panel();
            this.tpUsedDeposit = new System.Windows.Forms.TabPage();
            this.panelUsedDeposit = new System.Windows.Forms.Panel();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.panelSummaryDeposit = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpInDeposit.SuspendLayout();
            this.tpUsedDeposit.SuspendLayout();
            this.tpSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpInDeposit);
            this.tabControl1.Controls.Add(this.tpUsedDeposit);
            this.tabControl1.Controls.Add(this.tpSummary);
            this.tabControl1.Location = new System.Drawing.Point(4, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 426);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpInDeposit
            // 
            this.tpInDeposit.Controls.Add(this.panelInDeposit);
            this.tpInDeposit.Location = new System.Drawing.Point(4, 22);
            this.tpInDeposit.Name = "tpInDeposit";
            this.tpInDeposit.Padding = new System.Windows.Forms.Padding(3);
            this.tpInDeposit.Size = new System.Drawing.Size(786, 400);
            this.tpInDeposit.TabIndex = 0;
            this.tpInDeposit.Text = "In Deposit";
            this.tpInDeposit.UseVisualStyleBackColor = true;
            // 
            // panelInDeposit
            // 
            this.panelInDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInDeposit.AutoScroll = true;
            this.panelInDeposit.Location = new System.Drawing.Point(6, 6);
            this.panelInDeposit.Name = "panelInDeposit";
            this.panelInDeposit.Size = new System.Drawing.Size(774, 388);
            this.panelInDeposit.TabIndex = 0;
            // 
            // tpUsedDeposit
            // 
            this.tpUsedDeposit.Controls.Add(this.panelUsedDeposit);
            this.tpUsedDeposit.Location = new System.Drawing.Point(4, 22);
            this.tpUsedDeposit.Name = "tpUsedDeposit";
            this.tpUsedDeposit.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsedDeposit.Size = new System.Drawing.Size(786, 400);
            this.tpUsedDeposit.TabIndex = 1;
            this.tpUsedDeposit.Text = "Used Deposit";
            this.tpUsedDeposit.UseVisualStyleBackColor = true;
            // 
            // panelUsedDeposit
            // 
            this.panelUsedDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUsedDeposit.AutoScroll = true;
            this.panelUsedDeposit.Location = new System.Drawing.Point(6, 6);
            this.panelUsedDeposit.Name = "panelUsedDeposit";
            this.panelUsedDeposit.Size = new System.Drawing.Size(774, 388);
            this.panelUsedDeposit.TabIndex = 1;
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.panelSummaryDeposit);
            this.tpSummary.Location = new System.Drawing.Point(4, 22);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Size = new System.Drawing.Size(786, 400);
            this.tpSummary.TabIndex = 2;
            this.tpSummary.Text = "Summary Deposit";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // panelSummaryDeposit
            // 
            this.panelSummaryDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSummaryDeposit.AutoScroll = true;
            this.panelSummaryDeposit.Location = new System.Drawing.Point(6, 6);
            this.panelSummaryDeposit.Name = "panelSummaryDeposit";
            this.panelSummaryDeposit.Size = new System.Drawing.Size(774, 388);
            this.panelSummaryDeposit.TabIndex = 2;
            // 
            // AdvancePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvancePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deposit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdvancePayment_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpInDeposit.ResumeLayout(false);
            this.tpUsedDeposit.ResumeLayout(false);
            this.tpSummary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpInDeposit;
        private System.Windows.Forms.TabPage tpUsedDeposit;
        private System.Windows.Forms.Panel panelInDeposit;
        private System.Windows.Forms.Panel panelUsedDeposit;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.Panel panelSummaryDeposit;
    }
}