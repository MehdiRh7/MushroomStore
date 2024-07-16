
namespace MushroomStore
{
    partial class frmSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.rdGram = new System.Windows.Forms.RadioButton();
            this.rdKilo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchMushroom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMushroomType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnMushroomRecord = new System.Windows.Forms.Button();
            this.btnPaid = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.rdGram);
            this.groupBox1.Controls.Add(this.rdKilo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSearchCustomer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomerSelect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSearchMushroom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMushroomType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(670, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات فروش";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(316, 210);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(233, 27);
            this.txtPrice.TabIndex = 22;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(316, 161);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(233, 27);
            this.txtAmount.TabIndex = 21;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(154, 266);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(328, 19);
            this.label15.TabIndex = 20;
            this.label15.Text = "در صورت وارد نکردن ، تاریخ روز جاری ثبت میشود";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 266);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "تاریخ";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(437, 262);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(112, 27);
            this.txtDate.TabIndex = 18;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            // 
            // rdGram
            // 
            this.rdGram.AutoSize = true;
            this.rdGram.Location = new System.Drawing.Point(84, 162);
            this.rdGram.Margin = new System.Windows.Forms.Padding(4);
            this.rdGram.Name = "rdGram";
            this.rdGram.Size = new System.Drawing.Size(145, 23);
            this.rdGram.TabIndex = 17;
            this.rdGram.TabStop = true;
            this.rdGram.Text = "بسته های گرمی";
            this.rdGram.UseVisualStyleBackColor = true;
            // 
            // rdKilo
            // 
            this.rdKilo.AutoSize = true;
            this.rdKilo.Location = new System.Drawing.Point(222, 162);
            this.rdKilo.Margin = new System.Windows.Forms.Padding(4);
            this.rdKilo.Name = "rdKilo";
            this.rdKilo.Size = new System.Drawing.Size(81, 23);
            this.rdKilo.TabIndex = 16;
            this.rdKilo.TabStop = true;
            this.rdKilo.Text = "کیلوگرم";
            this.rdKilo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdKilo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, -4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "label9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "تومان";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(604, 213);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "قیمت";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "مقدار";
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Location = new System.Drawing.Point(6, 109);
            this.txtSearchCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(226, 27);
            this.txtSearchCustomer.TabIndex = 7;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "جستجو";
            // 
            // txtCustomerSelect
            // 
            this.txtCustomerSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCustomerSelect.FormattingEnabled = true;
            this.txtCustomerSelect.Location = new System.Drawing.Point(316, 109);
            this.txtCustomerSelect.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerSelect.Name = "txtCustomerSelect";
            this.txtCustomerSelect.Size = new System.Drawing.Size(233, 27);
            this.txtCustomerSelect.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(557, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "انتخاب مشتری";
            // 
            // txtSearchMushroom
            // 
            this.txtSearchMushroom.Location = new System.Drawing.Point(6, 62);
            this.txtSearchMushroom.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchMushroom.Name = "txtSearchMushroom";
            this.txtSearchMushroom.Size = new System.Drawing.Size(226, 27);
            this.txtSearchMushroom.TabIndex = 3;
            this.txtSearchMushroom.TextChanged += new System.EventHandler(this.txtSearchMushroom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "جستجو";
            // 
            // txtMushroomType
            // 
            this.txtMushroomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMushroomType.FormattingEnabled = true;
            this.txtMushroomType.Location = new System.Drawing.Point(316, 62);
            this.txtMushroomType.Margin = new System.Windows.Forms.Padding(4);
            this.txtMushroomType.Name = "txtMushroomType";
            this.txtMushroomType.Size = new System.Drawing.Size(233, 27);
            this.txtMushroomType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع قارچ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(614, 357);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "مبلغ کل :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(482, 357);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 19);
            this.label11.TabIndex = 2;
            this.label11.Text = "0 تومان";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(342, 357);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 19);
            this.label12.TabIndex = 3;
            this.label12.Text = "مبلغ پرداخت شده :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(118, 357);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "تومان";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 392);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 19);
            this.label14.TabIndex = 6;
            // 
            // btnMushroomRecord
            // 
            this.btnMushroomRecord.BackColor = System.Drawing.Color.LimeGreen;
            this.btnMushroomRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMushroomRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMushroomRecord.Location = new System.Drawing.Point(12, 529);
            this.btnMushroomRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnMushroomRecord.Name = "btnMushroomRecord";
            this.btnMushroomRecord.Size = new System.Drawing.Size(662, 40);
            this.btnMushroomRecord.TabIndex = 7;
            this.btnMushroomRecord.Text = "ثبت";
            this.btnMushroomRecord.UseVisualStyleBackColor = false;
            this.btnMushroomRecord.Click += new System.EventHandler(this.btnMushroomRecord_Click);
            // 
            // btnPaid
            // 
            this.btnPaid.Location = new System.Drawing.Point(16, 348);
            this.btnPaid.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(89, 36);
            this.btnPaid.TabIndex = 8;
            this.btnPaid.Text = "پرداخت";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(19, 416);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(558, 85);
            this.txtDescription.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(592, 449);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 19);
            this.label16.TabIndex = 10;
            this.label16.Text = "توضیحات";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(164, 354);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(171, 27);
            this.txtAmountPaid.TabIndex = 11;
            this.txtAmountPaid.TextChanged += new System.EventHandler(this.txtAmountPaid_TextChanged);
            this.txtAmountPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountPaid_KeyPress);
            this.txtAmountPaid.Leave += new System.EventHandler(this.txtAmountPaid_Leave);
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 593);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.btnMushroomRecord);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSale";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت فروش";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSale_FormClosing);
            this.Load += new System.EventHandler(this.frmSale_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtCustomerSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchMushroom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtMushroomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnMushroomRecord;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.RadioButton rdGram;
        private System.Windows.Forms.RadioButton rdKilo;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAmountPaid;
    }
}