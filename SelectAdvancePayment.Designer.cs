namespace DeliciousPartnerApp
{
    partial class SelectAdvancePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectAdvancePayment));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.selectt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountdue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sapnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddAdvancePayment = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
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
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
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
            this.id,
            this.cust_code,
            this.amountdue,
            this.balance,
            this.total_payment,
            this.reference,
            this.sapnumber,
            this.btnEdit});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(24, 92);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(844, 261);
            this.dgv.TabIndex = 6;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // selectt
            // 
            this.selectt.HeaderText = "Select";
            this.selectt.MinimumWidth = 50;
            this.selectt.Name = "selectt";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // cust_code
            // 
            this.cust_code.FillWeight = 118.3799F;
            this.cust_code.HeaderText = "Customer Code";
            this.cust_code.MinimumWidth = 150;
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // amountdue
            // 
            this.amountdue.FillWeight = 92.65804F;
            this.amountdue.HeaderText = "Amount Due";
            this.amountdue.MinimumWidth = 100;
            this.amountdue.Name = "amountdue";
            this.amountdue.ReadOnly = true;
            // 
            // balance
            // 
            this.balance.FillWeight = 91.74239F;
            this.balance.HeaderText = "Balance";
            this.balance.MinimumWidth = 100;
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            // 
            // total_payment
            // 
            this.total_payment.HeaderText = "Total Payment";
            this.total_payment.Name = "total_payment";
            this.total_payment.ReadOnly = true;
            // 
            // reference
            // 
            this.reference.FillWeight = 110.0556F;
            this.reference.HeaderText = "Reference";
            this.reference.MinimumWidth = 150;
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // sapnumber
            // 
            this.sapnumber.FillWeight = 87.16406F;
            this.sapnumber.HeaderText = "SAP";
            this.sapnumber.MinimumWidth = 100;
            this.sapnumber.Name = "sapnumber";
            this.sapnumber.ReadOnly = true;
            this.sapnumber.Visible = false;
            // 
            // btnEdit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.btnEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.HeaderText = "Action";
            this.btnEdit.MinimumWidth = 150;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Text = "Edit Total Payment";
            this.btnEdit.UseColumnTextForButtonValue = true;
            // 
            // btnAddAdvancePayment
            // 
            this.btnAddAdvancePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAdvancePayment.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddAdvancePayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAdvancePayment.FlatAppearance.BorderSize = 0;
            this.btnAddAdvancePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAdvancePayment.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAdvancePayment.ForeColor = System.Drawing.Color.White;
            this.btnAddAdvancePayment.Location = new System.Drawing.Point(722, 67);
            this.btnAddAdvancePayment.Name = "btnAddAdvancePayment";
            this.btnAddAdvancePayment.Size = new System.Drawing.Size(146, 22);
            this.btnAddAdvancePayment.TabIndex = 9;
            this.btnAddAdvancePayment.Text = "Add Deposit";
            this.btnAddAdvancePayment.UseVisualStyleBackColor = false;
            this.btnAddAdvancePayment.Click += new System.EventHandler(this.btnAddAdvancePayment_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(24, 359);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(844, 31);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(229, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(24, 67);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // SelectAdvancePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(892, 452);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAddAdvancePayment);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "SelectAdvancePayment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Deposit";
            this.Load += new System.EventHandler(this.SelectAdvancePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAddAdvancePayment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountdue;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn sapnumber;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
    }
}