namespace DeliciousPartnerApp
{
    partial class Production
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production));
            this.tcProd = new System.Windows.Forms.TabControl();
            this.tpForProductionOrder = new System.Windows.Forms.TabPage();
            this.panelForProdOrder = new System.Windows.Forms.Panel();
            this.tpIssueProduction = new System.Windows.Forms.TabPage();
            this.panelIssueProd = new System.Windows.Forms.Panel();
            this.tpReceivedProduction = new System.Windows.Forms.TabPage();
            this.panelReceivedProd = new System.Windows.Forms.Panel();
            this.tcProd.SuspendLayout();
            this.tpForProductionOrder.SuspendLayout();
            this.tpIssueProduction.SuspendLayout();
            this.tpReceivedProduction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcProd
            // 
            this.tcProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcProd.Controls.Add(this.tpForProductionOrder);
            this.tcProd.Controls.Add(this.tpIssueProduction);
            this.tcProd.Controls.Add(this.tpReceivedProduction);
            this.tcProd.Location = new System.Drawing.Point(12, 12);
            this.tcProd.Name = "tcProd";
            this.tcProd.SelectedIndex = 0;
            this.tcProd.Size = new System.Drawing.Size(787, 483);
            this.tcProd.TabIndex = 1;
            this.tcProd.SelectedIndexChanged += new System.EventHandler(this.tcProd_SelectedIndexChanged);
            // 
            // tpForProductionOrder
            // 
            this.tpForProductionOrder.Controls.Add(this.panelForProdOrder);
            this.tpForProductionOrder.Location = new System.Drawing.Point(4, 22);
            this.tpForProductionOrder.Name = "tpForProductionOrder";
            this.tpForProductionOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tpForProductionOrder.Size = new System.Drawing.Size(779, 457);
            this.tpForProductionOrder.TabIndex = 0;
            this.tpForProductionOrder.Text = "Production Order";
            this.tpForProductionOrder.UseVisualStyleBackColor = true;
            // 
            // panelForProdOrder
            // 
            this.panelForProdOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForProdOrder.AutoScroll = true;
            this.panelForProdOrder.Location = new System.Drawing.Point(6, 6);
            this.panelForProdOrder.Name = "panelForProdOrder";
            this.panelForProdOrder.Size = new System.Drawing.Size(767, 445);
            this.panelForProdOrder.TabIndex = 0;
            // 
            // tpIssueProduction
            // 
            this.tpIssueProduction.Controls.Add(this.panelIssueProd);
            this.tpIssueProduction.Location = new System.Drawing.Point(4, 22);
            this.tpIssueProduction.Name = "tpIssueProduction";
            this.tpIssueProduction.Padding = new System.Windows.Forms.Padding(3);
            this.tpIssueProduction.Size = new System.Drawing.Size(779, 457);
            this.tpIssueProduction.TabIndex = 2;
            this.tpIssueProduction.Text = "Issue For Production";
            this.tpIssueProduction.UseVisualStyleBackColor = true;
            // 
            // panelIssueProd
            // 
            this.panelIssueProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelIssueProd.AutoScroll = true;
            this.panelIssueProd.Location = new System.Drawing.Point(6, 6);
            this.panelIssueProd.Name = "panelIssueProd";
            this.panelIssueProd.Size = new System.Drawing.Size(767, 445);
            this.panelIssueProd.TabIndex = 0;
            // 
            // tpReceivedProduction
            // 
            this.tpReceivedProduction.Controls.Add(this.panelReceivedProd);
            this.tpReceivedProduction.Location = new System.Drawing.Point(4, 22);
            this.tpReceivedProduction.Name = "tpReceivedProduction";
            this.tpReceivedProduction.Size = new System.Drawing.Size(779, 457);
            this.tpReceivedProduction.TabIndex = 3;
            this.tpReceivedProduction.Text = "Receipt from Production";
            this.tpReceivedProduction.UseVisualStyleBackColor = true;
            // 
            // panelReceivedProd
            // 
            this.panelReceivedProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReceivedProd.AutoScroll = true;
            this.panelReceivedProd.Location = new System.Drawing.Point(6, 6);
            this.panelReceivedProd.Name = "panelReceivedProd";
            this.panelReceivedProd.Size = new System.Drawing.Size(767, 445);
            this.panelReceivedProd.TabIndex = 1;
            // 
            // Production
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 494);
            this.Controls.Add(this.tcProd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Production";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Production_Load);
            this.tcProd.ResumeLayout(false);
            this.tpForProductionOrder.ResumeLayout(false);
            this.tpIssueProduction.ResumeLayout(false);
            this.tpReceivedProduction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcProd;
        private System.Windows.Forms.TabPage tpForProductionOrder;
        private System.Windows.Forms.Panel panelForProdOrder;
        private System.Windows.Forms.TabPage tpIssueProduction;
        private System.Windows.Forms.Panel panelIssueProd;
        private System.Windows.Forms.TabPage tpReceivedProduction;
        private System.Windows.Forms.Panel panelReceivedProd;
    }
}