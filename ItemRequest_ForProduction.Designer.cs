namespace DeliciousPartnerApp
{
    partial class ItemRequest_ForProduction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemRequest_ForProduction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.checkToDate = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbRequestorWhse = new System.Windows.Forms.ComboBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.checkDate = new System.Windows.Forms.CheckBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkSelect = new System.Windows.Forms.CheckBox();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmbProdWhse = new System.Windows.Forms.ComboBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.selectt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.series_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.series_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectt2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_whse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toWhse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsCount.ForeColor = System.Drawing.Color.White;
            this.lblItemsCount.Location = new System.Drawing.Point(236, 8);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(60, 15);
            this.lblItemsCount.TabIndex = 15;
            this.lblItemsCount.Text = "ITEMS (0)";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.ForestGreen;
            this.panel11.Controls.Add(this.lblItemsCount);
            this.panel11.Location = new System.Drawing.Point(5, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(510, 29);
            this.panel11.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.dgvitems);
            this.panel2.Location = new System.Drawing.Point(867, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 784);
            this.panel2.TabIndex = 3;
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.AllowUserToDeleteRows = false;
            this.dgvitems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvitems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvitems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvitems.BackgroundColor = System.Drawing.Color.White;
            this.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvitems.ColumnHeadersHeight = 40;
            this.dgvitems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectt2,
            this.item,
            this.quantity,
            this.from_whse,
            this.toWhse});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvitems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvitems.EnableHeadersVisualStyles = false;
            this.dgvitems.GridColor = System.Drawing.Color.Gray;
            this.dgvitems.Location = new System.Drawing.Point(5, 28);
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.RowHeadersWidth = 10;
            this.dgvitems.Size = new System.Drawing.Size(510, 753);
            this.dgvitems.TabIndex = 54;
            // 
            // checkToDate
            // 
            this.checkToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkToDate.AutoSize = true;
            this.checkToDate.Checked = true;
            this.checkToDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkToDate.Location = new System.Drawing.Point(641, 95);
            this.checkToDate.Name = "checkToDate";
            this.checkToDate.Size = new System.Drawing.Size(15, 14);
            this.checkToDate.TabIndex = 71;
            this.checkToDate.UseVisualStyleBackColor = true;
            this.checkToDate.CheckedChanged += new System.EventHandler(this.checkToDate_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(16, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 16);
            this.label13.TabIndex = 70;
            this.label13.Text = "Requestor Whse:";
            // 
            // cmbRequestorWhse
            // 
            this.cmbRequestorWhse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbRequestorWhse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbRequestorWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequestorWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRequestorWhse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRequestorWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbRequestorWhse.FormattingEnabled = true;
            this.cmbRequestorWhse.Items.AddRange(new object[] {
            "Trans. #",
            "Cust. Code"});
            this.cmbRequestorWhse.Location = new System.Drawing.Point(149, 63);
            this.cmbRequestorWhse.Name = "cmbRequestorWhse";
            this.cmbRequestorWhse.Size = new System.Drawing.Size(143, 23);
            this.cmbRequestorWhse.TabIndex = 69;
            this.cmbRequestorWhse.SelectedIndexChanged += new System.EventHandler(this.cmbRequestorWhse_SelectedIndexChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(749, 94);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(107, 22);
            this.dtToDate.TabIndex = 68;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(666, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 67;
            this.label4.Text = "To Date:";
            // 
            // checkDate
            // 
            this.checkDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDate.AutoSize = true;
            this.checkDate.Checked = true;
            this.checkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDate.Location = new System.Drawing.Point(641, 75);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(15, 14);
            this.checkDate.TabIndex = 66;
            this.checkDate.UseVisualStyleBackColor = true;
            this.checkDate.CheckedChanged += new System.EventHandler(this.checkDate_CheckedChanged);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(174, 95);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 25);
            this.btnsearch.TabIndex = 16;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(16, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 61;
            this.label7.Text = "Branch:";
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
            this.cmbBranches.Location = new System.Drawing.Point(149, 3);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(143, 24);
            this.cmbBranches.TabIndex = 60;
            this.cmbBranches.SelectedIndexChanged += new System.EventHandler(this.cmbBranches_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.checkToDate);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cmbRequestorWhse);
            this.panel1.Controls.Add(this.dtToDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkDate);
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbBranches);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtFromDate);
            this.panel1.Controls.Add(this.lblNoDataFound);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.Label3);
            this.panel1.Controls.Add(this.cmbProdWhse);
            this.panel1.Controls.Add(this.dgvOrders);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 784);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(641, 675);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(215, 40);
            this.btnConfirm.TabIndex = 72;
            this.btnConfirm.Text = "Create Production Order";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(666, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "From Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(749, 68);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(107, 22);
            this.dtFromDate.TabIndex = 7;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DarkGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(388, 381);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(102, 17);
            this.lblNoDataFound.TabIndex = 56;
            this.lblNoDataFound.Text = "No data found.";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.ForestGreen;
            this.panel6.Controls.Add(this.checkSelect);
            this.panel6.Controls.Add(this.lblOrderCount);
            this.panel6.Location = new System.Drawing.Point(16, 122);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(840, 29);
            this.panel6.TabIndex = 54;
            // 
            // checkSelect
            // 
            this.checkSelect.AutoSize = true;
            this.checkSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSelect.ForeColor = System.Drawing.Color.White;
            this.checkSelect.Location = new System.Drawing.Point(3, 9);
            this.checkSelect.Name = "checkSelect";
            this.checkSelect.Size = new System.Drawing.Size(77, 18);
            this.checkSelect.TabIndex = 72;
            this.checkSelect.Text = "Select All";
            this.checkSelect.UseVisualStyleBackColor = true;
            this.checkSelect.CheckedChanged += new System.EventHandler(this.checkSelect_CheckedChanged);
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCount.ForeColor = System.Drawing.Color.White;
            this.lblOrderCount.Location = new System.Drawing.Point(391, 8);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(73, 15);
            this.lblOrderCount.TabIndex = 14;
            this.lblOrderCount.Text = "ORDERS (0)";
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(159, 25);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.DimGray;
            this.Label3.Location = new System.Drawing.Point(16, 34);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 16);
            this.Label3.TabIndex = 13;
            this.Label3.Text = "Production Whse:";
            // 
            // cmbProdWhse
            // 
            this.cmbProdWhse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbProdWhse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbProdWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProdWhse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbProdWhse.FormattingEnabled = true;
            this.cmbProdWhse.Items.AddRange(new object[] {
            "All"});
            this.cmbProdWhse.Location = new System.Drawing.Point(149, 34);
            this.cmbProdWhse.Name = "cmbProdWhse";
            this.cmbProdWhse.Size = new System.Drawing.Size(143, 23);
            this.cmbProdWhse.TabIndex = 10;
            this.cmbProdWhse.SelectedIndexChanged += new System.EventHandler(this.cmbProdWhse_SelectedIndexChanged);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectt,
            this.id,
            this.series_id,
            this.series_code,
            this.transnumber,
            this.docstatus,
            this.reference,
            this.transdate,
            this.days_due,
            this.reference2});
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.Gray;
            this.dgvOrders.Location = new System.Drawing.Point(16, 150);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 10;
            this.dgvOrders.Size = new System.Drawing.Size(840, 519);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            this.dgvOrders.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOrders_RowValidating);
            // 
            // selectt
            // 
            this.selectt.HeaderText = "Select";
            this.selectt.MinimumWidth = 50;
            this.selectt.Name = "selectt";
            this.selectt.Width = 50;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 100;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // series_id
            // 
            this.series_id.HeaderText = "Series ID";
            this.series_id.Name = "series_id";
            this.series_id.ReadOnly = true;
            this.series_id.Visible = false;
            // 
            // series_code
            // 
            this.series_code.HeaderText = "Series Code";
            this.series_code.Name = "series_code";
            this.series_code.ReadOnly = true;
            this.series_code.Visible = false;
            // 
            // transnumber
            // 
            this.transnumber.HeaderText = "Trans. Number";
            this.transnumber.MinimumWidth = 100;
            this.transnumber.Name = "transnumber";
            this.transnumber.ReadOnly = true;
            this.transnumber.Visible = false;
            // 
            // docstatus
            // 
            this.docstatus.HeaderText = "Doc. Status";
            this.docstatus.Name = "docstatus";
            this.docstatus.ReadOnly = true;
            this.docstatus.Visible = false;
            // 
            // reference
            // 
            this.reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reference.FillWeight = 309.7052F;
            this.reference.HeaderText = "Reference";
            this.reference.MinimumWidth = 100;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // transdate
            // 
            this.transdate.FillWeight = 54.2846F;
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.MinimumWidth = 200;
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            this.transdate.Width = 200;
            // 
            // days_due
            // 
            this.days_due.HeaderText = "Aging";
            this.days_due.Name = "days_due";
            this.days_due.ReadOnly = true;
            // 
            // reference2
            // 
            this.reference2.HeaderText = "Reference 2";
            this.reference2.MinimumWidth = 100;
            this.reference2.Name = "reference2";
            this.reference2.ReadOnly = true;
            // 
            // selectt2
            // 
            this.selectt2.HeaderText = "Select";
            this.selectt2.Name = "selectt2";
            // 
            // item
            // 
            this.item.HeaderText = "Item";
            this.item.MinimumWidth = 150;
            this.item.Name = "item";
            this.item.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Qty.";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // from_whse
            // 
            this.from_whse.HeaderText = "From Whse";
            this.from_whse.Name = "from_whse";
            this.from_whse.ReadOnly = true;
            this.from_whse.Visible = false;
            // 
            // toWhse
            // 
            this.toWhse.HeaderText = "To Whse";
            this.toWhse.Name = "toWhse";
            this.toWhse.ReadOnly = true;
            this.toWhse.Visible = false;
            // 
            // ItemRequest_ForProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemRequest_ForProduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "For Production";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ItemRequest_ForProduction_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dgvitems;
        private System.Windows.Forms.CheckBox checkToDate;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbRequestorWhse;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkDate;
        internal System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label lblNoDataFound;
        private System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Label lblOrderCount;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cmbProdWhse;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn series_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn series_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn transnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn docstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn days_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference2;
        private System.Windows.Forms.CheckBox checkSelect;
        internal System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_whse;
        private System.Windows.Forms.DataGridViewTextBoxColumn toWhse;
    }
}