
namespace MushroomStore
{
    partial class frmMinus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinus));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebt = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.txtMinus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "مبلغ بدهی ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "کسر";
            // 
            // txtDebt
            // 
            this.txtDebt.Enabled = false;
            this.txtDebt.Location = new System.Drawing.Point(71, 55);
            this.txtDebt.Margin = new System.Windows.Forms.Padding(4);
            this.txtDebt.Name = "txtDebt";
            this.txtDebt.Size = new System.Drawing.Size(187, 27);
            this.txtDebt.TabIndex = 2;
            this.txtDebt.TextChanged += new System.EventHandler(this.txtDebt_TextChanged);
            this.txtDebt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebt_KeyPress);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(144, 194);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(85, 40);
            this.btnMinus.TabIndex = 4;
            this.btnMinus.Text = "اعمال";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // txtMinus
            // 
            this.txtMinus.Location = new System.Drawing.Point(71, 117);
            this.txtMinus.Name = "txtMinus";
            this.txtMinus.Size = new System.Drawing.Size(187, 27);
            this.txtMinus.TabIndex = 5;
            this.txtMinus.TextChanged += new System.EventHandler(this.txtMinus_TextChanged);
            this.txtMinus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinus_KeyPress);
            this.txtMinus.Leave += new System.EventHandler(this.txtMinus_Leave);
            // 
            // frmMinus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 248);
            this.Controls.Add(this.txtMinus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.txtDebt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMinus";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کسر بدهی";
            this.Load += new System.EventHandler(this.frmMinus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebt;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.TextBox txtMinus;
    }
}