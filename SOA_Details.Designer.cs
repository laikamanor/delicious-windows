namespace DeliciousPartnerApp
{
    partial class SOA_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOA_Details));
            this.label2 = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDateTransaction = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.base_transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference:";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(156, 40);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(32, 18);
            this.lblReference.TabIndex = 2;
            this.lblReference.Text = "N/A";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.Location = new System.Drawing.Point(156, 87);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(32, 18);
            this.lblCustomerCode.TabIndex = 4;
            this.lblCustomerCode.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Customer Code:";
            // 
            // lblDateTransaction
            // 
            this.lblDateTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTransaction.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTransaction.Location = new System.Drawing.Point(539, 40);
            this.lblDateTransaction.Name = "lblDateTransaction";
            this.lblDateTransaction.Size = new System.Drawing.Size(110, 18);
            this.lblDateTransaction.TabIndex = 6;
            this.lblDateTransaction.Text = "02/016/2020";
            this.lblDateTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(410, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Date Transaction:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.base_transdate,
            this.base_reference,
            this.sales_remarks,
            this.amount});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(37, 108);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(612, 209);
            this.dgv.TabIndex = 7;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(549, 368);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 22);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(542, 328);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(107, 18);
            this.lblTotalAmount.TabIndex = 12;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(438, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Total Amount:";
            // 
            // base_transdate
            // 
            this.base_transdate.FillWeight = 31.81049F;
            this.base_transdate.HeaderText = "Transaction Date";
            this.base_transdate.MinimumWidth = 150;
            this.base_transdate.Name = "base_transdate";
            this.base_transdate.ReadOnly = true;
            // 
            // base_reference
            // 
            this.base_reference.FillWeight = 31.81049F;
            this.base_reference.HeaderText = "Base Reference";
            this.base_reference.MinimumWidth = 150;
            this.base_reference.Name = "base_reference";
            this.base_reference.ReadOnly = true;
            // 
            // sales_remarks
            // 
            this.sales_remarks.FillWeight = 31.81049F;
            this.sales_remarks.HeaderText = "Sales Invoice";
            this.sales_remarks.MinimumWidth = 150;
            this.sales_remarks.Name = "sales_remarks";
            this.sales_remarks.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.FillWeight = 31.81049F;
            this.amount.HeaderText = "Amount";
            this.amount.MinimumWidth = 150;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // SOA_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 423);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblDateTransaction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCustomerCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SOA_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statement of Account";
            this.Load += new System.EventHandler(this.SOA_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDateTransaction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}