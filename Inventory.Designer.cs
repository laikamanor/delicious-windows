namespace DeliciousPartnerApp
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begbal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfer_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adjin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adjout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issue_prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pullout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbItemGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
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
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcode,
            this.begbal,
            this.receipt_prod,
            this.received,
            this.transfer_in,
            this.adjin,
            this.total_in,
            this.transferred,
            this.adjout,
            this.issue_prod,
            this.pullout,
            this.sold,
            this.total_out,
            this.available});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.DarkGray;
            this.dgv.Location = new System.Drawing.Point(24, 185);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(811, 147);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // itemcode
            // 
            this.itemcode.FillWeight = 200F;
            this.itemcode.HeaderText = "Item";
            this.itemcode.MinimumWidth = 150;
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // begbal
            // 
            this.begbal.HeaderText = "Beginning";
            this.begbal.MinimumWidth = 100;
            this.begbal.Name = "begbal";
            this.begbal.ReadOnly = true;
            // 
            // receipt_prod
            // 
            this.receipt_prod.HeaderText = "Receipt From Prod.";
            this.receipt_prod.MinimumWidth = 100;
            this.receipt_prod.Name = "receipt_prod";
            this.receipt_prod.ReadOnly = true;
            // 
            // received
            // 
            this.received.HeaderText = "Received";
            this.received.MinimumWidth = 100;
            this.received.Name = "received";
            this.received.ReadOnly = true;
            // 
            // transfer_in
            // 
            this.transfer_in.HeaderText = "Transfer In";
            this.transfer_in.MinimumWidth = 100;
            this.transfer_in.Name = "transfer_in";
            this.transfer_in.ReadOnly = true;
            // 
            // adjin
            // 
            this.adjin.HeaderText = "Adjustment In";
            this.adjin.MinimumWidth = 100;
            this.adjin.Name = "adjin";
            this.adjin.ReadOnly = true;
            // 
            // total_in
            // 
            this.total_in.HeaderText = "Total In";
            this.total_in.MinimumWidth = 100;
            this.total_in.Name = "total_in";
            this.total_in.ReadOnly = true;
            // 
            // transferred
            // 
            this.transferred.HeaderText = "Transfer Out";
            this.transferred.MinimumWidth = 100;
            this.transferred.Name = "transferred";
            this.transferred.ReadOnly = true;
            // 
            // adjout
            // 
            this.adjout.HeaderText = "Adjustment Out";
            this.adjout.MinimumWidth = 100;
            this.adjout.Name = "adjout";
            this.adjout.ReadOnly = true;
            // 
            // issue_prod
            // 
            this.issue_prod.HeaderText = "Issue For Prod.";
            this.issue_prod.MinimumWidth = 100;
            this.issue_prod.Name = "issue_prod";
            this.issue_prod.ReadOnly = true;
            // 
            // pullout
            // 
            this.pullout.HeaderText = "Pull Out";
            this.pullout.MinimumWidth = 100;
            this.pullout.Name = "pullout";
            this.pullout.ReadOnly = true;
            // 
            // sold
            // 
            this.sold.HeaderText = "Sold";
            this.sold.MinimumWidth = 100;
            this.sold.Name = "sold";
            this.sold.ReadOnly = true;
            // 
            // total_out
            // 
            this.total_out.HeaderText = "Total Out";
            this.total_out.MinimumWidth = 100;
            this.total_out.Name = "total_out";
            this.total_out.ReadOnly = true;
            // 
            // available
            // 
            this.available.HeaderText = "Total Available";
            this.available.MinimumWidth = 100;
            this.available.Name = "available";
            this.available.ReadOnly = true;
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
            this.cmbBranches.Location = new System.Drawing.Point(111, 46);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(219, 24);
            this.cmbBranches.TabIndex = 1;
            this.cmbBranches.SelectedIndexChanged += new System.EventHandler(this.cmbBranches_SelectedIndexChanged);
            this.cmbBranches.SelectedValueChanged += new System.EventHandler(this.cmbBranches_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Branch:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(21, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 4;
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
            this.cmbWarehouse.Location = new System.Drawing.Point(111, 82);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(219, 24);
            this.cmbWarehouse.TabIndex = 3;
            this.cmbWarehouse.SelectedValueChanged += new System.EventHandler(this.cmbWarehouse_SelectedValueChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtToDate.CustomFormat = "yyyy-MM-dd";
            this.dtToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(718, 161);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(117, 22);
            this.dtToDate.TabIndex = 5;
            this.dtToDate.CloseUp += new System.EventHandler(this.dtDate_CloseUp);
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(652, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "To Date:";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefresh.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.FlatAppearance.BorderSize = 0;
            this.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.ForeColor = System.Drawing.Color.White;
            this.btnrefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Image")));
            this.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Location = new System.Drawing.Point(738, 338);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(97, 30);
            this.btnrefresh.TabIndex = 52;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefresh.UseVisualStyleBackColor = false;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(24, 158);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(202, 25);
            this.txtSearch.TabIndex = 53;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(226, 158);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(21, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Item Group:";
            // 
            // cmbItemGroup
            // 
            this.cmbItemGroup.BackColor = System.Drawing.SystemColors.Control;
            this.cmbItemGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbItemGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItemGroup.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemGroup.ForeColor = System.Drawing.Color.Black;
            this.cmbItemGroup.FormattingEnabled = true;
            this.cmbItemGroup.Location = new System.Drawing.Point(111, 120);
            this.cmbItemGroup.Name = "cmbItemGroup";
            this.cmbItemGroup.Size = new System.Drawing.Size(219, 24);
            this.cmbItemGroup.TabIndex = 55;
            this.cmbItemGroup.SelectedIndexChanged += new System.EventHandler(this.cmbItemGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(445, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "From Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFromDate.CustomFormat = "yyyy-MM-dd";
            this.dtFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(529, 161);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(117, 22);
            this.dtFromDate.TabIndex = 57;
            this.dtFromDate.CloseUp += new System.EventHandler(this.dtFromDate_CloseUp);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 396);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbItemGroup);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBranches);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbItemGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn begbal;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_prod;
        private System.Windows.Forms.DataGridViewTextBoxColumn received;
        private System.Windows.Forms.DataGridViewTextBoxColumn transfer_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn adjin;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferred;
        private System.Windows.Forms.DataGridViewTextBoxColumn adjout;
        private System.Windows.Forms.DataGridViewTextBoxColumn issue_prod;
        private System.Windows.Forms.DataGridViewTextBoxColumn pullout;
        private System.Windows.Forms.DataGridViewTextBoxColumn sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn available;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFromDate;
    }
}