namespace DeliciousPartnerApp
{
    partial class AddCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustomer));
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middle_initial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.landline_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddCustomerDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(22, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Customer Type:";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomerType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomerType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerType.ForeColor = System.Drawing.Color.Black;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(25, 180);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(620, 26);
            this.cmbCustomerType.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(22, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(25, 117);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(620, 26);
            this.txtName.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(25, 53);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(620, 26);
            this.txtCode.TabIndex = 28;
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
            this.btnSubmit.Location = new System.Drawing.Point(25, 528);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(620, 41);
            this.btnSubmit.TabIndex = 43;
            this.btnSubmit.Text = "Add";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.first_name,
            this.middle_initial,
            this.last_name,
            this.birthdate,
            this.landline_number,
            this.mobile_number,
            this.email_address,
            this.address});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(25, 252);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(620, 261);
            this.dgv.TabIndex = 44;
            // 
            // first_name
            // 
            this.first_name.HeaderText = "First Name";
            this.first_name.MinimumWidth = 100;
            this.first_name.Name = "first_name";
            this.first_name.ReadOnly = true;
            // 
            // middle_initial
            // 
            this.middle_initial.HeaderText = "Middle Initial";
            this.middle_initial.MinimumWidth = 100;
            this.middle_initial.Name = "middle_initial";
            this.middle_initial.ReadOnly = true;
            // 
            // last_name
            // 
            this.last_name.HeaderText = "Last Name";
            this.last_name.MinimumWidth = 100;
            this.last_name.Name = "last_name";
            this.last_name.ReadOnly = true;
            // 
            // birthdate
            // 
            this.birthdate.HeaderText = "Birthdate";
            this.birthdate.MinimumWidth = 100;
            this.birthdate.Name = "birthdate";
            this.birthdate.ReadOnly = true;
            // 
            // landline_number
            // 
            this.landline_number.HeaderText = "Landline No.";
            this.landline_number.MinimumWidth = 100;
            this.landline_number.Name = "landline_number";
            this.landline_number.ReadOnly = true;
            // 
            // mobile_number
            // 
            this.mobile_number.HeaderText = "Mobile No.";
            this.mobile_number.MinimumWidth = 100;
            this.mobile_number.Name = "mobile_number";
            this.mobile_number.ReadOnly = true;
            // 
            // email_address
            // 
            this.email_address.HeaderText = "Email Address";
            this.email_address.MinimumWidth = 100;
            this.email_address.Name = "email_address";
            this.email_address.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.MinimumWidth = 100;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(22, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Customer Details:";
            // 
            // btnAddCustomerDetails
            // 
            this.btnAddCustomerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCustomerDetails.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddCustomerDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomerDetails.FlatAppearance.BorderSize = 0;
            this.btnAddCustomerDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomerDetails.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomerDetails.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomerDetails.Location = new System.Drawing.Point(478, 221);
            this.btnAddCustomerDetails.Name = "btnAddCustomerDetails";
            this.btnAddCustomerDetails.Size = new System.Drawing.Size(167, 28);
            this.btnAddCustomerDetails.TabIndex = 46;
            this.btnAddCustomerDetails.Text = "Add Customer Details";
            this.btnAddCustomerDetails.UseVisualStyleBackColor = false;
            this.btnAddCustomerDetails.Click += new System.EventHandler(this.btnAddCustomerDetails_Click);
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 620);
            this.Controls.Add(this.btnAddCustomerDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCustomer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Customer";
            this.Load += new System.EventHandler(this.AddCustomer_Load);
            this.SizeChanged += new System.EventHandler(this.AddCustomer_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddCustomerDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn middle_initial;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn landline_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
    }
}