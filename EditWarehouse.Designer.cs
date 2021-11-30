namespace DeliciousPartnerApp
{
    partial class EditWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWarehouse));
            this.ISAction = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ISdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIs = new System.Windows.Forms.DataGridView();
            this.dgvURL = new System.Windows.Forms.DataGridView();
            this.URLdescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLCmbAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvURL)).BeginInit();
            this.SuspendLayout();
            // 
            // ISAction
            // 
            this.ISAction.HeaderText = "Action";
            this.ISAction.Name = "ISAction";
            // 
            // ISdescription
            // 
            this.ISdescription.HeaderText = "Description";
            this.ISdescription.Name = "ISdescription";
            this.ISdescription.ReadOnly = true;
            // 
            // dgvIs
            // 
            this.dgvIs.AllowUserToAddRows = false;
            this.dgvIs.AllowUserToDeleteRows = false;
            this.dgvIs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIs.BackgroundColor = System.Drawing.Color.White;
            this.dgvIs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvIs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIs.ColumnHeadersHeight = 40;
            this.dgvIs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISdescription,
            this.ISAction});
            this.dgvIs.EnableHeadersVisualStyles = false;
            this.dgvIs.GridColor = System.Drawing.Color.Gray;
            this.dgvIs.Location = new System.Drawing.Point(314, 196);
            this.dgvIs.Name = "dgvIs";
            this.dgvIs.RowHeadersWidth = 10;
            this.dgvIs.Size = new System.Drawing.Size(294, 267);
            this.dgvIs.TabIndex = 39;
            // 
            // dgvURL
            // 
            this.dgvURL.AllowUserToAddRows = false;
            this.dgvURL.AllowUserToDeleteRows = false;
            this.dgvURL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvURL.BackgroundColor = System.Drawing.Color.White;
            this.dgvURL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvURL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvURL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvURL.ColumnHeadersHeight = 40;
            this.dgvURL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URLdescription,
            this.url,
            this.URLCmbAction});
            this.dgvURL.EnableHeadersVisualStyles = false;
            this.dgvURL.GridColor = System.Drawing.Color.Gray;
            this.dgvURL.Location = new System.Drawing.Point(12, 196);
            this.dgvURL.Name = "dgvURL";
            this.dgvURL.RowHeadersWidth = 10;
            this.dgvURL.Size = new System.Drawing.Size(297, 267);
            this.dgvURL.TabIndex = 38;
            this.dgvURL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvURL_CellClick);
            this.dgvURL.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvURL_DataError_1);
            // 
            // URLdescription
            // 
            this.URLdescription.HeaderText = "Description";
            this.URLdescription.Name = "URLdescription";
            this.URLdescription.ReadOnly = true;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            // 
            // URLCmbAction
            // 
            this.URLCmbAction.HeaderText = "Action";
            this.URLCmbAction.Name = "URLCmbAction";
            this.URLCmbAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(9, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBranch.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.ForeColor = System.Drawing.Color.Black;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(12, 43);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(596, 26);
            this.cmbBranch.TabIndex = 31;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(12, 477);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(596, 41);
            this.btnSubmit.TabIndex = 34;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(12, 164);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(596, 26);
            this.txtName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(12, 105);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(596, 26);
            this.txtCode.TabIndex = 32;
            // 
            // EditWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(623, 552);
            this.Controls.Add(this.dgvIs);
            this.Controls.Add(this.dgvURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditWarehouse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Warehouse";
            this.Load += new System.EventHandler(this.EditWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvURL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISdescription;
        private System.Windows.Forms.DataGridView dgvIs;
        private System.Windows.Forms.DataGridView dgvURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn URLdescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewComboBoxColumn URLCmbAction;
    }
}