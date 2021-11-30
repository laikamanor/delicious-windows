namespace DeliciousPartnerApp
{
    partial class SalesPerCustomer_Details
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.running_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ar_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(843, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "To:";
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(876, 30);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(96, 22);
            this.dtToDate.TabIndex = 43;
            this.dtToDate.CloseUp += new System.EventHandler(this.dtToDate_CloseUp);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(694, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 16);
            this.label21.TabIndex = 42;
            this.label21.Text = "Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(741, 30);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(96, 22);
            this.dtFromDate.TabIndex = 41;
            this.dtFromDate.CloseUp += new System.EventHandler(this.dtFromDate_CloseUp);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Location = new System.Drawing.Point(127, 70);
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
            this.label1.Location = new System.Drawing.Point(12, 70);
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
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.id,
            this.transdate,
            this.reference,
            this.reference2,
            this.transtype,
            this.amt_in,
            this.amt_out,
            this.running_balance,
            this.ar_num,
            this.ip_num,
            this.remarks});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(12, 90);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(960, 320);
            this.dgv.TabIndex = 38;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(833, 70);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(117, 16);
            this.lblBalance.TabIndex = 46;
            this.lblBalance.Text = "N/A";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(694, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Beginning Balance:";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(876, 416);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 29);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 100;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // transdate
            // 
            this.transdate.FillWeight = 27.83418F;
            this.transdate.HeaderText = "Transaction Date";
            this.transdate.MinimumWidth = 150;
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // reference
            // 
            this.reference.FillWeight = 532.9949F;
            this.reference.HeaderText = "Reference #";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // reference2
            // 
            this.reference2.FillWeight = 27.83418F;
            this.reference2.HeaderText = "Reference 2 #";
            this.reference2.MinimumWidth = 100;
            this.reference2.Name = "reference2";
            this.reference2.ReadOnly = true;
            // 
            // transtype
            // 
            this.transtype.FillWeight = 27.83418F;
            this.transtype.HeaderText = "Transaction Type";
            this.transtype.MinimumWidth = 150;
            this.transtype.Name = "transtype";
            this.transtype.ReadOnly = true;
            // 
            // amt_in
            // 
            this.amt_in.FillWeight = 27.83418F;
            this.amt_in.HeaderText = "Sales";
            this.amt_in.MinimumWidth = 100;
            this.amt_in.Name = "amt_in";
            this.amt_in.ReadOnly = true;
            // 
            // amt_out
            // 
            this.amt_out.FillWeight = 27.83418F;
            this.amt_out.HeaderText = "Payment";
            this.amt_out.MinimumWidth = 100;
            this.amt_out.Name = "amt_out";
            this.amt_out.ReadOnly = true;
            // 
            // running_balance
            // 
            this.running_balance.FillWeight = 27.83418F;
            this.running_balance.HeaderText = "Running Balance";
            this.running_balance.MinimumWidth = 100;
            this.running_balance.Name = "running_balance";
            this.running_balance.ReadOnly = true;
            // 
            // ar_num
            // 
            this.ar_num.HeaderText = "AR #";
            this.ar_num.MinimumWidth = 100;
            this.ar_num.Name = "ar_num";
            this.ar_num.ReadOnly = true;
            // 
            // ip_num
            // 
            this.ip_num.HeaderText = "IP #";
            this.ip_num.MinimumWidth = 100;
            this.ip_num.Name = "ip_num";
            this.ip_num.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.MinimumWidth = 150;
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // SalesPerCustomer_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 503);
            this.Controls.Add(this.btnPrint);
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
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Ledger Details";
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
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference2;
        private System.Windows.Forms.DataGridViewTextBoxColumn transtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn running_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ar_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}