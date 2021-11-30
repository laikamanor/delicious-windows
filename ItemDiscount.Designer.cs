namespace DeliciousPartnerApp
{
    partial class ItemDiscount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDiscount));
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discprcnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linetotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processed_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.ForestGreen;
            this.panel11.Controls.Add(this.lblItemsCount);
            this.panel11.Location = new System.Drawing.Point(12, 45);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1014, 29);
            this.panel11.TabIndex = 57;
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsCount.ForeColor = System.Drawing.Color.White;
            this.lblItemsCount.Location = new System.Drawing.Point(3, 7);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(57, 15);
            this.lblItemsCount.TabIndex = 15;
            this.lblItemsCount.Text = "Count (0)";
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.AllowUserToDeleteRows = false;
            this.dgvitems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvitems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvitems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvitems.BackgroundColor = System.Drawing.Color.White;
            this.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvitems.ColumnHeadersHeight = 40;
            this.dgvitems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reference,
            this.item_code,
            this.unit_price,
            this.discprcnt,
            this.quantity,
            this.disc_amount,
            this.gross,
            this.linetotal,
            this.processed_by});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvitems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvitems.EnableHeadersVisualStyles = false;
            this.dgvitems.GridColor = System.Drawing.Color.Gray;
            this.dgvitems.Location = new System.Drawing.Point(12, 73);
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.RowHeadersWidth = 10;
            this.dgvitems.Size = new System.Drawing.Size(1014, 349);
            this.dgvitems.TabIndex = 56;
            // 
            // reference
            // 
            this.reference.HeaderText = "Reference";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // item_code
            // 
            this.item_code.HeaderText = "Item Code";
            this.item_code.MinimumWidth = 150;
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            // 
            // unit_price
            // 
            this.unit_price.HeaderText = "Unit Price";
            this.unit_price.MinimumWidth = 70;
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // discprcnt
            // 
            this.discprcnt.HeaderText = "Disc. Percent";
            this.discprcnt.MinimumWidth = 70;
            this.discprcnt.Name = "discprcnt";
            this.discprcnt.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 70;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // disc_amount
            // 
            this.disc_amount.HeaderText = "Disc. Amount";
            this.disc_amount.MinimumWidth = 70;
            this.disc_amount.Name = "disc_amount";
            this.disc_amount.ReadOnly = true;
            // 
            // gross
            // 
            this.gross.HeaderText = "Gross";
            this.gross.MinimumWidth = 70;
            this.gross.Name = "gross";
            this.gross.ReadOnly = true;
            // 
            // linetotal
            // 
            this.linetotal.HeaderText = "Line Total";
            this.linetotal.MinimumWidth = 70;
            this.linetotal.Name = "linetotal";
            this.linetotal.ReadOnly = true;
            // 
            // processed_by
            // 
            this.processed_by.HeaderText = "Processed By";
            this.processed_by.MinimumWidth = 100;
            this.processed_by.Name = "processed_by";
            this.processed_by.ReadOnly = true;
            // 
            // ItemDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 434);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.dgvitems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemDiscount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.ItemDiscount_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        internal System.Windows.Forms.Label lblItemsCount;
        internal System.Windows.Forms.DataGridView dgvitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn discprcnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn linetotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn processed_by;
    }
}