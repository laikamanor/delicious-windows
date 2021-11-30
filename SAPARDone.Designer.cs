namespace DeliciousPartnerApp
{
    partial class SAPARDone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAPARDone));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnViewItem = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkSelectAll = new System.Windows.Forms.CheckBox();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.cmbBranch = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbsales = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbSearchType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbCustomerType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbToTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFromTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.checkToDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSearchQuery2 = new System.Windows.Forms.Button();
            this.btnSearchQuery = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbsales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSearchType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewItem
            // 
            this.btnViewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewItem.BackColor = System.Drawing.Color.Silver;
            this.btnViewItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewItem.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnViewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewItem.ForeColor = System.Drawing.Color.DimGray;
            this.btnViewItem.Image = ((System.Drawing.Image)(resources.GetObject("btnViewItem.Image")));
            this.btnViewItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewItem.Location = new System.Drawing.Point(869, 494);
            this.btnViewItem.Name = "btnViewItem";
            this.btnViewItem.Size = new System.Drawing.Size(130, 36);
            this.btnViewItem.TabIndex = 11;
            this.btnViewItem.Text = "View Item";
            this.btnViewItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewItem.UseVisualStyleBackColor = false;
            this.btnViewItem.Click += new System.EventHandler(this.btnViewItem_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(1, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 16);
            this.label15.TabIndex = 95;
            this.label15.Text = "Customer Type:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(1, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 16);
            this.label13.TabIndex = 92;
            this.label13.Text = "Search Type:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.ForestGreen;
            this.panel6.Controls.Add(this.checkSelectAll);
            this.panel6.Controls.Add(this.lblOrderCount);
            this.panel6.Location = new System.Drawing.Point(4, 221);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(995, 29);
            this.panel6.TabIndex = 81;
            // 
            // checkSelectAll
            // 
            this.checkSelectAll.AutoSize = true;
            this.checkSelectAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSelectAll.ForeColor = System.Drawing.Color.White;
            this.checkSelectAll.Location = new System.Drawing.Point(3, 8);
            this.checkSelectAll.Name = "checkSelectAll";
            this.checkSelectAll.Size = new System.Drawing.Size(77, 18);
            this.checkSelectAll.TabIndex = 65;
            this.checkSelectAll.Text = "Select All";
            this.checkSelectAll.UseVisualStyleBackColor = true;
            this.checkSelectAll.CheckedChanged += new System.EventHandler(this.checkSelectAll_CheckedChanged);
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCount.ForeColor = System.Drawing.Color.White;
            this.lblOrderCount.Location = new System.Drawing.Point(468, 8);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(73, 15);
            this.lblOrderCount.TabIndex = 14;
            this.lblOrderCount.Text = "ORDERS (0)";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtsearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtsearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtsearch.Location = new System.Drawing.Point(4, 150);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(273, 22);
            this.txtsearch.TabIndex = 79;
            this.txtsearch.Text = "Search Trans#";
            //this.txtsearch.FontChanged += new System.EventHandler(this.txtsearch_FontChanged);
            this.txtsearch.Enter += new System.EventHandler(this.txtsearch_Enter);
            this.txtsearch.Leave += new System.EventHandler(this.txtsearch_Leave);
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.DimGray;
            this.Label3.Location = new System.Drawing.Point(4, 55);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(40, 16);
            this.Label3.TabIndex = 78;
            this.Label3.Text = "User:";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.Gray;
            this.dgvOrders.Location = new System.Drawing.Point(4, 251);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 10;
            this.dgvOrders.Size = new System.Drawing.Size(995, 237);
            this.dgvOrders.TabIndex = 74;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbBranch.Location = new System.Drawing.Point(117, 14);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbBranch.Properties.Appearance.Options.UseFont = true;
            this.cmbBranch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBranch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBranch.Size = new System.Drawing.Size(160, 22);
            this.cmbBranch.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(4, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 96;
            this.label5.Text = "Branch:";
            // 
            // cmbsales
            // 
            this.cmbsales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbsales.Location = new System.Drawing.Point(117, 48);
            this.cmbsales.Name = "cmbsales";
            this.cmbsales.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbsales.Properties.Appearance.Options.UseFont = true;
            this.cmbsales.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsales.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbsales.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbsales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbsales.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbsales.Size = new System.Drawing.Size(160, 22);
            this.cmbsales.TabIndex = 98;
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSearchType.Location = new System.Drawing.Point(117, 119);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbSearchType.Properties.Appearance.Options.UseFont = true;
            this.cmbSearchType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbSearchType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbSearchType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSearchType.Properties.Items.AddRange(new object[] {
            "Trans. #",
            "Cust. Code"});
            this.cmbSearchType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSearchType.Size = new System.Drawing.Size(160, 22);
            this.cmbSearchType.TabIndex = 99;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbCustomerType.Location = new System.Drawing.Point(117, 82);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbCustomerType.Properties.Appearance.Options.UseFont = true;
            this.cmbCustomerType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbCustomerType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbCustomerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCustomerType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCustomerType.Size = new System.Drawing.Size(160, 22);
            this.cmbCustomerType.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(738, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 104;
            this.label6.Text = "From Time:";
            // 
            // cmbToTime
            // 
            this.cmbToTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbToTime.Location = new System.Drawing.Point(852, 150);
            this.cmbToTime.Name = "cmbToTime";
            this.cmbToTime.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbToTime.Properties.Appearance.Options.UseFont = true;
            this.cmbToTime.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbToTime.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbToTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbToTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbToTime.Properties.Items.AddRange(new object[] {
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
            this.cmbToTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbToTime.Size = new System.Drawing.Size(147, 22);
            this.cmbToTime.TabIndex = 103;
            // 
            // cmbFromTime
            // 
            this.cmbFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFromTime.Location = new System.Drawing.Point(852, 121);
            this.cmbFromTime.Name = "cmbFromTime";
            this.cmbFromTime.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbFromTime.Properties.Appearance.Options.UseFont = true;
            this.cmbFromTime.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9.75F);
            this.cmbFromTime.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbFromTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmbFromTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFromTime.Properties.Items.AddRange(new object[] {
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
            this.cmbFromTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFromTime.Size = new System.Drawing.Size(147, 22);
            this.cmbFromTime.TabIndex = 102;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(738, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 101;
            this.label7.Text = "To Time:";
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.EditValue = null;
            this.dtToDate.Location = new System.Drawing.Point(852, 90);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dtToDate.Properties.Appearance.Options.UseFont = true;
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtToDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtToDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtToDate.Size = new System.Drawing.Size(147, 22);
            this.dtToDate.TabIndex = 110;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.EditValue = null;
            this.dtFromDate.Location = new System.Drawing.Point(852, 60);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dtFromDate.Properties.Appearance.Options.UseFont = true;
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtFromDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtFromDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtFromDate.Size = new System.Drawing.Size(147, 22);
            this.dtFromDate.TabIndex = 109;
            // 
            // checkToDate
            // 
            this.checkToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkToDate.AutoSize = true;
            this.checkToDate.Checked = true;
            this.checkToDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkToDate.Location = new System.Drawing.Point(741, 93);
            this.checkToDate.Name = "checkToDate";
            this.checkToDate.Size = new System.Drawing.Size(15, 14);
            this.checkToDate.TabIndex = 108;
            this.checkToDate.UseVisualStyleBackColor = true;
            this.checkToDate.CheckedChanged += new System.EventHandler(this.checkToDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(762, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 107;
            this.label4.Text = "To Date:";
            // 
            // checkDate
            // 
            this.checkDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDate.AutoSize = true;
            this.checkDate.Checked = true;
            this.checkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDate.Location = new System.Drawing.Point(741, 65);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(15, 14);
            this.checkDate.TabIndex = 106;
            this.checkDate.UseVisualStyleBackColor = true;
            this.checkDate.CheckedChanged += new System.EventHandler(this.checkDate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(762, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 105;
            this.label1.Text = "From Date:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Silver;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(733, 494);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 36);
            this.btnRefresh.TabIndex = 111;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnSearchQuery2
            // 
            this.btnSearchQuery2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchQuery2.BackColor = System.Drawing.Color.Silver;
            this.btnSearchQuery2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchQuery2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearchQuery2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchQuery2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchQuery2.ForeColor = System.Drawing.Color.Black;
            this.btnSearchQuery2.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchQuery2.Image")));
            this.btnSearchQuery2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchQuery2.Location = new System.Drawing.Point(852, 183);
            this.btnSearchQuery2.Name = "btnSearchQuery2";
            this.btnSearchQuery2.Size = new System.Drawing.Size(147, 32);
            this.btnSearchQuery2.TabIndex = 112;
            this.btnSearchQuery2.Text = "Search Query";
            this.btnSearchQuery2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchQuery2.UseVisualStyleBackColor = false;
            this.btnSearchQuery2.Click += new System.EventHandler(this.btnSearchQuery2_Click);
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
            this.btnSearchQuery.Location = new System.Drawing.Point(4, 183);
            this.btnSearchQuery.Name = "btnSearchQuery";
            this.btnSearchQuery.Size = new System.Drawing.Size(147, 32);
            this.btnSearchQuery.TabIndex = 113;
            this.btnSearchQuery.Text = "Search Query";
            this.btnSearchQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchQuery.UseVisualStyleBackColor = false;
            this.btnSearchQuery.Click += new System.EventHandler(this.btnSearchQuery_Click);
            // 
            // SAPARDone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 542);
            this.Controls.Add(this.btnSearchQuery);
            this.Controls.Add(this.btnSearchQuery2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.checkToDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbToTime);
            this.Controls.Add(this.cmbFromTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.cmbSearchType);
            this.Controls.Add(this.cmbsales);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnViewItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SAPARDone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SAPARDone_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbsales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSearchType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnViewItem;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox checkSelectAll;
        internal System.Windows.Forms.Label lblOrderCount;
        internal System.Windows.Forms.TextBox txtsearch;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.DataGridView dgvOrders;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBranch;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbsales;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSearchType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCustomerType;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbToTime;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFromTime;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private System.Windows.Forms.CheckBox checkToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal System.Windows.Forms.Button btnSearchQuery2;
        internal System.Windows.Forms.Button btnSearchQuery;
    }
}