namespace AB
{
    partial class CustomerLedger_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesPerCustomer_Details));
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.running_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(730, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "To:";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(763, 35);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(96, 22);
            this.dtToDate.TabIndex = 43;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(581, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 16);
            this.label21.TabIndex = 42;
            this.label21.Text = "Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(628, 35);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(96, 22);
            this.dtFromDate.TabIndex = 41;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Location = new System.Drawing.Point(127, 66);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(30, 16);
            this.lblCustomerCode.TabIndex = 40;
            this.lblCustomerCode.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Customer Code:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.transdate,
            this.reference,
            this.reference2,
            this.transtype,
            this.amt_in,
            this.amt_out,
            this.running_balance,
            this.remarks});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(12, 90);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(982, 392);
            this.dgv.TabIndex = 38;
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(855, 65);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(139, 16);
            this.lblBalance.TabIndex = 46;
            this.lblBalance.Text = "N/A";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(716, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Beginning Balance:";
            // 
            // transdate
            // 
            this.transdate.FillWeight = 27.83418F;
            this.transdate.HeaderText = "Transaction Date";
            this.transdate.MinimumWidth = 150;
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            this.transdate.Width = 151;
            // 
            // reference
            // 
            this.reference.FillWeight = 532.9949F;
            this.reference.HeaderText = "Reference #";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            this.reference.Width = 166;
            // 
            // reference2
            // 
            this.reference2.FillWeight = 27.83418F;
            this.reference2.HeaderText = "Reference 2 #";
            this.reference2.MinimumWidth = 100;
            this.reference2.Name = "reference2";
            this.reference2.ReadOnly = true;
            this.reference2.Width = 101;
            // 
            // transtype
            // 
            this.transtype.FillWeight = 27.83418F;
            this.transtype.HeaderText = "Transaction Type";
            this.transtype.MinimumWidth = 150;
            this.transtype.Name = "transtype";
            this.transtype.ReadOnly = true;
            this.transtype.Width = 151;
            // 
            // amt_in
            // 
            this.amt_in.FillWeight = 27.83418F;
            this.amt_in.HeaderText = "Sales";
            this.amt_in.MinimumWidth = 100;
            this.amt_in.Name = "amt_in";
            this.amt_in.ReadOnly = true;
            this.amt_in.Width = 101;
            // 
            // amt_out
            // 
            this.amt_out.FillWeight = 27.83418F;
            this.amt_out.HeaderText = "Payment";
            this.amt_out.MinimumWidth = 100;
            this.amt_out.Name = "amt_out";
            this.amt_out.ReadOnly = true;
            this.amt_out.Width = 102;
            // 
            // running_balance
            // 
            this.running_balance.FillWeight = 27.83418F;
            this.running_balance.HeaderText = "Running Balance";
            this.running_balance.MinimumWidth = 100;
            this.running_balance.Name = "running_balance";
            this.running_balance.ReadOnly = true;
            this.running_balance.Width = 101;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.MinimumWidth = 100;
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // SalesPerCustomer_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 503);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lblCustomerCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesPerCustomer_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Per Customer Details";
            this.Load += new System.EventHandler(this.SalesPerCustomer_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        public System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference2;
        private System.Windows.Forms.DataGridViewTextBoxColumn transtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn running_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}