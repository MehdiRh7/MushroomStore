using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace MushroomStore
{
    public partial class frmLogin : Form
    {
        public bool a = false;
        public bool aa = false;
        MyContext db = new MyContext();
        ILoginRepository _loginRepository;
        public frmLogin()
        {
            _loginRepository = new LoginRepository(db);
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(aa==true)
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("لطفا نام کاربری را وارد کنید");
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("لطفا رمز عبور را وارد کنید");
                }
                else
                {
                    var login = _loginRepository.GetAllLogins().First();
                    login.UserName = txtUsername.Text;
                    login.Password = txtPassword.Text;
                    _loginRepository.UpdateLogin(login);
                    _loginRepository.Save();
                    MessageBox.Show("نام کاربری و رمز عبور با موفقیت تغییر کرد");
                    DialogResult = DialogResult.OK;
                }
            }
            else if (a == false)
            {
                var logincount = _loginRepository.GetAllLogins().Count();
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("لطفا نام کاربری را وارد کنید");
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("لطفا رمز عبور را وارد کنید");
                }
                else if (logincount == 0)
                {
                    Login lg = new Login()
                    {
                        UserName = "admin",
                        Password = "123"
                    };
                    _loginRepository.InsertLogin(lg);
                    _loginRepository.Save();
                    MessageBox.Show("نام کاربری و رمز عبور را وارد نمایید");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    if (_loginRepository.GetAllLogins().Any(l => l.UserName == txtUsername.Text && l.Password == txtPassword.Text))
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("نام کابری یا رمز عبور اشتباه است");
                    }

                }
            }
            else
            {
                if(_loginRepository.GetAllLogins().Any(l => l.UserName == txtUsername.Text && l.Password == txtPassword.Text))
                {
                    aa = true;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    label3.Text = "نام کاربری و رمز عبور جدید را وارد کنید";
                    label1.Text = "نام کاربری جدید :";
                    label2.Text = "رمز عبور جدید :";
                    label3.ForeColor = Color.DarkGreen;
                    btnLogin.Text="ثبت";
                }
                else
                {
                    MessageBox.Show("نام کابری یا رمز عبور اشتباه است");
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (a == true)
            {
                this.Text = "تغییر نام کاربری و رمز عبور";
                label1.Text = "نام کاربری قبلی :";
                label2.Text = "رمز عبور قبلی :";
                btnLogin.Text = "انجام";
                label3.Text = "نام کاربری و رمز عبور قبلی را وارد کنید";
                label3.ForeColor = Color.DarkRed;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
