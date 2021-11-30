namespace DeliciousPartnerApp
{
    partial class AddAltUOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAltUOM));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAltQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaseQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkDefault = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbAltUOM = new System.Windows.Forms.ComboBox();
            this.lblBaseUom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Alt. UOM:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Alt Quantity:";
            // 
            // txtAltQuantity
            // 
            this.txtAltQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAltQuantity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltQuantity.Location = new System.Drawing.Point(15, 47);
            this.txtAltQuantity.Name = "txtAltQuantity";
            this.txtAltQuantity.Size = new System.Drawing.Size(358, 26);
            this.txtAltQuantity.TabIndex = 18;
            this.txtAltQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBaseQty_KeyDown);
            this.txtAltQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseQty_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Base Quantity:";
            // 
            // txtBaseQty
            // 
            this.txtBaseQty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBaseQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseQty.Location = new System.Drawing.Point(15, 168);
            this.txtBaseQty.Name = "txtBaseQty";
            this.txtBaseQty.Size = new System.Drawing.Size(358, 26);
            this.txtBaseQty.TabIndex = 20;
            this.txtBaseQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBaseQty_KeyDown);
            this.txtBaseQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseQty_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Base UOM:";
            // 
            // checkDefault
            // 
            this.checkDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkDefault.AutoSize = true;
            this.checkDefault.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDefault.Location = new System.Drawing.Point(15, 284);
            this.checkDefault.Name = "checkDefault";
            this.checkDefault.Size = new System.Drawing.Size(76, 22);
            this.checkDefault.TabIndex = 26;
            this.checkDefault.Text = "Default";
            this.checkDefault.UseVisualStyleBackColor = true;
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
            this.btnSubmit.Location = new System.Drawing.Point(12, 312);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(358, 41);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbAltUOM
            // 
            this.cmbAltUOM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbAltUOM.BackColor = System.Drawing.SystemColors.Control;
            this.cmbAltUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAltUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAltUOM.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAltUOM.FormattingEnabled = true;
            this.cmbAltUOM.Location = new System.Drawing.Point(12, 104);
            this.cmbAltUOM.Name = "cmbAltUOM";
            this.cmbAltUOM.Size = new System.Drawing.Size(358, 26);
            this.cmbAltUOM.TabIndex = 28;
            // 
            // lblBaseUom
            // 
            this.lblBaseUom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBaseUom.AutoSize = true;
            this.lblBaseUom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseUom.ForeColor = System.Drawing.Color.Gray;
            this.lblBaseUom.Location = new System.Drawing.Point(12, 238);
            this.lblBaseUom.Name = "lblBaseUom";
            this.lblBaseUom.Size = new System.Drawing.Size(0, 16);
            this.lblBaseUom.TabIndex = 29;
            // 
            // AddAltUOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 391);
            this.Controls.Add(this.lblBaseUom);
            this.Controls.Add(this.cmbAltUOM);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.checkDefault);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAltQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBaseQty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAltUOM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Alt UOM";
            this.Load += new System.EventHandler(this.AddAltUOM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAltQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaseQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkDefault;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbAltUOM;
        private System.Windows.Forms.Label lblBaseUom;
    }
}