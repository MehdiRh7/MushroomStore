
namespace MushroomStore
{
    partial class frmAddMushroom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddMushroom));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMushroomName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMushroomRecord = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMushroomName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(568, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات محصول";
            // 
            // txtMushroomName
            // 
            this.txtMushroomName.Location = new System.Drawing.Point(40, 70);
            this.txtMushroomName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMushroomName.Name = "txtMushroomName";
            this.txtMushroomName.Size = new System.Drawing.Size(405, 27);
            this.txtMushroomName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع قارچ";
            // 
            // btnMushroomRecord
            // 
            this.btnMushroomRecord.BackColor = System.Drawing.Color.LimeGreen;
            this.btnMushroomRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMushroomRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMushroomRecord.Location = new System.Drawing.Point(13, 213);
            this.btnMushroomRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMushroomRecord.Name = "btnMushroomRecord";
            this.btnMushroomRecord.Size = new System.Drawing.Size(568, 40);
            this.btnMushroomRecord.TabIndex = 1;
            this.btnMushroomRecord.Text = "ثبت";
            this.btnMushroomRecord.UseVisualStyleBackColor = false;
            this.btnMushroomRecord.Click += new System.EventHandler(this.btnMushroomRecord_Click);
            // 
            // frmAddMushroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 272);
            this.Controls.Add(this.btnMushroomRecord);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmAddMushroom";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ثبت محصول";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMushroomName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMushroomRecord;
    }
}