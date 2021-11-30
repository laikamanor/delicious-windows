namespace DeliciousPartnerApp
{
    partial class Production_IssueProduction_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production_IssueProduction_Items));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whsecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datecreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateupdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClosed = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblReference = new System.Windows.Forms.Label();
            this.btnUpdateSAP = new System.Windows.Forms.Button();
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
            this.btnSearch.Location = new System.Drawing.Point(228, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(23, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 16;
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
            this.doc_id,
            this.objtype,
            this.item_code,
            this.quantity,
            this.uom,
            this.whsecode,
            this.datecreated,
            this.dateupdated,
            this.btnClosed});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(23, 94);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(739, 281);
            this.dgv.TabIndex = 15;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // doc_id
            // 
            this.doc_id.HeaderText = "Doc. ID";
            this.doc_id.Name = "doc_id";
            this.doc_id.ReadOnly = true;
            this.doc_id.Visible = false;
            // 
            // objtype
            // 
            this.objtype.HeaderText = "Obj. Type";
            this.objtype.Name = "objtype";
            this.objtype.ReadOnly = true;
            this.objtype.Visible = false;
            // 
            // item_code
            // 
            this.item_code.HeaderText = "Item Code";
            this.item_code.MinimumWidth = 150;
            this.item_code.Name = "item_code";
            this.item_code.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.MinimumWidth = 100;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // uom
            // 
            this.uom.HeaderText = "U.O.M";
            this.uom.MinimumWidth = 100;
            this.uom.Name = "uom";
            this.uom.ReadOnly = true;
            // 
            // whsecode
            // 
            this.whsecode.HeaderText = "Warehouse";
            this.whsecode.Name = "whsecode";
            this.whsecode.ReadOnly = true;
            this.whsecode.Visible = false;
            // 
            // datecreated
            // 
            this.datecreated.HeaderText = "Date Created";
            this.datecreated.MinimumWidth = 100;
            this.datecreated.Name = "datecreated";
            this.datecreated.ReadOnly = true;
            // 
            // dateupdated
            // 
            this.dateupdated.HeaderText = "Date Updated";
            this.dateupdated.MinimumWidth = 100;
            this.dateupdated.Name = "dateupdated";
            this.dateupdated.ReadOnly = true;
            // 
            // btnClosed
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.btnClosed.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosed.HeaderText = "Action";
            this.btnClosed.MinimumWidth = 100;
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.ReadOnly = true;
            this.btnClosed.Text = "Close";
            this.btnClosed.UseColumnTextForButtonValue = true;
            this.btnClosed.Visible = false;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.DimGray;
            this.lblReference.Location = new System.Drawing.Point(19, 32);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(36, 19);
            this.lblReference.TabIndex = 14;
            this.lblReference.Text = "N/A";
            // 
            // btnUpdateSAP
            // 
            this.btnUpdateSAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSAP.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateSAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSAP.FlatAppearance.BorderSize = 0;
            this.btnUpdateSAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSAP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSAP.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSAP.Location = new System.Drawing.Point(624, 381);
            this.btnUpdateSAP.Name = "btnUpdateSAP";
            this.btnUpdateSAP.Size = new System.Drawing.Size(138, 40);
            this.btnUpdateSAP.TabIndex = 18;
            this.btnUpdateSAP.Text = "Update SAP #";
            this.btnUpdateSAP.UseVisualStyleBackColor = false;
            this.btnUpdateSAP.Click += new System.EventHandler(this.btnUpdateSAP_Click);
            // 
            // Production_IssueProduction_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 445);
            this.Controls.Add(this.btnUpdateSAP);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblReference);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Production_IssueProduction_Items";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue For Production Details";
            this.Load += new System.EventHandler(this.Production_IssueProduction_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn objtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn whsecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateupdated;
        private System.Windows.Forms.DataGridViewButtonColumn btnClosed;
        private System.Windows.Forms.Button btnUpdateSAP;
    }
}