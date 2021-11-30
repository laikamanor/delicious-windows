namespace DeliciousPartnerApp
{
    partial class AddSeries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSeries));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbObjType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWhse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(21, 482);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(315, 41);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(18, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "*Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(21, 132);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(315, 26);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "*Code:";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(21, 73);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(315, 26);
            this.txtCode.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(18, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "*Obj. Type:";
            // 
            // cmbObjType
            // 
            this.cmbObjType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbObjType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbObjType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbObjType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbObjType.ForeColor = System.Drawing.Color.Black;
            this.cmbObjType.FormattingEnabled = true;
            this.cmbObjType.Location = new System.Drawing.Point(21, 253);
            this.cmbObjType.Name = "cmbObjType";
            this.cmbObjType.Size = new System.Drawing.Size(315, 26);
            this.cmbObjType.TabIndex = 3;
            this.cmbObjType.SelectedIndexChanged += new System.EventHandler(this.cmbObjType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(18, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "*Next Num:";
            // 
            // txtNext
            // 
            this.txtNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNext.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNext.Location = new System.Drawing.Point(21, 371);
            this.txtNext.Name = "txtNext";
            this.txtNext.Size = new System.Drawing.Size(315, 26);
            this.txtNext.TabIndex = 5;
            this.txtNext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(18, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "*Start Num:";
            // 
            // txtStart
            // 
            this.txtStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.Location = new System.Drawing.Point(21, 312);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(315, 26);
            this.txtStart.TabIndex = 4;
            this.txtStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(18, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "*End Num:";
            // 
            // txtEnd
            // 
            this.txtEnd.AcceptsReturn = true;
            this.txtEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEnd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnd.Location = new System.Drawing.Point(21, 434);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(315, 26);
            this.txtEnd.TabIndex = 6;
            this.txtEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStart_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(18, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "*Warehouse:";
            // 
            // cmbWhse
            // 
            this.cmbWhse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbWhse.BackColor = System.Drawing.SystemColors.Control;
            this.cmbWhse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWhse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbWhse.FormattingEnabled = true;
            this.cmbWhse.Location = new System.Drawing.Point(21, 192);
            this.cmbWhse.Name = "cmbWhse";
            this.cmbWhse.Size = new System.Drawing.Size(315, 26);
            this.cmbWhse.TabIndex = 29;
            // 
            // AddSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 556);
            this.Controls.Add(this.cmbWhse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbObjType);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSeries";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Series";
            this.Load += new System.EventHandler(this.AddSeries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbObjType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWhse;
    }
}