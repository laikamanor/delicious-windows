namespace DeliciousPartnerApp
{
    partial class SummaryDeposit_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryDeposit_Details));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dep_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.running_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
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
            this.transdate,
            this.reference,
            this.reference2,
            this.transtype,
            this.dep_in,
            this.dep_out,
            this.running_balance});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(12, 64);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(863, 397);
            this.dgv.TabIndex = 6;
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
            // dep_in
            // 
            this.dep_in.FillWeight = 27.83418F;
            this.dep_in.HeaderText = "Deposit In";
            this.dep_in.MinimumWidth = 100;
            this.dep_in.Name = "dep_in";
            this.dep_in.ReadOnly = true;
            // 
            // dep_out
            // 
            this.dep_out.FillWeight = 27.83418F;
            this.dep_out.HeaderText = "Deposit Out";
            this.dep_out.MinimumWidth = 100;
            this.dep_out.Name = "dep_out";
            this.dep_out.ReadOnly = true;
            // 
            // running_balance
            // 
            this.running_balance.FillWeight = 27.83418F;
            this.running_balance.HeaderText = "Running Balance";
            this.running_balance.MinimumWidth = 100;
            this.running_balance.Name = "running_balance";
            this.running_balance.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Customer Code:";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerCode.Location = new System.Drawing.Point(124, 45);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(30, 16);
            this.lblCustomerCode.TabIndex = 8;
            this.lblCustomerCode.Text = "N/A";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(746, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "To:";
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(779, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(96, 22);
            this.dtToDate.TabIndex = 36;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(597, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 16);
            this.label21.TabIndex = 35;
            this.label21.Text = "Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(644, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(96, 22);
            this.dtFromDate.TabIndex = 34;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Black;
            this.lblBalance.Location = new System.Drawing.Point(736, 44);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(139, 16);
            this.lblBalance.TabIndex = 48;
            this.lblBalance.Text = "N/A";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(597, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Beginning Balance:";
            // 
            // SummaryDeposit_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(887, 473);
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
            this.Name = "SummaryDeposit_Details";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary Deposit Details";
            this.Load += new System.EventHandler(this.SummaryDeposit_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        public System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference2;
        private System.Windows.Forms.DataGridViewTextBoxColumn transtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn dep_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn running_balance;
        public System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label3;
    }
}