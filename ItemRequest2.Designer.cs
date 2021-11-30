namespace DeliciousPartnerApp
{
    partial class ItemRequest2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemRequest2));
            this.checkDueDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmbToWhse = new System.Windows.Forms.ComboBox();
            this.cmbFromWhse = new System.Windows.Forms.ComboBox();
            this.cmbDocStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.checkTransDate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTransDate = new System.Windows.Forms.DateTimePicker();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_whse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_whse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.due_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // checkDueDate
            // 
            this.checkDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDueDate.AutoSize = true;
            this.checkDueDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDueDate.ForeColor = System.Drawing.Color.Black;
            this.checkDueDate.Location = new System.Drawing.Point(604, 84);
            this.checkDueDate.Name = "checkDueDate";
            this.checkDueDate.Size = new System.Drawing.Size(15, 14);
            this.checkDueDate.TabIndex = 34;
            this.checkDueDate.UseVisualStyleBackColor = true;
            this.checkDueDate.CheckedChanged += new System.EventHandler(this.checkDueDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(625, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Due Date:";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDueDate.CustomFormat = "yyyy-MM-dd";
            this.dtDueDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDueDate.Location = new System.Drawing.Point(741, 79);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(154, 22);
            this.dtDueDate.TabIndex = 32;
            this.dtDueDate.ValueChanged += new System.EventHandler(this.dtDueDate_ValueChanged);
            // 
            // cmbToWhse
            // 
            this.cmbToWhse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbToWhse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbToWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbToWhse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbToWhse.FormattingEnabled = true;
            this.cmbToWhse.Location = new System.Drawing.Point(174, 46);
            this.cmbToWhse.Name = "cmbToWhse";
            this.cmbToWhse.Size = new System.Drawing.Size(154, 24);
            this.cmbToWhse.TabIndex = 30;
            this.cmbToWhse.SelectedIndexChanged += new System.EventHandler(this.cmbToWhse_SelectedIndexChanged);
            this.cmbToWhse.SelectedValueChanged += new System.EventHandler(this.cmbToWhse_SelectedValueChanged);
            // 
            // cmbFromWhse
            // 
            this.cmbFromWhse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbFromWhse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFromWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFromWhse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbFromWhse.FormattingEnabled = true;
            this.cmbFromWhse.Location = new System.Drawing.Point(174, 16);
            this.cmbFromWhse.Name = "cmbFromWhse";
            this.cmbFromWhse.Size = new System.Drawing.Size(154, 24);
            this.cmbFromWhse.TabIndex = 28;
            this.cmbFromWhse.SelectedIndexChanged += new System.EventHandler(this.cmbFromWhse_SelectedIndexChanged);
            this.cmbFromWhse.SelectedValueChanged += new System.EventHandler(this.cmbFromWhse_SelectedValueChanged);
            // 
            // cmbDocStatus
            // 
            this.cmbDocStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDocStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocStatus.FormattingEnabled = true;
            this.cmbDocStatus.Items.AddRange(new object[] {
            "All",
            "Open",
            "Closed",
            "Cancelled"});
            this.cmbDocStatus.Location = new System.Drawing.Point(174, 76);
            this.cmbDocStatus.Name = "cmbDocStatus";
            this.cmbDocStatus.Size = new System.Drawing.Size(154, 24);
            this.cmbDocStatus.TabIndex = 26;
            this.cmbDocStatus.SelectedIndexChanged += new System.EventHandler(this.cmbDocStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(34, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Doc. Status:";
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(414, 221);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 24;
            this.lblNoDataFound.Text = "No data found";
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
            this.id,
            this.transdate,
            this.reference,
            this.from_whse,
            this.to_whse,
            this.due_date,
            this.doc_status,
            this.remarks});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(34, 104);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(861, 281);
            this.dgv.TabIndex = 23;
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(34, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 16);
            this.label13.TabIndex = 72;
            this.label13.Text = "Requestor Whse:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.DimGray;
            this.Label3.Location = new System.Drawing.Point(34, 16);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 16);
            this.Label3.TabIndex = 71;
            this.Label3.Text = "Production Whse:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(803, 391);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 29);
            this.btnRefresh.TabIndex = 100;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // checkTransDate
            // 
            this.checkTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkTransDate.AutoSize = true;
            this.checkTransDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTransDate.ForeColor = System.Drawing.Color.Black;
            this.checkTransDate.Location = new System.Drawing.Point(604, 56);
            this.checkTransDate.Name = "checkTransDate";
            this.checkTransDate.Size = new System.Drawing.Size(15, 14);
            this.checkTransDate.TabIndex = 103;
            this.checkTransDate.UseVisualStyleBackColor = true;
            this.checkTransDate.CheckedChanged += new System.EventHandler(this.checkTransDate_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(625, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "Trans. Date:";
            // 
            // dtTransDate
            // 
            this.dtTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTransDate.CustomFormat = "yyyy-MM-dd";
            this.dtTransDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransDate.Location = new System.Drawing.Point(741, 51);
            this.dtTransDate.Name = "dtTransDate";
            this.dtTransDate.Size = new System.Drawing.Size(154, 22);
            this.dtTransDate.TabIndex = 101;
            this.dtTransDate.ValueChanged += new System.EventHandler(this.dtTransDate_ValueChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // transdate
            // 
            this.transdate.HeaderText = "Trans. Date";
            this.transdate.Name = "transdate";
            this.transdate.ReadOnly = true;
            // 
            // reference
            // 
            this.reference.HeaderText = "Reference";
            this.reference.Name = "reference";
            this.reference.ReadOnly = true;
            // 
            // from_whse
            // 
            this.from_whse.HeaderText = "Production Warehouse";
            this.from_whse.Name = "from_whse";
            this.from_whse.ReadOnly = true;
            // 
            // to_whse
            // 
            this.to_whse.HeaderText = "Requestor Warehouse";
            this.to_whse.Name = "to_whse";
            this.to_whse.ReadOnly = true;
            // 
            // due_date
            // 
            this.due_date.HeaderText = "Due Date";
            this.due_date.Name = "due_date";
            this.due_date.ReadOnly = true;
            // 
            // doc_status
            // 
            this.doc_status.HeaderText = "Doc Status";
            this.doc_status.Name = "doc_status";
            this.doc_status.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // ItemRequest2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.checkTransDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtTransDate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.checkDueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtDueDate);
            this.Controls.Add(this.cmbToWhse);
            this.Controls.Add(this.cmbFromWhse);
            this.Controls.Add(this.cmbDocStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemRequest2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ItemRequest2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkDueDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.ComboBox cmbToWhse;
        private System.Windows.Forms.ComboBox cmbFromWhse;
        private System.Windows.Forms.ComboBox cmbDocStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoDataFound;
        private System.Windows.Forms.DataGridView dgv;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox checkTransDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTransDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_whse;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_whse;
        private System.Windows.Forms.DataGridViewTextBoxColumn due_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}