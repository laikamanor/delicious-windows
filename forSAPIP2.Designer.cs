namespace DeliciousPartnerApp
{
    partial class forSAPIP2
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnProceed = new System.Windows.Forms.Button();
            this.checkTransDate = new System.Windows.Forms.CheckBox();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.checkToDate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCustType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.selectt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.selectt,
            this.id,
            this.payment_id,
            this.transdate,
            this.cust_code,
            this.payment_type,
            this.amount,
            this.reference2});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(10, 203);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(675, 171);
            this.dgv.TabIndex = 2;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(511, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "From Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(594, 123);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(91, 21);
            this.dtFromDate.TabIndex = 8;
            this.dtFromDate.CloseUp += new System.EventHandler(this.dtFromDate_CloseUp);
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProceed.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProceed.FlatAppearance.BorderSize = 0;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.Location = new System.Drawing.Point(555, 380);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(130, 36);
            this.btnProceed.TabIndex = 10;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // checkTransDate
            // 
            this.checkTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTransDate.AutoSize = true;
            this.checkTransDate.Location = new System.Drawing.Point(478, 130);
            this.checkTransDate.Name = "checkTransDate";
            this.checkTransDate.Size = new System.Drawing.Size(15, 14);
            this.checkTransDate.TabIndex = 11;
            this.checkTransDate.UseVisualStyleBackColor = true;
            this.checkTransDate.CheckedChanged += new System.EventHandler(this.checkTransDate_CheckedChanged);
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(297, 250);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 13;
            this.lblNoDataFound.Text = "No data found";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaymentType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(130, 56);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(186, 23);
            this.cmbPaymentType.TabIndex = 14;
            this.cmbPaymentType.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Payment Type:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(7, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(97, 380);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(31, 15);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "0.00";
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.ForeColor = System.Drawing.Color.Black;
            this.checkSelectAll.Location = new System.Drawing.Point(10, 154);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.checkSelectAll.TabIndex = 66;
            this.checkSelectAll.Text = "Select All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(10, 123);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(161, 21);
            this.txtSearch.TabIndex = 67;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(171, 123);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 21);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Location = new System.Drawing.Point(10, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 30);
            this.panel1.TabIndex = 69;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(301, 8);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(65, 15);
            this.lblCount.TabIndex = 15;
            this.lblCount.Text = "COUNT (0)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(511, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 70;
            this.label4.Text = "To Date:";
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(594, 150);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(91, 21);
            this.dtToDate.TabIndex = 71;
            this.dtToDate.CloseUp += new System.EventHandler(this.dtToDate_CloseUp);
            // 
            // checkToDate
            // 
            this.checkToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkToDate.AutoSize = true;
            this.checkToDate.Location = new System.Drawing.Point(478, 153);
            this.checkToDate.Name = "checkToDate";
            this.checkToDate.Size = new System.Drawing.Size(15, 14);
            this.checkToDate.TabIndex = 72;
            this.checkToDate.UseVisualStyleBackColor = true;
            this.checkToDate.CheckedChanged += new System.EventHandler(this.checkToDate_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 74;
            this.label5.Text = "Customer Type:";
            // 
            // cmbCustType
            // 
            this.cmbCustType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbCustType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustType.FormattingEnabled = true;
            this.cmbCustType.Location = new System.Drawing.Point(130, 25);
            this.cmbCustType.Name = "cmbCustType";
            this.cmbCustType.Size = new System.Drawing.Size(186, 23);
            this.cmbCustType.TabIndex = 73;
            this.cmbCustType.SelectedIndexChanged += new System.EventHandler(this.cmbCustType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(7, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 76;
            this.label6.Text = "Branch:";
            // 
            // cmbBranches
            // 
            this.cmbBranches.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranches.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranches.FormattingEnabled = true;
            this.cmbBranches.Location = new System.Drawing.Point(130, 88);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(186, 23);
            this.cmbBranches.TabIndex = 75;
            this.cmbBranches.SelectedIndexChanged += new System.EventHandler(this.cmbBranches_SelectedIndexChanged);
            // 
            // selectt
            // 
            this.selectt.HeaderText = "Select";
            this.selectt.Name = "selectt";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // payment_id
            // 
            this.payment_id.HeaderText = "Payment ID";
            this.payment_id.Name = "payment_id";
            this.payment_id.ReadOnly = true;
            this.payment_id.Visible = false;
            // 
            // transdate
            // 
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // cust_code
            // 
            this.cust_code.HeaderText = "Customer Code";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // payment_type
            // 
            this.payment_type.HeaderText = "Payment Type";
            this.payment_type.Name = "payment_type";
            this.payment_type.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // reference2
            // 
            this.reference2.HeaderText = "Payment Reference";
            this.reference2.Name = "reference2";
            this.reference2.ReadOnly = true;
            // 
            // forSAPIP2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 428);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbBranches);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCustType);
            this.Controls.Add(this.checkToDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.checkSelectAll);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPaymentType);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.checkTransDate);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "forSAPIP2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.forSAPIP2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.CheckBox checkTransDate;
        private System.Windows.Forms.Label lblNoDataFound;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.CheckBox checkToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCustType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference2;
    }
}