namespace DeliciousPartnerApp
{
    partial class AltUOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltUOM));
            this.btnAddAltUom = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAltUom
            // 
            this.btnAddAltUom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAltUom.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddAltUom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAltUom.FlatAppearance.BorderSize = 0;
            this.btnAddAltUom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAltUom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAltUom.ForeColor = System.Drawing.Color.White;
            this.btnAddAltUom.Location = new System.Drawing.Point(695, 46);
            this.btnAddAltUom.Name = "btnAddAltUom";
            this.btnAddAltUom.Size = new System.Drawing.Size(108, 22);
            this.btnAddAltUom.TabIndex = 16;
            this.btnAddAltUom.Text = "Add Alt UOM";
            this.btnAddAltUom.UseVisualStyleBackColor = false;
            this.btnAddAltUom.Click += new System.EventHandler(this.btnAddAltUom_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(226, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(21, 46);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 14;
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
            this.alt_qty,
            this.alt_uom,
            this.base_qty,
            this.base_uom,
            this.defaultt});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(21, 70);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(782, 391);
            this.dgv.TabIndex = 13;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
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
            this.doc_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.doc_id.HeaderText = "Doc ID";
            this.doc_id.Name = "doc_id";
            this.doc_id.ReadOnly = true;
            this.doc_id.Visible = false;
            this.doc_id.Width = 193;
            // 
            // alt_qty
            // 
            this.alt_qty.HeaderText = "Alt Qty.";
            this.alt_qty.Name = "alt_qty";
            this.alt_qty.ReadOnly = true;
            // 
            // alt_uom
            // 
            this.alt_uom.HeaderText = "Alt UOM";
            this.alt_uom.Name = "alt_uom";
            this.alt_uom.ReadOnly = true;
            // 
            // base_qty
            // 
            this.base_qty.HeaderText = "Base Qty.";
            this.base_qty.Name = "base_qty";
            this.base_qty.ReadOnly = true;
            // 
            // base_uom
            // 
            this.base_uom.HeaderText = "Base UOM";
            this.base_uom.Name = "base_uom";
            this.base_uom.ReadOnly = true;
            // 
            // defaultt
            // 
            this.defaultt.HeaderText = "Default";
            this.defaultt.Name = "defaultt";
            this.defaultt.ReadOnly = true;
            // 
            // AltUOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 492);
            this.Controls.Add(this.btnAddAltUom);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltUOM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alt UOM";
            this.Load += new System.EventHandler(this.AltUOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAltUom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultt;
    }
}