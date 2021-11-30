namespace DeliciousPartnerApp
{
    partial class Warehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricelist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricelist_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pullout_whse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditPrice = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.pricelist,
            this.pricelist_id,
            this.branch,
            this.code,
            this.namee,
            this.cash_account,
            this.short_account,
            this.pullout_whse,
            this.btnEditPrice,
            this.btnEdit});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(29, 96);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(647, 386);
            this.dgv.TabIndex = 6;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 8;
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
            this.cmbBranches.Location = new System.Drawing.Point(95, 38);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(154, 24);
            this.cmbBranches.TabIndex = 7;
            this.cmbBranches.SelectedIndexChanged += new System.EventHandler(this.cmbBranches_SelectedIndexChanged);
            this.cmbBranches.SelectedValueChanged += new System.EventHandler(this.cmbBranches_SelectedValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(234, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(29, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(546, 71);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 22);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add Warehouse";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 100;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // pricelist
            // 
            this.pricelist.HeaderText = "Price List";
            this.pricelist.MinimumWidth = 150;
            this.pricelist.Name = "pricelist";
            this.pricelist.ReadOnly = true;
            // 
            // pricelist_id
            // 
            this.pricelist_id.HeaderText = "Price List ID";
            this.pricelist_id.MinimumWidth = 100;
            this.pricelist_id.Name = "pricelist_id";
            this.pricelist_id.ReadOnly = true;
            this.pricelist_id.Visible = false;
            // 
            // branch
            // 
            this.branch.HeaderText = "Branch";
            this.branch.MinimumWidth = 150;
            this.branch.Name = "branch";
            this.branch.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "Code";
            this.code.MinimumWidth = 150;
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // namee
            // 
            this.namee.HeaderText = "Name";
            this.namee.MinimumWidth = 150;
            this.namee.Name = "namee";
            this.namee.ReadOnly = true;
            // 
            // cash_account
            // 
            this.cash_account.HeaderText = "Cash Account";
            this.cash_account.MinimumWidth = 100;
            this.cash_account.Name = "cash_account";
            this.cash_account.ReadOnly = true;
            // 
            // short_account
            // 
            this.short_account.HeaderText = "Short Account";
            this.short_account.MinimumWidth = 100;
            this.short_account.Name = "short_account";
            this.short_account.ReadOnly = true;
            // 
            // pullout_whse
            // 
            this.pullout_whse.HeaderText = "Pull Out Warehouse";
            this.pullout_whse.MinimumWidth = 100;
            this.pullout_whse.Name = "pullout_whse";
            this.pullout_whse.ReadOnly = true;
            // 
            // btnEditPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.btnEditPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnEditPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPrice.HeaderText = "Action";
            this.btnEditPrice.MinimumWidth = 100;
            this.btnEditPrice.Name = "btnEditPrice";
            this.btnEditPrice.ReadOnly = true;
            this.btnEditPrice.Text = "Update Price";
            this.btnEditPrice.UseColumnTextForButtonValue = true;
            // 
            // btnEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.btnEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.HeaderText = "Action";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseColumnTextForButtonValue = true;
            // 
            // Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 494);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBranches);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Warehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Warehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricelist;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricelist_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn namee;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn pullout_whse;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditPrice;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
    }
}