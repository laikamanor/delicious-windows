namespace DeliciousPartnerApp
{
    partial class Production_ProductionOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production_ProductionOrder));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sap_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIssue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReceipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDocStatus = new System.Windows.Forms.ComboBox();
            this.checkToDate = new System.Windows.Forms.CheckBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.checkDate = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbToTime = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFromTime = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(232, 157);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(27, 157);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 9;
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
            this.id,
            this.transdate,
            this.proddate,
            this.reference,
            this.docstatus,
            this.sap_number,
            this.remarks,
            this.status,
            this.btnIssue,
            this.btnReceipt,
            this.btnClosed});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(27, 181);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(809, 264);
            this.dgv.TabIndex = 8;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 70;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // transdate
            // 
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.MinimumWidth = 150;
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // proddate
            // 
            this.proddate.HeaderText = "Prod. Date";
            this.proddate.MinimumWidth = 150;
            this.proddate.Name = "proddate";
            this.proddate.ReadOnly = true;
            // 
            // reference
            // 
            this.reference.HeaderText = "Reference";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // docstatus
            // 
            this.docstatus.HeaderText = "Doc. Status";
            this.docstatus.MinimumWidth = 100;
            this.docstatus.Name = "docstatus";
            this.docstatus.ReadOnly = true;
            // 
            // sap_number
            // 
            this.sap_number.HeaderText = "SAP #";
            this.sap_number.MinimumWidth = 150;
            this.sap_number.Name = "sap_number";
            this.sap_number.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.MinimumWidth = 150;
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Production Status";
            this.status.MinimumWidth = 150;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // btnIssue
            // 
            this.btnIssue.HeaderText = "Issue for Prod. Order";
            this.btnIssue.MinimumWidth = 150;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.ReadOnly = true;
            // 
            // btnReceipt
            // 
            this.btnReceipt.HeaderText = "Receipt from Prod. Order";
            this.btnReceipt.MinimumWidth = 150;
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.ReadOnly = true;
            // 
            // btnClosed
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnClosed.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnClosed.HeaderText = "Action";
            this.btnClosed.MinimumWidth = 100;
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(24, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Warehouse:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWarehouse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouse.ForeColor = System.Drawing.Color.Black;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(114, 51);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(154, 24);
            this.cmbWarehouse.TabIndex = 13;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Branch:";
            // 
            // cmbBranches
            // 
            this.cmbBranches.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBranches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranches.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranches.ForeColor = System.Drawing.Color.Black;
            this.cmbBranches.FormattingEnabled = true;
            this.cmbBranches.Location = new System.Drawing.Point(114, 15);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(154, 24);
            this.cmbBranches.TabIndex = 11;
            this.cmbBranches.SelectedIndexChanged += new System.EventHandler(this.cmbBranches_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(24, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.Color.Black;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(114, 123);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(154, 24);
            this.cmbStatus.TabIndex = 17;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(24, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Doc. Status:";
            // 
            // cmbDocStatus
            // 
            this.cmbDocStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDocStatus.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.cmbDocStatus.Location = new System.Drawing.Point(114, 87);
            this.cmbDocStatus.Name = "cmbDocStatus";
            this.cmbDocStatus.Size = new System.Drawing.Size(154, 24);
            this.cmbDocStatus.TabIndex = 15;
            this.cmbDocStatus.SelectedIndexChanged += new System.EventHandler(this.cmbDocStatus_SelectedIndexChanged);
            // 
            // checkToDate
            // 
            this.checkToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkToDate.AutoSize = true;
            this.checkToDate.Checked = true;
            this.checkToDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkToDate.Location = new System.Drawing.Point(612, 121);
            this.checkToDate.Name = "checkToDate";
            this.checkToDate.Size = new System.Drawing.Size(15, 14);
            this.checkToDate.TabIndex = 77;
            this.checkToDate.UseVisualStyleBackColor = true;
            this.checkToDate.CheckedChanged += new System.EventHandler(this.checkToDate_CheckedChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(729, 120);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(107, 22);
            this.dtToDate.TabIndex = 76;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(636, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 75;
            this.label5.Text = "To Date:";
            // 
            // checkDate
            // 
            this.checkDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDate.AutoSize = true;
            this.checkDate.Checked = true;
            this.checkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDate.Location = new System.Drawing.Point(612, 96);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(15, 14);
            this.checkDate.TabIndex = 74;
            this.checkDate.UseVisualStyleBackColor = true;
            this.checkDate.CheckedChanged += new System.EventHandler(this.checkDate_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(636, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 73;
            this.label6.Text = "From Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(729, 89);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(107, 22);
            this.dtFromDate.TabIndex = 72;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(744, 451);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 29);
            this.btnRefresh.TabIndex = 78;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbToTime
            // 
            this.cmbToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbToTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbToTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbToTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToTime.ForeColor = System.Drawing.Color.Black;
            this.cmbToTime.FormattingEnabled = true;
            this.cmbToTime.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00",
            "23:59"});
            this.cmbToTime.Location = new System.Drawing.Point(776, 156);
            this.cmbToTime.Name = "cmbToTime";
            this.cmbToTime.Size = new System.Drawing.Size(60, 23);
            this.cmbToTime.TabIndex = 92;
            this.cmbToTime.SelectedIndexChanged += new System.EventHandler(this.cmbToTime_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(757, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 15);
            this.label12.TabIndex = 91;
            this.label12.Text = "To";
            // 
            // cmbFromTime
            // 
            this.cmbFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFromTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbFromTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFromTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFromTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromTime.ForeColor = System.Drawing.Color.Black;
            this.cmbFromTime.FormattingEnabled = true;
            this.cmbFromTime.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00",
            "23:59"});
            this.cmbFromTime.Location = new System.Drawing.Point(697, 156);
            this.cmbFromTime.Name = "cmbFromTime";
            this.cmbFromTime.Size = new System.Drawing.Size(60, 23);
            this.cmbFromTime.TabIndex = 90;
            this.cmbFromTime.SelectedIndexChanged += new System.EventHandler(this.cmbFromTime_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(636, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 89;
            this.label7.Text = "Time:";
            // 
            // Production_ProductionOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 513);
            this.Controls.Add(this.cmbToTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbFromTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.checkToDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDocStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBranches);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Production_ProductionOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Production_ProductionOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDocStatus;
        private System.Windows.Forms.CheckBox checkToDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.ComboBox cmbToTime;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbFromTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn proddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn docstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn sap_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnClosed;
    }
}