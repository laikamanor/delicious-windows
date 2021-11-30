namespace DeliciousPartnerApp
{
    partial class SalesReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReport));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbsales = new System.Windows.Forms.ComboBox();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discpercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.free = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbToTime = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFromTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDelFee = new System.Windows.Forms.Label();
            this.txtTotalPayment = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.Label();
            this.txtTenderAmount = new System.Windows.Forms.Label();
            this.txtlAmountPayable = new System.Windows.Forms.Label();
            this.txtGrossPrice = new System.Windows.Forms.Label();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.Panel8 = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processed_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintAR = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
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
            this.selectt,
            this.ID,
            this.transnumber,
            this.transdate,
            this.reference,
            this.gross,
            this.disc_type,
            this.disc_amount,
            this.doctotal,
            this.customer_code,
            this.transtype,
            this.remarks,
            this.processed_by,
            this.btnPrintAR});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(15, 261);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(605, 201);
            this.dgv.TabIndex = 3;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(342, 182);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 16);
            this.label21.TabIndex = 23;
            this.label21.Text = "Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(389, 178);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(96, 22);
            this.dtFromDate.TabIndex = 22;
            this.dtFromDate.CloseUp += new System.EventHandler(this.dtFromDate_CloseUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(12, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 21;
            this.label15.Text = "User:";
            // 
            // cmbsales
            // 
            this.cmbsales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbsales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbsales.ForeColor = System.Drawing.Color.Black;
            this.cmbsales.FormattingEnabled = true;
            this.cmbsales.Location = new System.Drawing.Point(124, 74);
            this.cmbsales.Name = "cmbsales";
            this.cmbsales.Size = new System.Drawing.Size(154, 23);
            this.cmbsales.TabIndex = 20;
            this.cmbsales.SelectedIndexChanged += new System.EventHandler(this.cmbsales_SelectedIndexChanged);
            this.cmbsales.SelectionChangeCommitted += new System.EventHandler(this.cmbsales_SelectionChangeCommitted);
            this.cmbsales.DropDownClosed += new System.EventHandler(this.cmbsales_DropDownClosed);
            this.cmbsales.SelectedValueChanged += new System.EventHandler(this.cmbsales_SelectedValueChanged);
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(285, 303);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 25;
            this.lblNoDataFound.Text = "No data found";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Trans. Type:";
            // 
            // cmbTransType
            // 
            this.cmbTransType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTransType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTransType.ForeColor = System.Drawing.Color.Black;
            this.cmbTransType.FormattingEnabled = true;
            this.cmbTransType.Location = new System.Drawing.Point(124, 109);
            this.cmbTransType.Name = "cmbTransType";
            this.cmbTransType.Size = new System.Drawing.Size(154, 23);
            this.cmbTransType.TabIndex = 28;
            this.cmbTransType.SelectedIndexChanged += new System.EventHandler(this.cmbTransType_SelectedIndexChanged);
            this.cmbTransType.SelectionChangeCommitted += new System.EventHandler(this.cmbTransType_SelectionChangeCommitted);
            this.cmbTransType.DropDownClosed += new System.EventHandler(this.cmbTransType_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbBranch.ForeColor = System.Drawing.Color.Black;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(124, 11);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(154, 23);
            this.cmbBranch.TabIndex = 30;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.SelectionChangeCommitted += new System.EventHandler(this.cmbBranch_SelectionChangeCommitted);
            this.cmbBranch.DropDownClosed += new System.EventHandler(this.cmbBranch_DropDownClosed);
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            this.cmbBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBranch_KeyPress);
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(524, 178);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(96, 22);
            this.dtToDate.TabIndex = 32;
            this.dtToDate.CloseUp += new System.EventHandler(this.dtToDate_CloseUp);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(491, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "To:";
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.AllowUserToDeleteRows = false;
            this.dgvitems.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvitems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvitems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvitems.BackgroundColor = System.Drawing.Color.White;
            this.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvitems.ColumnHeadersHeight = 40;
            this.dgvitems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.quantity,
            this.price,
            this.discpercent,
            this.discamt,
            this.totalprice,
            this.free});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvitems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvitems.EnableHeadersVisualStyles = false;
            this.dgvitems.GridColor = System.Drawing.Color.Gray;
            this.dgvitems.Location = new System.Drawing.Point(3, 32);
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.RowHeadersWidth = 10;
            this.dgvitems.Size = new System.Drawing.Size(505, 126);
            this.dgvitems.TabIndex = 55;
            this.dgvitems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvitems_CellClick);
            // 
            // item
            // 
            this.item.HeaderText = "Item";
            this.item.MinimumWidth = 150;
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 150;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Qty.";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 83;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 83;
            // 
            // discpercent
            // 
            this.discpercent.HeaderText = "Disc. %";
            this.discpercent.Name = "discpercent";
            this.discpercent.ReadOnly = true;
            this.discpercent.Width = 83;
            // 
            // discamt
            // 
            this.discamt.HeaderText = "Disc. Amt.";
            this.discamt.Name = "discamt";
            this.discamt.ReadOnly = true;
            this.discamt.Width = 83;
            // 
            // totalprice
            // 
            this.totalprice.HeaderText = "Total Amount";
            this.totalprice.Name = "totalprice";
            this.totalprice.ReadOnly = true;
            this.totalprice.Width = 83;
            // 
            // free
            // 
            this.free.HeaderText = "Free";
            this.free.Name = "free";
            this.free.ReadOnly = true;
            this.free.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cmbCustomerType);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.cmbSearchType);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbWarehouse);
            this.panel1.Controls.Add(this.cmbToTime);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbFromTime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblNoDataFound);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.dtToDate);
            this.panel1.Controls.Add(this.cmbsales);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.cmbTransType);
            this.panel1.Controls.Add(this.dtFromDate);
            this.panel1.Controls.Add(this.cmbBranch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 466);
            this.panel1.TabIndex = 56;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatAppearance.BorderSize = 0;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(204, 208);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 20);
            this.btnsearch.TabIndex = 79;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtsearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtsearch.Location = new System.Drawing.Point(15, 208);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(189, 21);
            this.txtsearch.TabIndex = 78;
            this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(12, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 15);
            this.label13.TabIndex = 77;
            this.label13.Text = "Customer Type:";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbCustomerType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomerType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbCustomerType.ForeColor = System.Drawing.Color.Black;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(124, 142);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(154, 23);
            this.cmbCustomerType.TabIndex = 76;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            this.cmbCustomerType.SelectionChangeCommitted += new System.EventHandler(this.cmbCustomerType_SelectionChangeCommitted);
            this.cmbCustomerType.DropDownClosed += new System.EventHandler(this.cmbCustomerType_DropDownClosed);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(12, 182);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 15);
            this.label17.TabIndex = 75;
            this.label17.Text = "Search Type:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbSearchType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSearchType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbSearchType.ForeColor = System.Drawing.Color.Black;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "Trans. #",
            "Cust. Code",
            "Remarks"});
            this.cmbSearchType.Location = new System.Drawing.Point(124, 178);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(154, 23);
            this.cmbSearchType.TabIndex = 74;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            this.cmbSearchType.DropDownClosed += new System.EventHandler(this.cmbSearchType_DropDownClosed);
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(117)))), ((int)(((byte)(32)))));
            this.panel11.Controls.Add(this.lblOrderCount);
            this.panel11.Controls.Add(this.checkSelectAll);
            this.panel11.Location = new System.Drawing.Point(15, 234);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(605, 27);
            this.panel11.TabIndex = 73;
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCount.ForeColor = System.Drawing.Color.White;
            this.lblOrderCount.Location = new System.Drawing.Point(270, 6);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(65, 15);
            this.lblOrderCount.TabIndex = 67;
            this.lblOrderCount.Text = "Orders (0)";
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSelectAll.ForeColor = System.Drawing.Color.White;
            this.checkSelectAll.Location = new System.Drawing.Point(4, 6);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(77, 18);
            this.checkSelectAll.TabIndex = 66;
            this.checkSelectAll.Text = "Select All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(12, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 72;
            this.label7.Text = "Warehouse:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWarehouse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWarehouse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbWarehouse.ForeColor = System.Drawing.Color.Black;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(124, 42);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(154, 23);
            this.cmbWarehouse.TabIndex = 71;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            this.cmbWarehouse.SelectionChangeCommitted += new System.EventHandler(this.cmbWarehouse_SelectionChangeCommitted);
            this.cmbWarehouse.DropDownClosed += new System.EventHandler(this.cmbWarehouse_DropDownClosed);
            this.cmbWarehouse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbWarehouse_KeyDown);
            // 
            // cmbToTime
            // 
            this.cmbToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbToTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbToTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbToTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
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
            this.cmbToTime.Location = new System.Drawing.Point(524, 206);
            this.cmbToTime.Name = "cmbToTime";
            this.cmbToTime.Size = new System.Drawing.Size(96, 24);
            this.cmbToTime.TabIndex = 70;
            this.cmbToTime.SelectedIndexChanged += new System.EventHandler(this.cmbToTime_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(491, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 15);
            this.label12.TabIndex = 69;
            this.label12.Text = "To";
            // 
            // cmbFromTime
            // 
            this.cmbFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFromTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbFromTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFromTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFromTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
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
            this.cmbFromTime.Location = new System.Drawing.Point(392, 208);
            this.cmbFromTime.Name = "cmbFromTime";
            this.cmbFromTime.Size = new System.Drawing.Size(93, 24);
            this.cmbFromTime.TabIndex = 68;
            this.cmbFromTime.SelectedIndexChanged += new System.EventHandler(this.cmbFromTime_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(342, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 67;
            this.label4.Text = "Time:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.dgvitems);
            this.panel3.Location = new System.Drawing.Point(638, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 466);
            this.panel3.TabIndex = 57;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.Color.ForestGreen;
            this.panel12.Controls.Add(this.lblItemsCount);
            this.panel12.Location = new System.Drawing.Point(3, 10);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(505, 29);
            this.panel12.TabIndex = 65;
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsCount.ForeColor = System.Drawing.Color.White;
            this.lblItemsCount.Location = new System.Drawing.Point(233, 8);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(57, 15);
            this.lblItemsCount.TabIndex = 15;
            this.lblItemsCount.Text = "Items (0)";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(117)))), ((int)(((byte)(32)))));
            this.panel2.Controls.Add(this.txtDelFee);
            this.panel2.Controls.Add(this.txtTotalPayment);
            this.panel2.Controls.Add(this.panel13);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDiscountAmount);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtChange);
            this.panel2.Controls.Add(this.txtTenderAmount);
            this.panel2.Controls.Add(this.txtlAmountPayable);
            this.panel2.Controls.Add(this.txtGrossPrice);
            this.panel2.Controls.Add(this.Panel10);
            this.panel2.Controls.Add(this.Panel9);
            this.panel2.Controls.Add(this.Panel8);
            this.panel2.Controls.Add(this.Panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.Label11);
            this.panel2.Controls.Add(this.Label10);
            this.panel2.Controls.Add(this.Label9);
            this.panel2.Controls.Add(this.Label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 298);
            this.panel2.TabIndex = 56;
            // 
            // txtDelFee
            // 
            this.txtDelFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDelFee.BackColor = System.Drawing.Color.Transparent;
            this.txtDelFee.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelFee.ForeColor = System.Drawing.Color.White;
            this.txtDelFee.Location = new System.Drawing.Point(259, 97);
            this.txtDelFee.Name = "txtDelFee";
            this.txtDelFee.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDelFee.Size = new System.Drawing.Size(216, 18);
            this.txtDelFee.TabIndex = 59;
            this.txtDelFee.Text = "0.00";
            // 
            // txtTotalPayment
            // 
            this.txtTotalPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPayment.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalPayment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayment.ForeColor = System.Drawing.Color.White;
            this.txtTotalPayment.Location = new System.Drawing.Point(258, 207);
            this.txtTotalPayment.Name = "txtTotalPayment";
            this.txtTotalPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalPayment.Size = new System.Drawing.Size(216, 18);
            this.txtTotalPayment.TabIndex = 64;
            this.txtTotalPayment.Text = "0.00";
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Location = new System.Drawing.Point(32, 129);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(440, 1);
            this.panel13.TabIndex = 58;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(29, 97);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 16);
            this.label16.TabIndex = 57;
            this.label16.Text = "Delivery Fee:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(31, 232);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(440, 1);
            this.panel7.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(28, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "Total Payment:";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtDiscountAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmount.ForeColor = System.Drawing.Color.White;
            this.txtDiscountAmount.Location = new System.Drawing.Point(258, 133);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscountAmount.Size = new System.Drawing.Size(216, 18);
            this.txtDiscountAmount.TabIndex = 61;
            this.txtDiscountAmount.Text = "0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(28, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 16);
            this.label14.TabIndex = 60;
            this.label14.Text = "Discount Amount:";
            // 
            // txtChange
            // 
            this.txtChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChange.BackColor = System.Drawing.Color.Transparent;
            this.txtChange.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.ForeColor = System.Drawing.Color.White;
            this.txtChange.Location = new System.Drawing.Point(258, 271);
            this.txtChange.Name = "txtChange";
            this.txtChange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtChange.Size = new System.Drawing.Size(216, 18);
            this.txtChange.TabIndex = 59;
            this.txtChange.Text = "0.00";
            // 
            // txtTenderAmount
            // 
            this.txtTenderAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenderAmount.BackColor = System.Drawing.Color.Transparent;
            this.txtTenderAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenderAmount.ForeColor = System.Drawing.Color.White;
            this.txtTenderAmount.Location = new System.Drawing.Point(258, 239);
            this.txtTenderAmount.Name = "txtTenderAmount";
            this.txtTenderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTenderAmount.Size = new System.Drawing.Size(216, 18);
            this.txtTenderAmount.TabIndex = 58;
            this.txtTenderAmount.Text = "0.00";
            // 
            // txtlAmountPayable
            // 
            this.txtlAmountPayable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlAmountPayable.BackColor = System.Drawing.Color.Transparent;
            this.txtlAmountPayable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlAmountPayable.ForeColor = System.Drawing.Color.White;
            this.txtlAmountPayable.Location = new System.Drawing.Point(258, 171);
            this.txtlAmountPayable.Name = "txtlAmountPayable";
            this.txtlAmountPayable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtlAmountPayable.Size = new System.Drawing.Size(216, 18);
            this.txtlAmountPayable.TabIndex = 57;
            this.txtlAmountPayable.Text = "0.00";
            // 
            // txtGrossPrice
            // 
            this.txtGrossPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrossPrice.BackColor = System.Drawing.Color.Transparent;
            this.txtGrossPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossPrice.ForeColor = System.Drawing.Color.White;
            this.txtGrossPrice.Location = new System.Drawing.Point(259, 57);
            this.txtGrossPrice.Name = "txtGrossPrice";
            this.txtGrossPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGrossPrice.Size = new System.Drawing.Size(216, 18);
            this.txtGrossPrice.TabIndex = 56;
            this.txtGrossPrice.Text = "0.00";
            // 
            // Panel10
            // 
            this.Panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel10.BackColor = System.Drawing.Color.White;
            this.Panel10.Location = new System.Drawing.Point(31, 264);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(440, 1);
            this.Panel10.TabIndex = 54;
            // 
            // Panel9
            // 
            this.Panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel9.BackColor = System.Drawing.Color.White;
            this.Panel9.Location = new System.Drawing.Point(31, 196);
            this.Panel9.Name = "Panel9";
            this.Panel9.Size = new System.Drawing.Size(440, 1);
            this.Panel9.TabIndex = 53;
            // 
            // Panel8
            // 
            this.Panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel8.BackColor = System.Drawing.Color.White;
            this.Panel8.Location = new System.Drawing.Point(31, 156);
            this.Panel8.Name = "Panel8";
            this.Panel8.Size = new System.Drawing.Size(440, 1);
            this.Panel8.TabIndex = 55;
            // 
            // Panel5
            // 
            this.Panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel5.BackColor = System.Drawing.Color.White;
            this.Panel5.Location = new System.Drawing.Point(32, 89);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(440, 1);
            this.Panel5.TabIndex = 52;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(32, 44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(440, 1);
            this.panel6.TabIndex = 51;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.White;
            this.Label11.Location = new System.Drawing.Point(28, 271);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(61, 16);
            this.Label11.TabIndex = 50;
            this.Label11.Text = "Change:";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.White;
            this.Label10.Location = new System.Drawing.Point(28, 239);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(109, 16);
            this.Label10.TabIndex = 49;
            this.Label10.Text = "Tender Amount:";
            // 
            // Label9
            // 
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.White;
            this.Label9.Location = new System.Drawing.Point(28, 171);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(117, 16);
            this.Label9.TabIndex = 48;
            this.Label9.Text = "Amount Payable:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(29, 57);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(100, 16);
            this.Label6.TabIndex = 47;
            this.Label6.Text = "Gross Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 46;
            this.label1.Text = "BILLS";
            // 
            // selectt
            // 
            this.selectt.FillWeight = 150.8476F;
            this.selectt.HeaderText = "Select";
            this.selectt.MinimumWidth = 75;
            this.selectt.Name = "selectt";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 50;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // transnumber
            // 
            this.transnumber.HeaderText = "Trans. #";
            this.transnumber.MinimumWidth = 150;
            this.transnumber.Name = "transnumber";
            this.transnumber.ReadOnly = true;
            this.transnumber.Visible = false;
            // 
            // transdate
            // 
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.MinimumWidth = 150;
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // reference
            // 
            this.reference.FillWeight = 344.67F;
            this.reference.HeaderText = "Reference";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // gross
            // 
            this.gross.FillWeight = 40.89647F;
            this.gross.HeaderText = "Gross";
            this.gross.MinimumWidth = 100;
            this.gross.Name = "gross";
            this.gross.ReadOnly = true;
            // 
            // disc_type
            // 
            this.disc_type.HeaderText = "Disc. Type";
            this.disc_type.MinimumWidth = 100;
            this.disc_type.Name = "disc_type";
            this.disc_type.ReadOnly = true;
            // 
            // disc_amount
            // 
            this.disc_amount.HeaderText = "Disc. Amount";
            this.disc_amount.MinimumWidth = 100;
            this.disc_amount.Name = "disc_amount";
            this.disc_amount.ReadOnly = true;
            // 
            // doctotal
            // 
            this.doctotal.FillWeight = 40.89647F;
            this.doctotal.HeaderText = "Doc. Total";
            this.doctotal.MinimumWidth = 100;
            this.doctotal.Name = "doctotal";
            this.doctotal.ReadOnly = true;
            // 
            // customer_code
            // 
            this.customer_code.FillWeight = 40.89647F;
            this.customer_code.HeaderText = "Customer Code";
            this.customer_code.MinimumWidth = 150;
            this.customer_code.Name = "customer_code";
            this.customer_code.ReadOnly = true;
            // 
            // transtype
            // 
            this.transtype.FillWeight = 40.89647F;
            this.transtype.HeaderText = "Trans. Type";
            this.transtype.MinimumWidth = 150;
            this.transtype.Name = "transtype";
            this.transtype.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.MinimumWidth = 100;
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // processed_by
            // 
            this.processed_by.FillWeight = 40.89647F;
            this.processed_by.HeaderText = "Processed By";
            this.processed_by.MinimumWidth = 150;
            this.processed_by.Name = "processed_by";
            this.processed_by.ReadOnly = true;
            // 
            // btnPrintAR
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.btnPrintAR.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnPrintAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAR.HeaderText = "Action";
            this.btnPrintAR.MinimumWidth = 100;
            this.btnPrintAR.Name = "btnPrintAR";
            this.btnPrintAR.Text = "Print AR";
            this.btnPrintAR.UseColumnTextForButtonValue = true;
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1153, 503);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Detailed Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.ComboBox cmbsales;
        private System.Windows.Forms.Label lblNoDataFound;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbTransType;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DataGridView dgvitems;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn discpercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn discamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalprice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn free;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkSelectAll;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label txtTotalPayment;
        internal System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label txtDiscountAmount;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label txtChange;
        internal System.Windows.Forms.Label txtTenderAmount;
        internal System.Windows.Forms.Label txtlAmountPayable;
        internal System.Windows.Forms.Label txtGrossPrice;
        internal System.Windows.Forms.Panel Panel10;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.Panel Panel8;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbToTime;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbFromTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Panel panel11;
        internal System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.Panel panel12;
        internal System.Windows.Forms.Label lblItemsCount;
        internal System.Windows.Forms.Label txtDelFee;
        internal System.Windows.Forms.Panel panel13;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbCustomerType;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.ComboBox cmbSearchType;
        internal System.Windows.Forms.Button btnsearch;
        internal System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn transnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn disc_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn transtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn processed_by;
        private System.Windows.Forms.DataGridViewButtonColumn btnPrintAR;
    }
}