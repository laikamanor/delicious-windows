namespace DeliciousPartnerApp
{
    partial class PriceList_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceList_Items));
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.lblPriceList = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblCurrentPrice.Location = new System.Drawing.Point(25, 101);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(96, 16);
            this.lblCurrentPrice.TabIndex = 26;
            this.lblCurrentPrice.Text = "Current Price:";
            // 
            // lblPriceList
            // 
            this.lblPriceList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPriceList.AutoSize = true;
            this.lblPriceList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceList.ForeColor = System.Drawing.Color.Gray;
            this.lblPriceList.Location = new System.Drawing.Point(25, 33);
            this.lblPriceList.Name = "lblPriceList";
            this.lblPriceList.Size = new System.Drawing.Size(71, 16);
            this.lblPriceList.TabIndex = 25;
            this.lblPriceList.Text = "Price List ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(28, 203);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(315, 41);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "*New Price:";
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNewPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPrice.Location = new System.Drawing.Point(28, 156);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.Size = new System.Drawing.Size(315, 26);
            this.txtNewPrice.TabIndex = 0;
            this.txtNewPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPrice_KeyPress);
            // 
            // lblItemCode
            // 
            this.lblItemCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.ForeColor = System.Drawing.Color.Gray;
            this.lblItemCode.Location = new System.Drawing.Point(25, 67);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(77, 16);
            this.lblItemCode.TabIndex = 22;
            this.lblItemCode.Text = "Item Code:";
            // 
            // PriceList_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 277);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.lblPriceList);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPrice);
            this.Controls.Add(this.lblItemCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "PriceList_Items";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price List Items";
            this.Load += new System.EventHandler(this.PriceList_Items_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.Label lblItemCode;
        public System.Windows.Forms.Label lblPriceList;
    }
}