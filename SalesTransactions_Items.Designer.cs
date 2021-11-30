namespace DeliciousPartnerApp
{
    partial class SalesTransactions_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesTransactions_Items));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAppliedAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTenderAmount = new System.Windows.Forms.Label();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.lblGross = new System.Windows.Forms.Label();
            this.lblDiscAmount = new System.Windows.Forms.Label();
            this.lblDocTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.lblTransdate = new System.Windows.Forms.Label();
            this.lblSAP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_code,
            this.quantity,
            this.unit_price,
            this.gross,
            this.disc_amount,
            this.disc_percent,
            this.line_total});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(12, 92);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(660, 181);
            this.dgv.TabIndex = 36;
            // 
            // item_code
            // 
            this.item_code.HeaderText = "Item";
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Qty.";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // unit_price
            // 
            this.unit_price.HeaderText = "Unit Price";
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // gross
            // 
            this.gross.HeaderText = "Gross";
            this.gross.Name = "gross";
            this.gross.ReadOnly = true;
            // 
            // disc_amount
            // 
            this.disc_amount.HeaderText = "Disc. Amount";
            this.disc_amount.Name = "disc_amount";
            this.disc_amount.ReadOnly = true;
            // 
            // disc_percent
            // 
            this.disc_percent.HeaderText = "Disc. Percent";
            this.disc_percent.Name = "disc_percent";
            this.disc_percent.ReadOnly = true;
            // 
            // line_total
            // 
            this.line_total.HeaderText = "Line Total";
            this.line_total.Name = "line_total";
            this.line_total.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblAppliedAmount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTenderAmount);
            this.panel1.Controls.Add(this.lblAmountDue);
            this.panel1.Controls.Add(this.lblGross);
            this.panel1.Controls.Add(this.lblDiscAmount);
            this.panel1.Controls.Add(this.lblDocTotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Label11);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.Label9);
            this.panel1.Location = new System.Drawing.Point(12, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 180);
            this.panel1.TabIndex = 37;
            // 
            // lblAppliedAmount
            // 
            this.lblAppliedAmount.AutoSize = true;
            this.lblAppliedAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppliedAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAppliedAmount.Location = new System.Drawing.Point(177, 89);
            this.lblAppliedAmount.Name = "lblAppliedAmount";
            this.lblAppliedAmount.Size = new System.Drawing.Size(33, 16);
            this.lblAppliedAmount.TabIndex = 75;
            this.lblAppliedAmount.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 74;
            this.label3.Text = "Applied Amount:";
            // 
            // lblTenderAmount
            // 
            this.lblTenderAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenderAmount.AutoSize = true;
            this.lblTenderAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenderAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTenderAmount.Location = new System.Drawing.Point(177, 117);
            this.lblTenderAmount.Name = "lblTenderAmount";
            this.lblTenderAmount.Size = new System.Drawing.Size(33, 16);
            this.lblTenderAmount.TabIndex = 73;
            this.lblTenderAmount.Text = "0.00";
            // 
            // lblAmountDue
            // 
            this.lblAmountDue.AutoSize = true;
            this.lblAmountDue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountDue.ForeColor = System.Drawing.Color.Black;
            this.lblAmountDue.Location = new System.Drawing.Point(177, 147);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(33, 16);
            this.lblAmountDue.TabIndex = 71;
            this.lblAmountDue.Text = "0.00";
            // 
            // lblGross
            // 
            this.lblGross.AutoSize = true;
            this.lblGross.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGross.ForeColor = System.Drawing.Color.Black;
            this.lblGross.Location = new System.Drawing.Point(177, 9);
            this.lblGross.Name = "lblGross";
            this.lblGross.Size = new System.Drawing.Size(33, 16);
            this.lblGross.TabIndex = 69;
            this.lblGross.Text = "0.00";
            // 
            // lblDiscAmount
            // 
            this.lblDiscAmount.AutoSize = true;
            this.lblDiscAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscAmount.Location = new System.Drawing.Point(177, 35);
            this.lblDiscAmount.Name = "lblDiscAmount";
            this.lblDiscAmount.Size = new System.Drawing.Size(33, 16);
            this.lblDiscAmount.TabIndex = 72;
            this.lblDiscAmount.Text = "0.00";
            // 
            // lblDocTotal
            // 
            this.lblDocTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocTotal.AutoSize = true;
            this.lblDocTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocTotal.ForeColor = System.Drawing.Color.Black;
            this.lblDocTotal.Location = new System.Drawing.Point(177, 61);
            this.lblDocTotal.Name = "lblDocTotal";
            this.lblDocTotal.Size = new System.Drawing.Size(33, 16);
            this.lblDocTotal.TabIndex = 70;
            this.lblDocTotal.Text = "0.00";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(13, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 68;
            this.label8.Text = "Tender Amount:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Gray;
            this.Label11.Location = new System.Drawing.Point(13, 147);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(90, 16);
            this.Label11.TabIndex = 66;
            this.Label11.Text = "Amount Due:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Gray;
            this.Label6.Location = new System.Drawing.Point(13, 9);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(84, 16);
            this.Label6.TabIndex = 63;
            this.Label6.Text = "Gross Price:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(13, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 16);
            this.label14.TabIndex = 67;
            this.label14.Text = "Discount Amount:";
            // 
            // Label9
            // 
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Gray;
            this.Label9.Location = new System.Drawing.Point(13, 61);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(75, 16);
            this.Label9.TabIndex = 64;
            this.Label9.Text = "Doc. Total:";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.Black;
            this.lblReference.Location = new System.Drawing.Point(92, 46);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(30, 16);
            this.lblReference.TabIndex = 38;
            this.lblReference.Text = "N/A";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.AutoSize = true;
            this.lblDocStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocStatus.ForeColor = System.Drawing.Color.Black;
            this.lblDocStatus.Location = new System.Drawing.Point(600, 46);
            this.lblDocStatus.Name = "lblDocStatus";
            this.lblDocStatus.Size = new System.Drawing.Size(72, 16);
            this.lblDocStatus.TabIndex = 39;
            this.lblDocStatus.Text = "----------------";
            // 
            // lblTransdate
            // 
            this.lblTransdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransdate.AutoSize = true;
            this.lblTransdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransdate.ForeColor = System.Drawing.Color.Black;
            this.lblTransdate.Location = new System.Drawing.Point(600, 73);
            this.lblTransdate.Name = "lblTransdate";
            this.lblTransdate.Size = new System.Drawing.Size(72, 16);
            this.lblTransdate.TabIndex = 45;
            this.lblTransdate.Text = "0000-00-00";
            // 
            // lblSAP
            // 
            this.lblSAP.AutoSize = true;
            this.lblSAP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSAP.ForeColor = System.Drawing.Color.Black;
            this.lblSAP.Location = new System.Drawing.Point(92, 73);
            this.lblSAP.Name = "lblSAP";
            this.lblSAP.Size = new System.Drawing.Size(30, 16);
            this.lblSAP.TabIndex = 46;
            this.lblSAP.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(9, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 16);
            this.label10.TabIndex = 47;
            this.label10.Text = "Reference:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(9, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 16);
            this.label12.TabIndex = 48;
            this.label12.Text = "SAP #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(499, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Doc. Status:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(499, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 16);
            this.label13.TabIndex = 50;
            this.label13.Text = "Trans. Date:";
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(289, 177);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 51;
            this.lblNoDataFound.Text = "No data found";
            // 
            // SalesTransactions_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 471);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblSAP);
            this.Controls.Add(this.lblTransdate);
            this.Controls.Add(this.lblDocStatus);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesTransactions_Items";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Items Transactions";
            this.Load += new System.EventHandler(this.SalesTransactions_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label lblTenderAmount;
        internal System.Windows.Forms.Label lblAmountDue;
        internal System.Windows.Forms.Label lblGross;
        internal System.Windows.Forms.Label lblDiscAmount;
        internal System.Windows.Forms.Label lblDocTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_total;
        public System.Windows.Forms.Label lblReference;
        public System.Windows.Forms.Label lblDocStatus;
        public System.Windows.Forms.Label lblTransdate;
        public System.Windows.Forms.Label lblSAP;
        private System.Windows.Forms.Label lblNoDataFound;
        internal System.Windows.Forms.Label lblAppliedAmount;
        internal System.Windows.Forms.Label label3;
    }
}