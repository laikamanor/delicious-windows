namespace DeliciousPartnerApp
{
    partial class POS_ItemInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS_ItemInfo));
            this.lblItem = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblDisplayDiscount = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.btnAddCart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.DimGray;
            this.lblItem.Location = new System.Drawing.Point(20, 40);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(354, 70);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "BIGDESAL";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrice.Location = new System.Drawing.Point(20, 118);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(354, 24);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "₱ 0.00";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(99, 161);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(126, 26);
            this.txtQuantity.TabIndex = 0;
            this.txtQuantity.Text = "0.00";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblDisplayDiscount
            // 
            this.lblDisplayDiscount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDisplayDiscount.AutoSize = true;
            this.lblDisplayDiscount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayDiscount.ForeColor = System.Drawing.Color.DimGray;
            this.lblDisplayDiscount.Location = new System.Drawing.Point(347, 214);
            this.lblDisplayDiscount.Name = "lblDisplayDiscount";
            this.lblDisplayDiscount.Size = new System.Drawing.Size(27, 22);
            this.lblDisplayDiscount.TabIndex = 3;
            this.lblDisplayDiscount.Text = "%";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(24, 260);
            this.txtTotalPrice.Multiline = true;
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTotalPrice.Size = new System.Drawing.Size(350, 39);
            this.txtTotalPrice.TabIndex = 2;
            this.txtTotalPrice.Text = "0.00";
            // 
            // btnAddCart
            // 
            this.btnAddCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCart.FlatAppearance.BorderSize = 0;
            this.btnAddCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCart.ForeColor = System.Drawing.Color.White;
            this.btnAddCart.Location = new System.Drawing.Point(24, 318);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(350, 43);
            this.btnAddCart.TabIndex = 3;
            this.btnAddCart.Text = "ADD TO CART";
            this.btnAddCart.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(24, 205);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(317, 39);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0.00";
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMinus.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinus.FlatAppearance.BorderSize = 0;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.ForeColor = System.Drawing.Color.White;
            this.btnMinus.Location = new System.Drawing.Point(24, 161);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(75, 26);
            this.btnMinus.TabIndex = 20;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPlus.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.White;
            this.btnPlus.Location = new System.Drawing.Point(224, 161);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(75, 26);
            this.btnPlus.TabIndex = 21;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // POS_ItemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 414);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAddCart);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblDisplayDiscount);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POS_ItemInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.POS_ItemInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblDisplayDiscount;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Button btnAddCart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
    }
}