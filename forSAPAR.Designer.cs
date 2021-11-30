namespace DeliciousPartnerApp
{
    partial class forSAPAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forSAPAR));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.selectt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.base_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountdue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTenderType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.base_id,
            this.transnumber,
            this.reference,
            this.cust_code,
            this.doctotal,
            this.amountdue,
            this.tendertype,
            this.transdate});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(22, 73);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(754, 314);
            this.dgv.TabIndex = 1;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // selectt
            // 
            this.selectt.HeaderText = "Select";
            this.selectt.Name = "selectt";
            // 
            // base_id
            // 
            this.base_id.HeaderText = "ID";
            this.base_id.Name = "base_id";
            this.base_id.ReadOnly = true;
            this.base_id.Visible = false;
            // 
            // transnumber
            // 
            this.transnumber.HeaderText = "Trans. Number";
            this.transnumber.Name = "transnumber";
            this.transnumber.ReadOnly = true;
            this.transnumber.Visible = false;
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
            this.doctotal.HeaderText = "Document Total";
            this.doctotal.Name = "doctotal";
            this.doctotal.ReadOnly = true;
            // 
            // amountdue
            // 
            this.amountdue.HeaderText = "Amount Due";
            this.amountdue.Name = "amountdue";
            this.amountdue.ReadOnly = true;
            // 
            // tendertype
            // 
            this.tendertype.HeaderText = "Tender Type";
            this.tendertype.Name = "tendertype";
            this.tendertype.ReadOnly = true;
            // 
            // transdate
            // 
            this.transdate.HeaderText = "Transaction Date";
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtDate.CustomFormat = "yyyy-MM-dd";
            this.dtDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(630, 49);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(146, 21);
            this.dtDate.TabIndex = 2;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // cmbTenderType
            // 
            this.cmbTenderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTenderType.BackColor = System.Drawing.Color.DodgerBlue;
            this.cmbTenderType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTenderType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenderType.ForeColor = System.Drawing.Color.White;
            this.cmbTenderType.FormattingEnabled = true;
            this.cmbTenderType.Items.AddRange(new object[] {
            "CASH",
            "AR Sales"});
            this.cmbTenderType.Location = new System.Drawing.Point(630, 23);
            this.cmbTenderType.Name = "cmbTenderType";
            this.cmbTenderType.Size = new System.Drawing.Size(146, 23);
            this.cmbTenderType.TabIndex = 3;
            this.cmbTenderType.SelectedIndexChanged += new System.EventHandler(this.cmbTenderType_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(136, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(158, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(546, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tender Type:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(546, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date:";
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Location = new System.Drawing.Point(22, 52);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.checkSelectAll.TabIndex = 8;
            this.checkSelectAll.Text = "Select All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(630, 391);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(146, 35);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View Total Item";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(342, 154);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 12;
            this.lblNoDataFound.Text = "No data found";
            // 
            // forSAPAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.checkSelectAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbTenderType);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "forSAPAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "For SAP AR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.forSAPAR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ComboBox cmbTenderType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkSelectAll;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectt;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountdue;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.Label lblNoDataFound;
    }
}