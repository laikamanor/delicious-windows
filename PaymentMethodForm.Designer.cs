namespace DeliciousPartnerApp
{
    partial class PaymentMethodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethodForm));
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtSAPNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.DimGray;
            this.Label2.Location = new System.Drawing.Point(49, 37);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(102, 16);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Payment Type:";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPaymentType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaymentType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentType.ForeColor = System.Drawing.Color.Black;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Items.AddRange(new object[] {
            "All",
            "Cash",
            "A.R Sales",
            "A.R Charge"});
            this.cmbPaymentType.Location = new System.Drawing.Point(53, 59);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(380, 24);
            this.cmbPaymentType.TabIndex = 0;
            this.cmbPaymentType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentType_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(49, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(53, 119);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(380, 22);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentType_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtSAPNumber
            // 
            this.txtSAPNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSAPNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSAPNumber.Location = new System.Drawing.Point(53, 177);
            this.txtSAPNumber.MaxLength = 11;
            this.txtSAPNumber.Name = "txtSAPNumber";
            this.txtSAPNumber.Size = new System.Drawing.Size(380, 22);
            this.txtSAPNumber.TabIndex = 2;
            this.txtSAPNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentType_KeyDown);
            this.txtSAPNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSAPNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(49, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "SAP #:";
            // 
            // txtReference
            // 
            this.txtReference.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtReference.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReference.Location = new System.Drawing.Point(54, 231);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(380, 22);
            this.txtReference.TabIndex = 3;
            this.txtReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentType_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(50, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Reference:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(54, 278);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(379, 31);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(97, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "(Option)";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(124, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "(Option if not CASH and Comission)";
            // 
            // PaymentMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(501, 361);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSAPNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbPaymentType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentMethodForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Method Form";
            this.Load += new System.EventHandler(this.PaymentMethodForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbPaymentType;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtSAPNumber;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReference;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button btnSubmit;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label6;
    }
}