namespace DeliciousPartnerApp
{
    partial class ItemSalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSalesReport));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalNetAmount = new System.Windows.Forms.Label();
            this.lblGrossAmount = new System.Windows.Forms.Label();
            this.lblDiscAmount = new System.Windows.Forms.Label();
            this.cmbToTime = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFromTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbWhse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(11, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 61;
            this.label1.Text = "Total Disc. Amount:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(11, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "Total Gross Amount:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(11, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "Total Net Amount:";
            // 
            // lblTotalNetAmount
            // 
            this.lblTotalNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalNetAmount.AutoSize = true;
            this.lblTotalNetAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNetAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalNetAmount.Location = new System.Drawing.Point(170, 392);
            this.lblTotalNetAmount.Name = "lblTotalNetAmount";
            this.lblTotalNetAmount.Size = new System.Drawing.Size(33, 16);
            this.lblTotalNetAmount.TabIndex = 66;
            this.lblTotalNetAmount.Text = "0.00";
            // 
            // lblGrossAmount
            // 
            this.lblGrossAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrossAmount.AutoSize = true;
            this.lblGrossAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossAmount.ForeColor = System.Drawing.Color.Black;
            this.lblGrossAmount.Location = new System.Drawing.Point(170, 340);
            this.lblGrossAmount.Name = "lblGrossAmount";
            this.lblGrossAmount.Size = new System.Drawing.Size(33, 16);
            this.lblGrossAmount.TabIndex = 65;
            this.lblGrossAmount.Text = "0.00";
            // 
            // lblDiscAmount
            // 
            this.lblDiscAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiscAmount.AutoSize = true;
            this.lblDiscAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscAmount.Location = new System.Drawing.Point(170, 366);
            this.lblDiscAmount.Name = "lblDiscAmount";
            this.lblDiscAmount.Size = new System.Drawing.Size(33, 16);
            this.lblDiscAmount.TabIndex = 64;
            this.lblDiscAmount.Text = "0.00";
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
            this.cmbToTime.Location = new System.Drawing.Point(639, 95);
            this.cmbToTime.Name = "cmbToTime";
            this.cmbToTime.Size = new System.Drawing.Size(96, 23);
            this.cmbToTime.TabIndex = 74;
            this.cmbToTime.SelectedIndexChanged += new System.EventHandler(this.cmbToTime_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(606, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 15);
            this.label12.TabIndex = 73;
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
            this.cmbFromTime.Location = new System.Drawing.Point(507, 95);
            this.cmbFromTime.Name = "cmbFromTime";
            this.cmbFromTime.Size = new System.Drawing.Size(93, 23);
            this.cmbFromTime.TabIndex = 72;
            this.cmbFromTime.SelectedIndexChanged += new System.EventHandler(this.cmbFromTime_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(457, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 71;
            this.label4.Text = "Time:";
            // 
            // cmbTransType
            // 
            this.cmbTransType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTransType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTransType.ForeColor = System.Drawing.Color.Black;
            this.cmbTransType.FormattingEnabled = true;
            this.cmbTransType.Location = new System.Drawing.Point(123, 97);
            this.cmbTransType.Name = "cmbTransType";
            this.cmbTransType.Size = new System.Drawing.Size(131, 23);
            this.cmbTransType.TabIndex = 76;
            this.cmbTransType.SelectedIndexChanged += new System.EventHandler(this.cmbTransType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(9, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 77;
            this.label6.Text = "Trans. Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(9, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 81;
            this.label7.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.ForeColor = System.Drawing.Color.Black;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(121, 29);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(131, 23);
            this.cmbBranch.TabIndex = 80;
            this.cmbBranch.SelectionChangeCommitted += new System.EventHandler(this.cmbBranch_SelectionChangeCommitted);
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(11, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 79;
            this.label13.Text = "Warehouse:";
            // 
            // cmbWhse
            // 
            this.cmbWhse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbWhse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWhse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWhse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbWhse.FormattingEnabled = true;
            this.cmbWhse.Location = new System.Drawing.Point(123, 61);
            this.cmbWhse.Name = "cmbWhse";
            this.cmbWhse.Size = new System.Drawing.Size(131, 23);
            this.cmbWhse.TabIndex = 78;
            this.cmbWhse.SelectionChangeCommitted += new System.EventHandler(this.cmbWhse_SelectionChangeCommitted);
            this.cmbWhse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbWhse_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(606, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 85;
            this.label5.Text = "To:";
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(639, 63);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(96, 22);
            this.dtToDate.TabIndex = 84;
            this.dtToDate.CloseUp += new System.EventHandler(this.dtToDate_CloseUp);
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DimGray;
            this.label21.Location = new System.Drawing.Point(457, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 16);
            this.label21.TabIndex = 83;
            this.label21.Text = "Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(504, 63);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(96, 22);
            this.dtFromDate.TabIndex = 82;
            this.dtFromDate.CloseUp += new System.EventHandler(this.dtFromDate_CloseUp);
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 127);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(723, 199);
            this.gridControl1.TabIndex = 86;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            this.repositoryItemTextEdit1.Click += new System.EventHandler(this.repositoryItemTextEdit1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ItemSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 465);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbWhse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTransType);
            this.Controls.Add(this.cmbToTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbFromTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalNetAmount);
            this.Controls.Add(this.lblGrossAmount);
            this.Controls.Add(this.lblDiscAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemSalesReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Sales Detailed Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ItemSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalNetAmount;
        private System.Windows.Forms.Label lblGrossAmount;
        private System.Windows.Forms.Label lblDiscAmount;
        internal System.Windows.Forms.ComboBox cmbToTime;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbFromTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTransType;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cmbBranch;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbWhse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}