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
    public partial class frmAddCustomer : Form
    {
        public int id = 0;
        public bool aa = false;
        MyContext db = new MyContext();
        ICustomerRepository _customerRepository;
        ISellerRepository _sellerRepository;
        ISaleHistoryRepository _saleHistoryRepository;
        IPurchaseHistoryRepository _purchaseHistoryRepository;
        public frmAddCustomer()
        {
            _customerRepository = new CustomerRepository(db);
            _sellerRepository = new SellerRepository(db);
            _saleHistoryRepository = new SaleHistoryRepository(db);
            _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
            InitializeComponent();
        }

        private void btnCustomerRecord_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید");
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید");
            }
            else if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید");
            }
            else
            {
                if (aa == false)
                {
                    if (id == 0)
                    {
                        Customers cus = new Customers()
                        {
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            PhoneNumber = txtPhoneNumber.Text,
                            Address = txtAddress.Text,
                            credit = txtPreCredit.Text.Replace(",", "") != "" ? int.Parse(txtPreCredit.Text.Replace(",", "")) : 0,
                            debt = txtPreDebt.Text.Replace(",", "") != "" ? int.Parse(txtPreDebt.Text.Replace(",", "")) : 0
                        };
                        _customerRepository.InsertCustomer(cus);
                        _customerRepository.Save();
                        MessageBox.Show("مشتری با موفقیت اضافه شد");
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtAddress.Text = "";
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        var customer = _customerRepository.GetCustomerById(id);

                        customer.CustomerID = id;
                        customer.FirstName = txtFirstName.Text;
                        customer.LastName = txtLastName.Text;
                        customer.PhoneNumber = txtPhoneNumber.Text;
                        customer.Address = txtAddress.Text;
                        if (txtPreCredit.Text.Replace(",", "") != "" && txtPreCredit.Text.Replace(",", "") != "0" && txtPreDebt.Text.Replace(",", "") != "" && txtPreDebt.Text.Replace(",", "") != "0")
                        {
                            MessageBox.Show("لطفا فقط مقدار طلب یا مقدار بدهی را پر کنید ، هر دو مقدار به طور همزمان نمی تواند پر باشد");
                        }
                        else
                        {
                            if (txtPreDebt.Text.Replace(",", "") != "" && txtPreDebt.Text.Replace(",", "") != "0")
                            {
                                if (customer.debt > 0)
                                {
                                    customer.debt += int.Parse(txtPreDebt.Text.Replace(",", ""));
                                }
                                else if (customer.credit > 0)
                                {
                                    if (customer.credit - int.Parse(txtPreDebt.Text.Replace(",", "")) >= 0)
                                    {
                                        customer.credit -= int.Parse(txtPreDebt.Text.Replace(",", ""));
                                    }
                                    else if (customer.credit - int.Parse(txtPreDebt.Text.Replace(",", "")) < 0)
                                    {
                                        customer.debt = System.Math.Abs(customer.credit - int.Parse(txtPreDebt.Text.Replace(",", "")));
                                        customer.credit = 0;
                                    }
                                }
                                else
                                {
                                    customer.debt = int.Parse(txtPreDebt.Text.Replace(",", ""));
                                }
                            }
                            else if (txtPreCredit.Text.Replace(",", "") != "" && txtPreCredit.Text.Replace(",", "") != "0")
                            {
                                if (customer.credit > 0)
                                {
                                    customer.credit += int.Parse(txtPreCredit.Text.Replace(",", ""));
                                }
                                else if (customer.debt > 0)
                                {
                                    if (customer.debt - int.Parse(txtPreCredit.Text.Replace(",", "")) >= 0)
                                    {
                                        customer.debt -= int.Parse(txtPreCredit.Text.Replace(",", ""));
                                    }
                                    else if (customer.debt - int.Parse(txtPreCredit.Text.Replace(",", "")) < 0)
                                    {
                                        customer.credit = System.Math.Abs(customer.debt - int.Parse(txtPreCredit.Text.Replace(",", "")));
                                        customer.debt = 0;
                                    }
                                }
                                else
                                {
                                    customer.credit = int.Parse(txtPreCredit.Text.Replace(",", ""));
                                }
                            }
                            _customerRepository.UpdateCustomer(customer);

                            _customerRepository.Save();
                            var sale = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.CustomerID == customer.CustomerID);
                            foreach (var item in sale)
                            {
                                item.CustomerName = customer.FirstName + " " + customer.LastName;
                                _saleHistoryRepository.UpdateSaleHistory(item);
                                _saleHistoryRepository.Save();
                            }

                            MessageBox.Show("مشتری با موفقیت ویرایش شد");
                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            txtPhoneNumber.Text = "";
                            txtAddress.Text = "";
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    if (id == 0)
                    {
                        Sellers sel = new Sellers()
                        {
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            PhoneNumber = txtPhoneNumber.Text,
                            Address = txtAddress.Text,
                            credit = txtPreCredit.Text.Replace(",", "") != "" ? int.Parse(txtPreCredit.Text.Replace(",", "")) : 0,
                            debt = txtPreDebt.Text.Replace(",", "") != "" ? int.Parse(txtPreDebt.Text.Replace(",", "")) : 0
                        };
                        _sellerRepository.InsertSeller(sel);
                        _sellerRepository.Save();
                        MessageBox.Show("سالن دار با موفقیت اضافه شد");
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtPhoneNumber.Text = "";
                        txtAddress.Text = "";
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        var seller = _sellerRepository.GetSellerById(id);


                        seller.FirstName = txtFirstName.Text;
                        seller.LastName = txtLastName.Text;
                        seller.PhoneNumber = txtPhoneNumber.Text;
                        seller.Address = txtAddress.Text;
                        if (txtPreCredit.Text.Replace(",", "") != "" && txtPreCredit.Text.Replace(",", "") != "0" && txtPreDebt.Text.Replace(",", "") != "" && txtPreDebt.Text.Replace(",", "") != "0")
                        {
                            MessageBox.Show("لطفا فقط مقدار طلب یا مقدار بدهی را پر کنید ، هر دو مقدار به طور همزمان نمی تواند پر باشد");
                        }
                        else
                        {
                            if (txtPreDebt.Text.Replace(",", "") != "" && txtPreDebt.Text.Replace(",", "") != "0")
                            {
                                if (seller.debt > 0)
                                {
                                    seller.debt += int.Parse(txtPreDebt.Text.Replace(",", ""));
                                }
                                else if (seller.credit > 0)
                                {
                                    if (seller.credit - int.Parse(txtPreDebt.Text.Replace(",", "")) >= 0)
                                    {
                                        seller.credit -= int.Parse(txtPreDebt.Text.Replace(",", ""));
                                    }
                                    else if (seller.credit - int.Parse(txtPreDebt.Text.Replace(",", "")) < 0)
                                    {
                                        seller.debt = System.Math.Abs(seller.credit - int.Parse(txtPreDebt.Text.Replace(",", "")));
                                        seller.credit = 0;
                                    }
                                }
                                else
                                {
                                    seller.debt = int.Parse(txtPreDebt.Text.Replace(",", ""));
                                }
                            }
                            else if (txtPreCredit.Text.Replace(",", "") != "" && txtPreCredit.Text.Replace(",", "") != "0")
                            {
                                if (seller.credit > 0)
                                {
                                    seller.credit += int.Parse(txtPreCredit.Text.Replace(",", ""));
                                }
                                else if (seller.debt > 0)
                                {
                                    if (seller.debt - int.Parse(txtPreCredit.Text.Replace(",", "")) >= 0)
                                    {
                                        seller.debt -= int.Parse(txtPreCredit.Text.Replace(",", ""));
                                    }
                                    else if (seller.debt - int.Parse(txtPreCredit.Text.Replace(",", "")) < 0)
                                    {
                                        seller.credit = System.Math.Abs(seller.debt - int.Parse(txtPreCredit.Text.Replace(",", "")));
                                        seller.debt = 0;
                                    }
                                }
                                else
                                {
                                    seller.credit = int.Parse(txtPreCredit.Text.Replace(",", ""));
                                }
                            }


                            _sellerRepository.UpdateSeller(seller);

                            _sellerRepository.Save();
                            var pur = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.SellerID == seller.SellerID);
                            foreach (var item in pur)
                            {
                                item.SellerName = seller.FirstName + " " + seller.LastName;
                                _purchaseHistoryRepository.UpdatePurchaseHistory(item);
                                _purchaseHistoryRepository.Save();
                            }

                                

                                MessageBox.Show("سالن دار با موفقیت ویرایش شد");
                            
                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            txtPhoneNumber.Text = "";
                            txtAddress.Text = "";
                            DialogResult = DialogResult.OK;
                        }
                    }
                }


            }
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            if (aa == false)
            {
                if (id != 0)
                {
                    this.Text = "ویرایش مشتری";
                    btnCustomerRecord.Text = "ویرایش";
                    var customer = _customerRepository.GetCustomerById(id);
                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtAddress.Text = customer.Address;
                }
            }
            else
            {
                this.Text = "افزودن سالن دار";
                this.groupBox1.Text = "اطلاعات سالن دار";
                if (id != 0)
                {
                    this.Text = "ویرایش سالن دار";
                    btnCustomerRecord.Text = "ویرایش";
                    var seller = _sellerRepository.GetSellerById(id);
                    txtFirstName.Text = seller.FirstName;
                    txtLastName.Text = seller.LastName;
                    txtPhoneNumber.Text = seller.PhoneNumber;
                    txtAddress.Text = seller.Address;
                }
            }
        }

        private void txtPreDebt_TextChanged(object sender, EventArgs e)
        {
            if (txtPreDebt.Text == "" || txtPreDebt.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtPreDebt.Text, System.Globalization.NumberStyles.Currency);
            txtPreDebt.Text = price.ToString("#,#");
            txtPreDebt.Select(txtPreDebt.Text.Length, 0);
        }

        private void txtPreCredit_TextChanged(object sender, EventArgs e)
        {
            if (txtPreCredit.Text == "" || txtPreCredit.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtPreCredit.Text, System.Globalization.NumberStyles.Currency);
            txtPreCredit.Text = price.ToString("#,#");
            txtPreCredit.Select(txtPreCredit.TextLength, 0);
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPreDebt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPreCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPreDebt_Leave(object sender, EventArgs e)
        {
            if(txtPreDebt.Text == "")
            {
                txtPreDebt.Text = "0";
            }
        }

        private void txtPreCredit_Leave(object sender, EventArgs e)
        {
            if (txtPreCredit.Text == "")
            {
                txtPreCredit.Text = "0";
            }
        }
    }
}
