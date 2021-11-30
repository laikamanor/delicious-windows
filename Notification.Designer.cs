namespace DeliciousPartnerApp
{
    partial class Notification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDateRead = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAadd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(9, 23);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(36, 19);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "N/A";
            // 
            // lblDateRead
            // 
            this.lblDateRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateRead.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRead.ForeColor = System.Drawing.Color.DimGray;
            this.lblDateRead.Location = new System.Drawing.Point(321, 435);
            this.lblDateRead.Name = "lblDateRead";
            this.lblDateRead.Size = new System.Drawing.Size(516, 23);
            this.lblDateRead.TabIndex = 2;
            this.lblDateRead.Text = "Date Read: DATE_READ";
            this.lblDateRead.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblBody
            // 
            this.lblBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBody.BackColor = System.Drawing.Color.White;
            this.lblBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblBody.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBody.Enabled = false;
            this.lblBody.Location = new System.Drawing.Point(13, 71);
            this.lblBody.Multiline = true;
            this.lblBody.Name = "lblBody";
            this.lblBody.ReadOnly = true;
            this.lblBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lblBody.Size = new System.Drawing.Size(823, 145);
            this.lblBody.TabIndex = 3;
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(13, 461);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(820, 37);
            this.btnDone.TabIndex = 9;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remarks,
            this.date_created});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(13, 251);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(820, 181);
            this.dgv.TabIndex = 10;
            // 
            // remarks
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.remarks.DefaultCellStyle = dataGridViewCellStyle2;
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // date_created
            // 
            this.date_created.HeaderText = "Date Created";
            this.date_created.Name = "date_created";
            this.date_created.ReadOnly = true;
            // 
            // btnAadd
            // 
            this.btnAadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAadd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAadd.FlatAppearance.BorderSize = 0;
            this.btnAadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAadd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAadd.ForeColor = System.Drawing.Color.White;
            this.btnAadd.Location = new System.Drawing.Point(738, 222);
            this.btnAadd.Name = "btnAadd";
            this.btnAadd.Size = new System.Drawing.Size(95, 23);
            this.btnAadd.TabIndex = 11;
            this.btnAadd.Text = "Add Remarks";
            this.btnAadd.UseVisualStyleBackColor = false;
            this.btnAadd.Click += new System.EventHandler(this.btnAadd_Click);
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(848, 531);
            this.Controls.Add(this.btnAadd);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lblDateRead);
            this.Controls.Add(this.lblHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDateRead;
        private System.Windows.Forms.TextBox lblBody;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAadd;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_created;
    }
}