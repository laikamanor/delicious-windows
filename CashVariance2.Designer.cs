namespace DeliciousPartnerApp
{
    partial class CashVariance2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashVariance2));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.system_cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual_cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ar_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateSAP = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.checkTransDate = new System.Windows.Forms.CheckBox();
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
            this.btnSearch.Location = new System.Drawing.Point(233, 75);
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
            this.txtSearch.Location = new System.Drawing.Point(28, 75);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.reference,
            this.transdate,
            this.system_cash,
            this.actual_cash,
            this.variance,
            this.ar_number,
            this.ip_number,
            this.branch,
            this.btnUpdateSAP});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(28, 99);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(750, 283);
            this.dgv.TabIndex = 8;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // reference
            // 
            this.reference.FillWeight = 609.1371F;
            this.reference.HeaderText = "Reference";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // transdate
            // 
            this.transdate.FillWeight = 27.26613F;
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.MinimumWidth = 150;
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // system_cash
            // 
            this.system_cash.FillWeight = 27.26613F;
            this.system_cash.HeaderText = "System Cash";
            this.system_cash.MinimumWidth = 100;
            this.system_cash.Name = "system_cash";
            this.system_cash.ReadOnly = true;
            // 
            // actual_cash
            // 
            this.actual_cash.FillWeight = 27.26613F;
            this.actual_cash.HeaderText = "Actual Cash";
            this.actual_cash.MinimumWidth = 100;
            this.actual_cash.Name = "actual_cash";
            this.actual_cash.ReadOnly = true;
            // 
            // variance
            // 
            this.variance.FillWeight = 27.26613F;
            this.variance.HeaderText = "Variance";
            this.variance.MinimumWidth = 100;
            this.variance.Name = "variance";
            this.variance.ReadOnly = true;
            // 
            // ar_number
            // 
            this.ar_number.FillWeight = 27.26613F;
            this.ar_number.HeaderText = "AR #";
            this.ar_number.MinimumWidth = 100;
            this.ar_number.Name = "ar_number";
            this.ar_number.ReadOnly = true;
            // 
            // ip_number
            // 
            this.ip_number.FillWeight = 27.26613F;
            this.ip_number.HeaderText = "IP #";
            this.ip_number.MinimumWidth = 100;
            this.ip_number.Name = "ip_number";
            this.ip_number.ReadOnly = true;
            // 
            // branch
            // 
            this.branch.FillWeight = 27.26613F;
            this.branch.HeaderText = "Branch";
            this.branch.MinimumWidth = 150;
            this.branch.Name = "branch";
            this.branch.ReadOnly = true;
            // 
            // btnUpdateSAP
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSAP.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnUpdateSAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSAP.HeaderText = "Action";
            this.btnUpdateSAP.MinimumWidth = 150;
            this.btnUpdateSAP.Name = "btnUpdateSAP";
            this.btnUpdateSAP.ReadOnly = true;
            this.btnUpdateSAP.Text = "Update SAP #";
            this.btnUpdateSAP.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(610, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date:";
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtDate.CustomFormat = "yyyy-MM-dd";
            this.dtDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(671, 75);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(107, 22);
            this.dtDate.TabIndex = 11;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Branch:";
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
            this.cmbBranch.Location = new System.Drawing.Point(115, 31);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(154, 24);
            this.cmbBranch.TabIndex = 13;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // checkTransDate
            // 
            this.checkTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTransDate.AutoSize = true;
            this.checkTransDate.Location = new System.Drawing.Point(589, 78);
            this.checkTransDate.Name = "checkTransDate";
            this.checkTransDate.Size = new System.Drawing.Size(15, 14);
            this.checkTransDate.TabIndex = 15;
            this.checkTransDate.UseVisualStyleBackColor = true;
            this.checkTransDate.CheckedChanged += new System.EventHandler(this.checkTransDate_CheckedChanged);
            // 
            // CashVariance2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 411);
            this.Controls.Add(this.checkTransDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashVariance2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CashVariance2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.CheckBox checkTransDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn system_cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual_cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn variance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ar_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch;
        private System.Windows.Forms.DataGridViewButtonColumn btnUpdateSAP;
    }
}