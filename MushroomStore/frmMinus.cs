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
    public partial class frmMinus : Form
    {
        MyContext db = new MyContext();
        public bool a = false;
        public bool aa = false;
        public int id = 0;
        public int minus;
        ICustomerRepository _customerRepository;
        ISellerRepository _sellerRepository;
        ISaleHistoryRepository _saleHistoryRepository;
        public frmMinus()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository(db);
            _sellerRepository = new SellerRepository(db);
            _saleHistoryRepository = new SaleHistoryRepository(db);
        }

        private void frmMinus_Load(object sender, EventArgs e)
        {
            if (aa == false)
            {
                if (a == false)
                {
                    var customer = _customerRepository.GetCustomerById(id);
                    txtDebt.Text = customer.debt.ToString();
                }
                else
                {
                    var seller = _sellerRepository.GetSellerById(id);
                    txtDebt.Text = seller.debt.ToString();
                }
            }
            else
            {
                this.Text = "کسر طلب";
                label1.Text = "مبلغ طلب";
                if (a == false)
                {
                    var customer = _customerRepository.GetCustomerById(id);
                    txtDebt.Text = customer.credit.ToString();
                }
                else
                {
                    var seller = _sellerRepository.GetSellerById(id);
                    txtDebt.Text = seller.credit.ToString();
                }
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            
            frmDebtsCredts frm = new frmDebtsCredts();
            if (txtMinus.Text.Replace(",", "") == "")
            {
                MessageBox.Show("لطفا مبلغ کسر را وارد کنید");
            }
            else if (aa == false)
            {
                if (a == false)
                {
                    var customer = _customerRepository.GetCustomerById(id);
                    if (customer.debt >= int.Parse(txtMinus.Text.Replace(",", "")))
                    {
                        customer.debt -= (int)int.Parse(txtMinus.Text.Replace(",", ""));
                                               
                        minus = (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        _customerRepository.UpdateCustomer(customer);
                        _customerRepository.Save();
                        MessageBox.Show("مبلغ خواسته شده کسر گردید");
                        
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("مبلغ خواسته شده بیشتر از مبلغ بدهی است");
                    }
                }
                else
                {
                    var seller = _sellerRepository.GetSellerById(id);
                    if (seller.debt >= int.Parse(txtMinus.Text.Replace(",", "")))
                    {
                        seller.debt -= (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        minus = (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        _sellerRepository.UpdateSeller(seller);
                        _sellerRepository.Save();
                        MessageBox.Show("مبلغ خواسته شده کسر گردید");
                        
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("مبلغ خواسته شده بیشتر از مبلغ بدهی است");
                    }
                }
            }
            else
            {
                if (a == false)
                {
                    var customer = _customerRepository.GetCustomerById(id);
                    if (customer.credit >= int.Parse(txtMinus.Text.Replace(",", "")))
                    {
                        customer.credit -= (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        minus = (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        _customerRepository.UpdateCustomer(customer);
                        _customerRepository.Save();
                        MessageBox.Show("مبلغ خواسته شده کسر گردید");
                        
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("مبلغ خواسته شده بیشتر از مبلغ طلب است");
                    }
                }
                else
                {
                    var seller = _sellerRepository.GetSellerById(id);
                    if (seller.credit >= int.Parse(txtMinus.Text.Replace(",", "")))
                    {
                        seller.credit -= (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        minus = (int)int.Parse(txtMinus.Text.Replace(",", ""));
                        _sellerRepository.UpdateSeller(seller);
                        _sellerRepository.Save();
                        MessageBox.Show("مبلغ خواسته شده کسر گردید");
                        
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("مبلغ خواسته شده بیشتر از مبلغ بدهی است");
                    }
                }
            }
        }

        private void txtDebt_TextChanged(object sender, EventArgs e)
        {
            if (txtDebt.Text == "" || txtDebt.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtDebt.Text, System.Globalization.NumberStyles.Currency);
            txtDebt.Text = price.ToString("#,#");

            txtDebt.Select(txtDebt.TextLength, 0);
        }

        private void txtMinus_TextChanged(object sender, EventArgs e)
        {
            if (txtMinus.Text == "" || txtMinus.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtMinus.Text, System.Globalization.NumberStyles.Currency);
            txtMinus.Text = price.ToString("#,#");

            txtMinus.Select(txtMinus.TextLength, 0);
        }

        private void txtDebt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMinus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMinus_Leave(object sender, EventArgs e)
        {
            if(txtMinus.Text == "")
            {
                txtMinus.Text = "0";
            }
        }
    }
}
