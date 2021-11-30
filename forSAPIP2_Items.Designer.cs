namespace DeliciousPartnerApp
{
    partial class forSAPIP2_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forSAPIP2_Items));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateSAP = new System.Windows.Forms.Button();
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
            this.payment_id,
            this.payment_type,
            this.amount});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(25, 27);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(661, 316);
            this.dgv.TabIndex = 3;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // payment_id
            // 
            this.payment_id.HeaderText = "Payment ID";
            this.payment_id.Name = "payment_id";
            this.payment_id.ReadOnly = true;
            this.payment_id.Visible = false;
            // 
            // payment_type
            // 
            this.payment_type.HeaderText = "Payment Type";
            this.payment_type.Name = "payment_type";
            this.payment_type.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(316, 145);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 14;
            this.lblNoDataFound.Text = "No data found";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(124, 346);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(33, 16);
            this.lblTotalAmount.TabIndex = 15;
            this.lblTotalAmount.Text = "0.00";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(22, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Total Amount:";
            // 
            // btnUpdateSAP
            // 
            this.btnUpdateSAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSAP.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateSAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSAP.FlatAppearance.BorderSize = 0;
            this.btnUpdateSAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSAP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSAP.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSAP.Location = new System.Drawing.Point(541, 349);
            this.btnUpdateSAP.Name = "btnUpdateSAP";
            this.btnUpdateSAP.Size = new System.Drawing.Size(145, 36);
            this.btnUpdateSAP.TabIndex = 17;
            this.btnUpdateSAP.Text = "Update SAP #";
            this.btnUpdateSAP.UseVisualStyleBackColor = false;
            this.btnUpdateSAP.Click += new System.EventHandler(this.btnUpdateSAP_Click);
            // 
            // forSAPIP2_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(716, 453);
            this.Controls.Add(this.btnUpdateSAP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "forSAPIP2_Items";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "For SAP IP";
            this.Load += new System.EventHandler(this.forSAPIP2_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblNoDataFound;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateSAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}