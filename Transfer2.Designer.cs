namespace DeliciousPartnerApp
{
    partial class Transfer2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer2));
            this.label3 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearchTransactions = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbStatusTransactions = new System.Windows.Forms.ComboBox();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sap_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variance_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rec_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewReceive = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWhse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbToWhse = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchQuery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(581, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "To Date:";
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(676, 163);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(117, 22);
            this.dtToDate.TabIndex = 40;
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(370, 274);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 39;
            this.lblNoDataFound.Text = "No data found";
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(218, 162);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(81, 22);
            this.btnsearch.TabIndex = 38;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtsearchTransactions
            // 
            this.txtsearchTransactions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsearchTransactions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtsearchTransactions.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchTransactions.Location = new System.Drawing.Point(9, 163);
            this.txtsearchTransactions.Name = "txtsearchTransactions";
            this.txtsearchTransactions.Size = new System.Drawing.Size(209, 21);
            this.txtsearchTransactions.TabIndex = 37;
            this.txtsearchTransactions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearchTransactions_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.DimGray;
            this.Label2.Location = new System.Drawing.Point(6, 127);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 15);
            this.Label2.TabIndex = 36;
            this.Label2.Text = "Doc. Status:";
            // 
            // cmbStatusTransactions
            // 
            this.cmbStatusTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbStatusTransactions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatusTransactions.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusTransactions.ForeColor = System.Drawing.Color.Black;
            this.cmbStatusTransactions.FormattingEnabled = true;
            this.cmbStatusTransactions.Items.AddRange(new object[] {
            "All",
            "Open",
            "Closed",
            "Cancelled"});
            this.cmbStatusTransactions.Location = new System.Drawing.Point(145, 124);
            this.cmbStatusTransactions.Name = "cmbStatusTransactions";
            this.cmbStatusTransactions.Size = new System.Drawing.Size(154, 23);
            this.cmbStatusTransactions.TabIndex = 35;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.ColumnHeadersHeight = 40;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.transnumber,
            this.transdate,
            this.reference,
            this.remarks,
            this.docstatus,
            this.sap_number,
            this.variance_count,
            this.rec_count,
            this.btnViewReceive});
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.GridColor = System.Drawing.Color.DarkGray;
            this.dgvTransactions.Location = new System.Drawing.Point(9, 228);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 10;
            this.dgvTransactions.Size = new System.Drawing.Size(784, 181);
            this.dgvTransactions.TabIndex = 34;
            this.dgvTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // transnumber
            // 
            this.transnumber.HeaderText = "Trans. #";
            this.transnumber.Name = "transnumber";
            this.transnumber.ReadOnly = true;
            this.transnumber.Visible = false;
            // 
            // transdate
            // 
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // reference
            // 
            this.reference.HeaderText = "Reference";
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // docstatus
            // 
            this.docstatus.HeaderText = "Doc. Status";
            this.docstatus.Name = "docstatus";
            this.docstatus.ReadOnly = true;
            // 
            // sap_number
            // 
            this.sap_number.HeaderText = "SAP #";
            this.sap_number.Name = "sap_number";
            this.sap_number.ReadOnly = true;
            // 
            // variance_count
            // 
            this.variance_count.HeaderText = "Variance";
            this.variance_count.Name = "variance_count";
            this.variance_count.ReadOnly = true;
            this.variance_count.Visible = false;
            // 
            // rec_count
            // 
            this.rec_count.HeaderText = "Rec. Count";
            this.rec_count.Name = "rec_count";
            this.rec_count.ReadOnly = true;
            // 
            // btnViewReceive
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.btnViewReceive.DefaultCellStyle = dataGridViewCellStyle4;
            this.btnViewReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReceive.HeaderText = "Action";
            this.btnViewReceive.MinimumWidth = 100;
            this.btnViewReceive.Name = "btnViewReceive";
            this.btnViewReceive.ReadOnly = true;
            this.btnViewReceive.Text = "View Receive";
            this.btnViewReceive.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "From Warehouse:";
            // 
            // cmbWhse
            // 
            this.cmbWhse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbWhse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWhse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbWhse.FormattingEnabled = true;
            this.cmbWhse.Location = new System.Drawing.Point(145, 58);
            this.cmbWhse.Name = "cmbWhse";
            this.cmbWhse.Size = new System.Drawing.Size(154, 24);
            this.cmbWhse.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.ForeColor = System.Drawing.Color.Black;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(145, 22);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(154, 24);
            this.cmbBranch.TabIndex = 42;
            this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "To Warehouse:";
            // 
            // cmbToWhse
            // 
            this.cmbToWhse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbToWhse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbToWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToWhse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbToWhse.FormattingEnabled = true;
            this.cmbToWhse.Location = new System.Drawing.Point(145, 90);
            this.cmbToWhse.Name = "cmbToWhse";
            this.cmbToWhse.Size = new System.Drawing.Size(154, 24);
            this.cmbToWhse.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(581, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "From Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(676, 135);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(117, 22);
            this.dtFromDate.TabIndex = 48;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // btnSearchQuery
            // 
            this.btnSearchQuery.BackColor = System.Drawing.Color.Silver;
            this.btnSearchQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchQuery.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchQuery.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchQuery.ForeColor = System.Drawing.Color.Black;
            this.btnSearchQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchQuery.Image")));
            this.btnSearchQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchQuery.Location = new System.Drawing.Point(9, 190);
            this.btnSearchQuery.Name = "btnSearchQuery";
            this.btnSearchQuery.Size = new System.Drawing.Size(147, 32);
            this.btnSearchQuery.TabIndex = 76;
            this.btnSearchQuery.Text = "Search Query";
            this.btnSearchQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchQuery.UseVisualStyleBackColor = false;
            this.btnSearchQuery.Click += new System.EventHandler(this.btnSearchQuery_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(646, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 32);
            this.button1.TabIndex = 77;
            this.button1.Text = "Search Query";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Transfer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 446);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearchQuery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbToWhse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbWhse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearchTransactions);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbStatusTransactions);
            this.Controls.Add(this.dgvTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transfer2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Transfer2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label lblNoDataFound;
        internal System.Windows.Forms.Button btnsearch;
        internal System.Windows.Forms.TextBox txtsearchTransactions;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbStatusTransactions;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWhse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbToWhse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn docstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn sap_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn variance_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn rec_count;
        private System.Windows.Forms.DataGridViewButtonColumn btnViewReceive;
        internal System.Windows.Forms.Button btnSearchQuery;
        internal System.Windows.Forms.Button button1;
    }
}