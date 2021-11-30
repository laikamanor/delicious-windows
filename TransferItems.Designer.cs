namespace DeliciousPartnerApp
{
    partial class TransferItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferItems));
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTransDate = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblDocumentStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblToWhse = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualrec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from_whse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.AllowUserToDeleteRows = false;
            this.dgvitems.AllowUserToResizeRows = false;
            this.dgvitems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvitems.BackgroundColor = System.Drawing.Color.White;
            this.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvitems.ColumnHeadersHeight = 40;
            this.dgvitems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.transfer_id,
            this.itemname,
            this.quantity,
            this.price,
            this.actualrec,
            this.variance,
            this.from_whse});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvitems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvitems.EnableHeadersVisualStyles = false;
            this.dgvitems.GridColor = System.Drawing.Color.Gray;
            this.dgvitems.Location = new System.Drawing.Point(12, 93);
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.RowHeadersWidth = 10;
            this.dgvitems.Size = new System.Drawing.Size(773, 287);
            this.dgvitems.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Reference:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Document Status:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(590, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Transaction Date:";
            // 
            // lblTransDate
            // 
            this.lblTransDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransDate.AutoSize = true;
            this.lblTransDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransDate.ForeColor = System.Drawing.Color.Black;
            this.lblTransDate.Location = new System.Drawing.Point(713, 40);
            this.lblTransDate.Name = "lblTransDate";
            this.lblTransDate.Size = new System.Drawing.Size(72, 16);
            this.lblTransDate.TabIndex = 63;
            this.lblTransDate.Text = "0000-00-00";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.Black;
            this.lblReference.Location = new System.Drawing.Point(134, 40);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(30, 16);
            this.lblReference.TabIndex = 64;
            this.lblReference.Text = "N/A";
            // 
            // lblDocumentStatus
            // 
            this.lblDocumentStatus.AutoSize = true;
            this.lblDocumentStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentStatus.ForeColor = System.Drawing.Color.Black;
            this.lblDocumentStatus.Location = new System.Drawing.Point(134, 74);
            this.lblDocumentStatus.Name = "lblDocumentStatus";
            this.lblDocumentStatus.Size = new System.Drawing.Size(30, 16);
            this.lblDocumentStatus.TabIndex = 65;
            this.lblDocumentStatus.Text = "N/A";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(636, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 41);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblToWhse
            // 
            this.lblToWhse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToWhse.AutoSize = true;
            this.lblToWhse.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToWhse.ForeColor = System.Drawing.Color.Black;
            this.lblToWhse.Location = new System.Drawing.Point(713, 74);
            this.lblToWhse.Name = "lblToWhse";
            this.lblToWhse.Size = new System.Drawing.Size(30, 16);
            this.lblToWhse.TabIndex = 68;
            this.lblToWhse.Text = "N/A";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(590, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 67;
            this.label5.Text = "To Warehouse:";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(481, 386);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 41);
            this.btnPrint.TabIndex = 69;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // transfer_id
            // 
            this.transfer_id.HeaderText = "ID";
            this.transfer_id.Name = "transfer_id";
            this.transfer_id.ReadOnly = true;
            this.transfer_id.Visible = false;
            // 
            // itemname
            // 
            this.itemname.HeaderText = "Item";
            this.itemname.Name = "itemname";
            this.itemname.ReadOnly = true;
            // 
            // quantity
            // 
            dataGridViewCellStyle2.Format = "n2";
            this.quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            dataGridViewCellStyle3.Format = "n2";
            this.price.DefaultCellStyle = dataGridViewCellStyle3;
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // actualrec
            // 
            dataGridViewCellStyle4.Format = "n2";
            this.actualrec.DefaultCellStyle = dataGridViewCellStyle4;
            this.actualrec.HeaderText = "Actual Received";
            this.actualrec.Name = "actualrec";
            this.actualrec.ReadOnly = true;
            // 
            // variance
            // 
            dataGridViewCellStyle5.Format = "n2";
            this.variance.DefaultCellStyle = dataGridViewCellStyle5;
            this.variance.HeaderText = "Variance";
            this.variance.Name = "variance";
            this.variance.ReadOnly = true;
            // 
            // from_whse
            // 
            this.from_whse.HeaderText = "From Whse";
            this.from_whse.Name = "from_whse";
            this.from_whse.ReadOnly = true;
            this.from_whse.Visible = false;
            // 
            // TransferItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblToWhse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDocumentStatus);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblTransDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvitems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransferItems";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Items";
            this.Load += new System.EventHandler(this.TransferItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvitems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTransDate;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label lblDocumentStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblToWhse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transfer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualrec;
        private System.Windows.Forms.DataGridViewTextBoxColumn variance;
        private System.Windows.Forms.DataGridViewTextBoxColumn from_whse;
    }
}