namespace DeliciousPartnerApp
{
    partial class CashVariance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashVariance));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpForSAP = new System.Windows.Forms.TabPage();
            this.panelForSAP = new System.Windows.Forms.Panel();
            this.tpDone = new System.Windows.Forms.TabPage();
            this.panelDone = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tpForSAP.SuspendLayout();
            this.tpDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpForSAP);
            this.tabControl1.Controls.Add(this.tpDone);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 502);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpForSAP
            // 
            this.tpForSAP.Controls.Add(this.panelForSAP);
            this.tpForSAP.Location = new System.Drawing.Point(4, 22);
            this.tpForSAP.Name = "tpForSAP";
            this.tpForSAP.Padding = new System.Windows.Forms.Padding(3);
            this.tpForSAP.Size = new System.Drawing.Size(816, 476);
            this.tpForSAP.TabIndex = 0;
            this.tpForSAP.Text = "For SAP";
            this.tpForSAP.UseVisualStyleBackColor = true;
            // 
            // panelForSAP
            // 
            this.panelForSAP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForSAP.Location = new System.Drawing.Point(6, 6);
            this.panelForSAP.Name = "panelForSAP";
            this.panelForSAP.Size = new System.Drawing.Size(804, 464);
            this.panelForSAP.TabIndex = 0;
            // 
            // tpDone
            // 
            this.tpDone.Controls.Add(this.panelDone);
            this.tpDone.Location = new System.Drawing.Point(4, 22);
            this.tpDone.Name = "tpDone";
            this.tpDone.Padding = new System.Windows.Forms.Padding(3);
            this.tpDone.Size = new System.Drawing.Size(816, 476);
            this.tpDone.TabIndex = 1;
            this.tpDone.Text = "Done";
            this.tpDone.UseVisualStyleBackColor = true;
            // 
            // panelDone
            // 
            this.panelDone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDone.Location = new System.Drawing.Point(6, 6);
            this.panelDone.Name = "panelDone";
            this.panelDone.Size = new System.Drawing.Size(804, 464);
            this.panelDone.TabIndex = 1;
            // 
            // CashVariance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 526);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashVariance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Variance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CashVariance_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpForSAP.ResumeLayout(false);
            this.tpDone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpForSAP;
        private System.Windows.Forms.TabPage tpDone;
        private System.Windows.Forms.Panel panelForSAP;
        private System.Windows.Forms.Panel panelDone;
    }
}