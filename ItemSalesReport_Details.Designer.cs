namespace DeliciousPartnerApp
{
    partial class ItemSalesReport_Details
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSalesReport_Details));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discprcnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processed_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reference,
            this.item_code,
            this.quantity,
            this.unit_price,
            this.discprcnt,
            this.disc_amount,
            this.gross_amount,
            this.net_amount,
            this.processed_by});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(21, 32);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(804, 483);
            this.dgv.TabIndex = 61;
            // 
            // reference
            // 
            this.reference.HeaderText = "Reference #";
            this.reference.MinimumWidth = 200;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // item_code
            // 
            this.item_code.HeaderText = "Item Code";
            this.item_code.MinimumWidth = 200;
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 100;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // unit_price
            // 
            this.unit_price.HeaderText = "Unit Price";
            this.unit_price.MinimumWidth = 100;
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // discprcnt
            // 
            this.discprcnt.HeaderText = "Disc. %";
            this.discprcnt.MinimumWidth = 100;
            this.discprcnt.Name = "discprcnt";
            this.discprcnt.ReadOnly = true;
            // 
            // disc_amount
            // 
            this.disc_amount.HeaderText = "Disc. Amt.";
            this.disc_amount.MinimumWidth = 100;
            this.disc_amount.Name = "disc_amount";
            this.disc_amount.ReadOnly = true;
            // 
            // gross_amount
            // 
            this.gross_amount.HeaderText = "Gross Amt.";
            this.gross_amount.MinimumWidth = 100;
            this.gross_amount.Name = "gross_amount";
            this.gross_amount.ReadOnly = true;
            // 
            // net_amount
            // 
            this.net_amount.HeaderText = "Net Amt.";
            this.net_amount.MinimumWidth = 100;
            this.net_amount.Name = "net_amount";
            this.net_amount.ReadOnly = true;
            // 
            // processed_by
            // 
            this.processed_by.HeaderText = "Proccessed By";
            this.processed_by.MinimumWidth = 150;
            this.processed_by.Name = "processed_by";
            this.processed_by.ReadOnly = true;
            // 
            // ItemSalesReport_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 527);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ItemSalesReport_Details";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Sales Detailed Report Details";
            this.Load += new System.EventHandler(this.ItemSalesReport_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn discprcnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn net_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn processed_by;
    }
}