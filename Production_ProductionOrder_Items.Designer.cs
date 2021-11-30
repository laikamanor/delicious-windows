namespace DeliciousPartnerApp
{
    partial class Production_ProductionOrder_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production_ProductionOrder_Items));
            this.lblReference = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planned_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.received_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whsecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datecreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateupdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateclosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.close = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClosed = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.DimGray;
            this.lblReference.Location = new System.Drawing.Point(31, 26);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(36, 19);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "N/A";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(240, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 22);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(35, 64);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.ImeModeChanged += new System.EventHandler(this.txtSearch_ImeModeChanged);
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
            this.planned_qty,
            this.received_qty,
            this.uom,
            this.whsecode,
            this.datecreated,
            this.dateupdated,
            this.dateclosed,
            this.close,
            this.remarks,
            this.btnClosed});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(35, 88);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(739, 276);
            this.dgv.TabIndex = 11;
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
            // planned_qty
            // 
            this.planned_qty.HeaderText = "Planned Qty.";
            this.planned_qty.MinimumWidth = 100;
            this.planned_qty.Name = "planned_qty";
            this.planned_qty.ReadOnly = true;
            // 
            // received_qty
            // 
            this.received_qty.HeaderText = "Received Qty.";
            this.received_qty.MinimumWidth = 100;
            this.received_qty.Name = "received_qty";
            this.received_qty.ReadOnly = true;
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
            // dateclosed
            // 
            this.dateclosed.HeaderText = "Date Closed";
            this.dateclosed.MinimumWidth = 100;
            this.dateclosed.Name = "dateclosed";
            this.dateclosed.ReadOnly = true;
            this.dateclosed.Visible = false;
            // 
            // close
            // 
            this.close.HeaderText = "Close";
            this.close.MinimumWidth = 50;
            this.close.Name = "close";
            this.close.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.MinimumWidth = 100;
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
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
            this.btnRefresh.Location = new System.Drawing.Point(682, 370);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 29);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Production_ProductionOrder_Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 434);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblReference);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Production_ProductionOrder_Items";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Order Details";
            this.Load += new System.EventHandler(this.Production_ProductionOrder_Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn objtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn planned_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn received_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn whsecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateupdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateclosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn close;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewButtonColumn btnClosed;
    }
}