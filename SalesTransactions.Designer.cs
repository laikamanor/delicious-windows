namespace DeliciousPartnerApp
{
    partial class SalesTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesTransactions));
            this.label4 = new System.Windows.Forms.Label();
            this.dtTransDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWhse = new System.Windows.Forms.ComboBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbDocStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.checkSAP = new System.Windows.Forms.CheckBox();
            this.checkTransDate = new System.Windows.Forms.CheckBox();
            this.btnGenerateExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCustType = new System.Windows.Forms.ComboBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sap_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(443, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Trans. Date:";
            // 
            // dtTransDate
            // 
            this.dtTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTransDate.CustomFormat = "yyyy-MM-dd";
            this.dtTransDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransDate.Location = new System.Drawing.Point(533, 220);
            this.dtTransDate.Name = "dtTransDate";
            this.dtTransDate.Size = new System.Drawing.Size(154, 22);
            this.dtTransDate.TabIndex = 41;
            this.dtTransDate.ValueChanged += new System.EventHandler(this.dtTransDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(24, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Warehouse:";
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
            this.cmbWhse.Location = new System.Drawing.Point(146, 89);
            this.cmbWhse.Name = "cmbWhse";
            this.cmbWhse.Size = new System.Drawing.Size(159, 24);
            this.cmbWhse.TabIndex = 39;
            this.cmbWhse.SelectedValueChanged += new System.EventHandler(this.cmbWhse_SelectedValueChanged);
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
            this.cmbBranch.Location = new System.Drawing.Point(146, 57);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(159, 24);
            this.cmbBranch.TabIndex = 38;
            this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
            // 
            // cmbDocStatus
            // 
            this.cmbDocStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDocStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocStatus.ForeColor = System.Drawing.Color.Black;
            this.cmbDocStatus.FormattingEnabled = true;
            this.cmbDocStatus.Items.AddRange(new object[] {
            "All",
            "Open",
            "Closed",
            "Cancelled"});
            this.cmbDocStatus.Location = new System.Drawing.Point(146, 119);
            this.cmbDocStatus.Name = "cmbDocStatus";
            this.cmbDocStatus.Size = new System.Drawing.Size(159, 24);
            this.cmbDocStatus.TabIndex = 37;
            this.cmbDocStatus.SelectedValueChanged += new System.EventHandler(this.cmbDocStatus_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(24, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Doc. Status:";
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
            this.id,
            this.transdate,
            this.reference,
            this.cust_code,
            this.doctotal,
            this.transtype,
            this.sap_number,
            this.docstatus,
            this.remarks});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(27, 243);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(660, 191);
            this.dgv.TabIndex = 35;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(24, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Branch:";
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(308, 313);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 44;
            this.lblNoDataFound.Text = "No data found";
            // 
            // checkSAP
            // 
            this.checkSAP.AutoSize = true;
            this.checkSAP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSAP.Location = new System.Drawing.Point(27, 30);
            this.checkSAP.Name = "checkSAP";
            this.checkSAP.Size = new System.Drawing.Size(91, 20);
            this.checkSAP.TabIndex = 45;
            this.checkSAP.Text = "have AR #";
            this.checkSAP.UseVisualStyleBackColor = true;
            this.checkSAP.CheckedChanged += new System.EventHandler(this.checkSAP_CheckedChanged);
            // 
            // checkTransDate
            // 
            this.checkTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTransDate.AutoSize = true;
            this.checkTransDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTransDate.Location = new System.Drawing.Point(422, 226);
            this.checkTransDate.Name = "checkTransDate";
            this.checkTransDate.Size = new System.Drawing.Size(15, 14);
            this.checkTransDate.TabIndex = 46;
            this.checkTransDate.UseVisualStyleBackColor = true;
            this.checkTransDate.CheckedChanged += new System.EventHandler(this.checkTransDate_CheckedChanged);
            // 
            // btnGenerateExcel
            // 
            this.btnGenerateExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateExcel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGenerateExcel.FlatAppearance.BorderSize = 0;
            this.btnGenerateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateExcel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateExcel.ForeColor = System.Drawing.Color.White;
            this.btnGenerateExcel.Location = new System.Drawing.Point(536, 440);
            this.btnGenerateExcel.Name = "btnGenerateExcel";
            this.btnGenerateExcel.Size = new System.Drawing.Size(151, 36);
            this.btnGenerateExcel.TabIndex = 47;
            this.btnGenerateExcel.Text = "Generate Excel";
            this.btnGenerateExcel.UseVisualStyleBackColor = false;
            this.btnGenerateExcel.Click += new System.EventHandler(this.btnGenerateExcel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(24, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "Cust. Type:";
            // 
            // cmbCustType
            // 
            this.cmbCustType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbCustType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCustType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustType.ForeColor = System.Drawing.Color.Black;
            this.cmbCustType.FormattingEnabled = true;
            this.cmbCustType.Location = new System.Drawing.Point(146, 153);
            this.cmbCustType.Name = "cmbCustType";
            this.cmbCustType.Size = new System.Drawing.Size(159, 24);
            this.cmbCustType.TabIndex = 48;
            this.cmbCustType.SelectedIndexChanged += new System.EventHandler(this.cmbCustType_SelectedIndexChanged);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(221, 216);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(84, 26);
            this.btnsearch.TabIndex = 53;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtsearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(27, 216);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(194, 25);
            this.txtsearch.TabIndex = 52;
            this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(24, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 55;
            this.label6.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbSearchType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSearchType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchType.ForeColor = System.Drawing.Color.Black;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Reference",
            "Cust. Code"});
            this.cmbSearchType.Location = new System.Drawing.Point(146, 184);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(159, 24);
            this.cmbSearchType.TabIndex = 54;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            // cust_code
            // 
            this.cust_code.HeaderText = "Customer Code";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // doctotal
            // 
            this.doctotal.HeaderText = "Doc. Total";
            this.doctotal.Name = "doctotal";
            this.doctotal.ReadOnly = true;
            // 
            // transtype
            // 
            this.transtype.HeaderText = "Trans. Type";
            this.transtype.Name = "transtype";
            this.transtype.ReadOnly = true;
            // 
            // sap_number
            // 
            this.sap_number.HeaderText = "SAP #";
            this.sap_number.Name = "sap_number";
            this.sap_number.ReadOnly = true;
            // 
            // docstatus
            // 
            this.docstatus.HeaderText = "Doc. Status";
            this.docstatus.Name = "docstatus";
            this.docstatus.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // SalesTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(711, 498);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSearchType);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCustType);
            this.Controls.Add(this.btnGenerateExcel);
            this.Controls.Add(this.checkTransDate);
            this.Controls.Add(this.checkSAP);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtTransDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWhse);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbDocStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Transaction Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTransDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWhse;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbDocStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNoDataFound;
        private System.Windows.Forms.CheckBox checkSAP;
        private System.Windows.Forms.CheckBox checkTransDate;
        private System.Windows.Forms.Button btnGenerateExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCustType;
        internal System.Windows.Forms.Button btnsearch;
        internal System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn transtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn sap_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn docstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}