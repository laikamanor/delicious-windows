namespace DeliciousPartnerApp
{
    partial class CashTransactionReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashTransactionReport));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.transdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salestype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymenttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbCashier = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblNoDataFound = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComission = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCashOut = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblGCert = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.lblEpay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBankDeposit = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUsedADV = new System.Windows.Forms.Label();
            this.lblADVCash = new System.Windows.Forms.Label();
            this.lblCashSales = new System.Windows.Forms.Label();
            this.lblCashOnHand = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbWhse = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.transdate,
            this.reference,
            this.amount,
            this.cust_code,
            this.salestype,
            this.paymenttype,
            this.username,
            this.url});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.Gray;
            this.dgv.Location = new System.Drawing.Point(24, 222);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 10;
            this.dgv.Size = new System.Drawing.Size(739, 248);
            this.dgv.TabIndex = 2;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
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
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // cust_code
            // 
            this.cust_code.HeaderText = "Cust. Code";
            this.cust_code.Name = "cust_code";
            this.cust_code.ReadOnly = true;
            // 
            // salestype
            // 
            this.salestype.HeaderText = "Sales Type";
            this.salestype.Name = "salestype";
            this.salestype.ReadOnly = true;
            // 
            // paymenttype
            // 
            this.paymenttype.HeaderText = "Payment Type";
            this.paymenttype.Name = "paymenttype";
            this.paymenttype.ReadOnly = true;
            // 
            // username
            // 
            this.username.HeaderText = "Processed By";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            this.url.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(21, 98);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 15);
            this.label20.TabIndex = 16;
            this.label20.Text = "Cashier:";
            // 
            // cmbCashier
            // 
            this.cmbCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbCashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCashier.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbCashier.ForeColor = System.Drawing.Color.Black;
            this.cmbCashier.FormattingEnabled = true;
            this.cmbCashier.Location = new System.Drawing.Point(133, 95);
            this.cmbCashier.Name = "cmbCashier";
            this.cmbCashier.Size = new System.Drawing.Size(131, 23);
            this.cmbCashier.TabIndex = 14;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Gray;
            this.label21.Location = new System.Drawing.Point(557, 162);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 15);
            this.label21.TabIndex = 19;
            this.label21.Text = "To Date:";
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTo.CustomFormat = "yyyy-MM-dd";
            this.dtTo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(646, 156);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(117, 21);
            this.dtTo.TabIndex = 18;
            //this.dtTo.CloseUp += new System.EventHandler(this.dtTo_CloseUp);
            // 
            // lblNoDataFound
            // 
            this.lblNoDataFound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoDataFound.AutoSize = true;
            this.lblNoDataFound.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataFound.ForeColor = System.Drawing.Color.DimGray;
            this.lblNoDataFound.Location = new System.Drawing.Point(360, 340);
            this.lblNoDataFound.Name = "lblNoDataFound";
            this.lblNoDataFound.Size = new System.Drawing.Size(105, 18);
            this.lblNoDataFound.TabIndex = 20;
            this.lblNoDataFound.Text = "No data found";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblComission);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblCashOut);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblGCert);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblEpay);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblBankDeposit);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblUsedADV);
            this.panel1.Controls.Add(this.lblADVCash);
            this.panel1.Controls.Add(this.lblCashSales);
            this.panel1.Controls.Add(this.lblCashOnHand);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(22, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 168);
            this.panel1.TabIndex = 21;
            // 
            // lblComission
            // 
            this.lblComission.AutoSize = true;
            this.lblComission.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComission.ForeColor = System.Drawing.Color.Black;
            this.lblComission.Location = new System.Drawing.Point(568, 107);
            this.lblComission.Name = "lblComission";
            this.lblComission.Size = new System.Drawing.Size(33, 16);
            this.lblComission.TabIndex = 58;
            this.lblComission.Text = "0.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(378, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 16);
            this.label15.TabIndex = 57;
            this.label15.Text = "Commission:";
            // 
            // lblCashOut
            // 
            this.lblCashOut.AutoSize = true;
            this.lblCashOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashOut.ForeColor = System.Drawing.Color.Black;
            this.lblCashOut.Location = new System.Drawing.Point(568, 76);
            this.lblCashOut.Name = "lblCashOut";
            this.lblCashOut.Size = new System.Drawing.Size(33, 16);
            this.lblCashOut.TabIndex = 56;
            this.lblCashOut.Text = "0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(378, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 16);
            this.label14.TabIndex = 55;
            this.label14.Text = "Cashout:";
            // 
            // lblGCert
            // 
            this.lblGCert.AutoSize = true;
            this.lblGCert.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGCert.ForeColor = System.Drawing.Color.Black;
            this.lblGCert.Location = new System.Drawing.Point(568, 47);
            this.lblGCert.Name = "lblGCert";
            this.lblGCert.Size = new System.Drawing.Size(33, 16);
            this.lblGCert.TabIndex = 54;
            this.lblGCert.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(378, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "GCert:";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefresh.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.FlatAppearance.BorderSize = 0;
            this.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.ForeColor = System.Drawing.Color.White;
            this.btnrefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Image")));
            this.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Location = new System.Drawing.Point(664, 649);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(97, 30);
            this.btnrefresh.TabIndex = 52;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefresh.UseVisualStyleBackColor = false;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // lblEpay
            // 
            this.lblEpay.AutoSize = true;
            this.lblEpay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpay.ForeColor = System.Drawing.Color.Black;
            this.lblEpay.Location = new System.Drawing.Point(568, 19);
            this.lblEpay.Name = "lblEpay";
            this.lblEpay.Size = new System.Drawing.Size(33, 16);
            this.lblEpay.TabIndex = 13;
            this.lblEpay.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(378, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total Electronic Payment:";
            // 
            // lblBankDeposit
            // 
            this.lblBankDeposit.AutoSize = true;
            this.lblBankDeposit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankDeposit.ForeColor = System.Drawing.Color.Black;
            this.lblBankDeposit.Location = new System.Drawing.Point(244, 108);
            this.lblBankDeposit.Name = "lblBankDeposit";
            this.lblBankDeposit.Size = new System.Drawing.Size(33, 16);
            this.lblBankDeposit.TabIndex = 11;
            this.lblBankDeposit.Text = "0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(14, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Total Payment From Bank Deposit:";
            // 
            // lblUsedADV
            // 
            this.lblUsedADV.AutoSize = true;
            this.lblUsedADV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedADV.ForeColor = System.Drawing.Color.Black;
            this.lblUsedADV.Location = new System.Drawing.Point(244, 137);
            this.lblUsedADV.Name = "lblUsedADV";
            this.lblUsedADV.Size = new System.Drawing.Size(33, 16);
            this.lblUsedADV.TabIndex = 9;
            this.lblUsedADV.Text = "0.00";
            // 
            // lblADVCash
            // 
            this.lblADVCash.AutoSize = true;
            this.lblADVCash.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblADVCash.ForeColor = System.Drawing.Color.Black;
            this.lblADVCash.Location = new System.Drawing.Point(244, 77);
            this.lblADVCash.Name = "lblADVCash";
            this.lblADVCash.Size = new System.Drawing.Size(33, 16);
            this.lblADVCash.TabIndex = 8;
            this.lblADVCash.Text = "0.00";
            // 
            // lblCashSales
            // 
            this.lblCashSales.AutoSize = true;
            this.lblCashSales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashSales.ForeColor = System.Drawing.Color.Black;
            this.lblCashSales.Location = new System.Drawing.Point(244, 45);
            this.lblCashSales.Name = "lblCashSales";
            this.lblCashSales.Size = new System.Drawing.Size(33, 16);
            this.lblCashSales.TabIndex = 6;
            this.lblCashSales.Text = "0.00";
            // 
            // lblCashOnHand
            // 
            this.lblCashOnHand.AutoSize = true;
            this.lblCashOnHand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashOnHand.ForeColor = System.Drawing.Color.Black;
            this.lblCashOnHand.Location = new System.Drawing.Point(243, 17);
            this.lblCashOnHand.Name = "lblCashOnHand";
            this.lblCashOnHand.Size = new System.Drawing.Size(40, 19);
            this.lblCashOnHand.TabIndex = 5;
            this.lblCashOnHand.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(14, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Payment From System Deposit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(14, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Cash Deposit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Cash Payment:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Cash On Hand:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(19, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Sales Type:";
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSalesType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbSalesType.ForeColor = System.Drawing.Color.Black;
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(131, 153);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(131, 23);
            this.cmbSalesType.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(19, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Payment Type:";
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaymentType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbPaymentType.ForeColor = System.Drawing.Color.Black;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(131, 125);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(131, 23);
            this.cmbPaymentType.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(557, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "From Date:";
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFrom.CustomFormat = "yyyy-MM-dd";
            this.dtFrom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(646, 128);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(117, 21);
            this.dtFrom.TabIndex = 26;
            //this.dtFrom.CloseUp += new System.EventHandler(this.dtFrom_CloseUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(19, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "Branch:";
            // 
            // cmbBranch
            // 
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBranch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbBranch.ForeColor = System.Drawing.Color.Black;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(131, 33);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(131, 23);
            this.cmbBranch.TabIndex = 34;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(21, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 33;
            this.label13.Text = "Warehouse:";
            // 
            // cmbWhse
            // 
            this.cmbWhse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbWhse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWhse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbWhse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWhse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbWhse.ForeColor = System.Drawing.Color.Black;
            this.cmbWhse.FormattingEnabled = true;
            this.cmbWhse.Location = new System.Drawing.Point(133, 65);
            this.cmbWhse.Name = "cmbWhse";
            this.cmbWhse.Size = new System.Drawing.Size(131, 23);
            this.cmbWhse.TabIndex = 32;
            this.cmbWhse.SelectedIndexChanged += new System.EventHandler(this.cmbWhse_SelectedIndexChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(22, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 32);
            this.button2.TabIndex = 77;
            this.button2.Text = "Search Query";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(616, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 32);
            this.button1.TabIndex = 78;
            this.button1.Text = "Search Query";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CashTransactionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 690);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbWhse);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPaymentType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSalesType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNoDataFound);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbCashier);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashTransactionReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Transaction Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox cmbCashier;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblNoDataFound;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBankDeposit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUsedADV;
        private System.Windows.Forms.Label lblADVCash;
        private System.Windows.Forms.Label lblCashSales;
        private System.Windows.Forms.Label lblCashOnHand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEpay;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Button btnrefresh;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbSalesType;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFrom;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbBranch;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbWhse;
        private System.Windows.Forms.Label lblGCert;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCashOut;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblComission;
        private System.Windows.Forms.Label label15;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn salestype;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymenttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button1;
    }
}