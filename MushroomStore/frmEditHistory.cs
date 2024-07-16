using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MushroomStore
{
    public partial class frmEditHistory : Form
    {
        List<int> Mushid = new List<int>();
        List<int> Mushid2 = new List<int>();
        List<int> debt2 = new List<int>();
        List<int> credit2 = new List<int>();
        public int debt = 0;
        public int credit = 0;
        public int id = 0;
        public bool a = false;
        int salepaid = 0;
        int purchasepaid = 0;
        int salesum = 0;
        int saledebt = 0;
        int salecredit = 0;
        int purchasesum = 0;
        int purchasedebt = 0;
        int purchasecredit = 0;
        int beforeCreditDebt = 0;

        MyContext db = new MyContext();
        ISaleHistoryRepository _saleHistoryRepository;
        IPurchaseHistoryRepository _purchaseHistoryRepository;
        ISellerRepository _sellerRepository;
        ICustomerRepository _customerRepository;
        IMushroomRepository _mushroomRepository;

        public frmEditHistory()
        {
            InitializeComponent();
            _saleHistoryRepository = new SaleHistoryRepository(db);
            _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
            _sellerRepository = new SellerRepository(db);
            _customerRepository = new CustomerRepository(db);
            _mushroomRepository = new MushroomRepository(db);
        }

        private void frmEditHistory_Load(object sender, EventArgs e)
        {

            if (a == false)
            {
                if (id != 0)
                {
                    var sale = _saleHistoryRepository.GetSaleHistoryById(id);
                    var mushroom = _mushroomRepository.GetAllMushrooms().ToList();
                    txtID.Text = sale.CustomerID.ToString();
                    txtName.Text = sale.CustomerName;

                    foreach (var item in mushroom)
                    {
                        txtMushroom.Items.Add(item.Name);
                    }
                    txtMushroom.Text = sale.MushroomName;
                    txtAmount.Text = sale.amount.ToString();
                    txtPrice.Text = sale.Price.ToString();
                    txtPaid.Text = sale.Paid.ToString();
                    txtSum.Text = sale.Sum.ToString();
                    txtDescription.Text = sale.Description.ToString();
                    salepaid = int.Parse(txtPaid.Text.Replace(",", ""));
                    salesum = Convert.ToInt32(txtSum.Text.Replace(",", ""));
                    beforeCreditDebt = int.Parse(txtSum.Text.Replace(",", "")) - int.Parse(txtPaid.Text.Replace(",", ""));
                }
            }
            else
            {
                if (id != 0)
                {
                    var purchase = _purchaseHistoryRepository.GetPurchaseHistoryById(id);
                    var mushroom = _mushroomRepository.GetAllMushrooms().ToList();
                    txtID.Text = purchase.SellerID.ToString();
                    txtName.Text = purchase.SellerName;

                    foreach (var item in mushroom)
                    {
                        txtMushroom.Items.Add(item.Name);
                    }
                    txtMushroom.Text = purchase.MushroomName;
                    txtAmount.Text = purchase.amount.ToString();
                    txtPrice.Text = purchase.Price.ToString();
                    txtPaid.Text = purchase.Paid.ToString();
                    txtSum.Text = purchase.Sum.ToString();
                    txtDescription.Text = purchase.Description.ToString();
                    purchasepaid = int.Parse(txtPaid.Text.Replace(",", ""));
                    purchasesum = Convert.ToInt32(txtSum.Text.Replace(",", ""));
                    beforeCreditDebt = int.Parse(txtPaid.Text.Replace(",", "")) - int.Parse(txtSum.Text.Replace(",", ""));



                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                MessageBox.Show("لطفا مقدار را وارد کنید");
            }
            else if (int.Parse(txtAmount.Text) == 0)
            {
                MessageBox.Show("لطفا مقدار را بیشتر از صفر تعیین کنید");
            }
            else if (txtPrice.Text.Replace(",", "") == "")
            {
                MessageBox.Show("لطفا قیمت را وارد کنید");
            }
            else if (int.Parse(txtPrice.Text.Replace(",", "")) == 0)
            {
                MessageBox.Show("لطفا قیمت را بیشتر از صفر تعیین کنید");
            }
            else
            {
                if (txtPaid.Text.Replace(",", "") == "")
                {
                    txtPaid.Text = "0";
                }
                else
                {
                    Program.ch = 1;

                    if (a == false)
                    {
                        var sale = _saleHistoryRepository.GetSaleHistoryById(id);
                        var customer = _customerRepository.GetCustomerById(sale.CustomerID);
                        var now = int.Parse(txtSum.Text.Replace(",", "")) - int.Parse(txtPaid.Text.Replace(",", ""));
                        if (beforeCreditDebt > 0)
                        {
                            if (now > 0)
                            {
                                var result = now - beforeCreditDebt;
                                if (result >= 0)
                                {
                                    if (customer.debt > 0)
                                    {
                                        customer.debt += result;
                                    }
                                    else if (customer.credit > 0)
                                    {
                                        if (customer.credit - result >= 0)
                                        {
                                            customer.credit -= result;
                                        }
                                        else
                                        {
                                            customer.debt = System.Math.Abs(customer.credit - result);
                                            customer.credit = 0;
                                        }
                                    }
                                    else
                                    {
                                        customer.debt = result;
                                    }
                                }
                                else if (result < 0)
                                {
                                    if (customer.debt > 0)
                                    {
                                        if (customer.debt - System.Math.Abs(result) >= 0)
                                        {
                                            customer.debt -= System.Math.Abs(result);
                                        }
                                        else
                                        {
                                            customer.credit = System.Math.Abs(customer.debt - System.Math.Abs(result));
                                            customer.debt = 0;
                                        }
                                    }
                                    else if(customer.credit > 0)
                                    {
                                        customer.credit += System.Math.Abs(result);
                                    }
                                    else
                                    {
                                        customer.credit = System.Math.Abs(result);
                                    }
                                }
                            }
                            else if (now < 0)
                            {
                                var result = System.Math.Abs(now) + beforeCreditDebt;
                                if (customer.debt > 0)
                                {
                                    if (customer.debt - result >= 0)
                                    {
                                        customer.debt -= result;
                                    }
                                    else
                                    {
                                        customer.credit = System.Math.Abs(customer.debt - result);
                                        customer.debt = 0;
                                    }
                                }
                                else if(customer.credit > 0)
                                {
                                    customer.credit += result;
                                }
                                else
                                {
                                    customer.credit = result;
                                }
                            }
                            else
                            {
                                if (customer.debt > 0)
                                {
                                    if (customer.debt - beforeCreditDebt >= 0)
                                    {
                                        customer.debt -= beforeCreditDebt;
                                    }
                                    else
                                    {
                                        customer.credit = System.Math.Abs(customer.debt - beforeCreditDebt);
                                        customer.debt = 0;
                                    }
                                }
                                else if(customer.credit > 0)
                                {
                                    customer.credit += beforeCreditDebt;
                                }
                                else
                                {
                                    customer.credit = beforeCreditDebt;
                                }
                            }
                        }

                        else if (beforeCreditDebt < 0)
                        {
                            if (now > 0)
                            {
                                var result = System.Math.Abs(beforeCreditDebt) + now;
                                if(customer.debt > 0)
                                {
                                    customer.debt += result;
                                }
                                else if(customer.credit > 0)
                                {
                                    if(customer.credit - result >= 0)
                                    {
                                        customer.credit -= result;
                                    }
                                    else
                                    {
                                        customer.debt = System.Math.Abs(customer.credit - result);
                                        customer.credit = 0;
                                    }
                                }
                                else
                                {
                                    customer.debt = result;
                                }
                            }
                            else if (now < 0)
                            {
                                var result = System.Math.Abs(now) - System.Math.Abs(beforeCreditDebt);
                                if(result >= 0)
                                {
                                    if(customer.debt > 0)
                                    {
                                        if(customer.debt - result >= 0)
                                        {
                                            customer.debt -= result;
                                        }
                                        else
                                        {
                                            customer.credit = System.Math.Abs(customer.debt - result);
                                            customer.debt = 0;
                                        }
                                    }
                                    else if(customer.credit > 0)
                                    {
                                        customer.credit += result;
                                    }
                                    else
                                    {
                                        customer.credit = result;
                                    }
                                }
                                else
                                {
                                    if (customer.debt > 0)
                                    {
                                        customer.debt += System.Math.Abs(result);
                                    }
                                    else if(customer.credit > 0)
                                    {
                                        if(customer.credit - System.Math.Abs(result) >= 0)
                                        {
                                            customer.credit -= System.Math.Abs(result);
                                        }
                                        else
                                        {
                                            customer.debt = System.Math.Abs(customer.credit - System.Math.Abs(result));
                                            customer.credit = 0;
                                        }
                                    }
                                    else
                                    {
                                        customer.debt = System.Math.Abs(result);
                                    }
                                }
                            }
                            else
                            {
                                if(customer.debt > 0)
                                {
                                    customer.debt += System.Math.Abs(beforeCreditDebt);
                                }
                                else if(customer.credit > 0)
                                {
                                    if(customer.credit - System.Math.Abs(beforeCreditDebt) >=0)
                                    {
                                        customer.credit -= System.Math.Abs(beforeCreditDebt);
                                    }
                                    else
                                    {
                                        customer.debt = System.Math.Abs(customer.credit - System.Math.Abs(beforeCreditDebt));
                                        customer.credit = 0;
                                    }
                                }
                                else
                                {
                                    customer.debt = System.Math.Abs(beforeCreditDebt);
                                }
                            }
                        }
                        else
                        {
                            if(now > 0)
                            {
                                if(customer.debt > 0)
                                {
                                    customer.debt += now;
                                }
                                else if(customer.credit > 0)
                                {
                                    if(customer.credit - now >= 0)
                                    {
                                        customer.credit -= now;
                                    }
                                    else
                                    {
                                        customer.debt = System.Math.Abs(customer.credit - now);
                                        customer.credit = 0;
                                    }
                                }
                                else
                                {
                                    customer.debt = now;
                                }
                            }
                            else if(now < 0)
                            {
                                if(customer.debt > 0)
                                {
                                    if(customer.debt - System.Math.Abs(now) >= 0)
                                    {
                                        customer.debt -= System.Math.Abs(now);
                                    }
                                    else
                                    {
                                        customer.credit = System.Math.Abs(customer.debt - System.Math.Abs(now));
                                        customer.debt = 0;
                                    }
                                }
                                else if(customer.credit > 0)
                                {
                                    customer.credit += System.Math.Abs(now);
                                }
                                else
                                {
                                    customer.credit = System.Math.Abs(now);
                                }
                            }
                        }
                    }
                    else
                    {
                        var purchase = _purchaseHistoryRepository.GetPurchaseHistoryById(id);
                        var seller = _sellerRepository.GetSellerById(purchase.SellerID);
                        var now = int.Parse(txtPaid.Text.Replace(",", "")) - int.Parse(txtSum.Text.Replace(",", ""));
                        if (beforeCreditDebt < 0)
                        {
                            if (now < 0)
                            {
                                var result = System.Math.Abs(now) - System.Math.Abs(beforeCreditDebt);
                                if (result < 0)
                                {
                                    if (seller.debt > 0)
                                    {
                                        seller.debt += System.Math.Abs(result);
                                    }
                                    else if (seller.credit > 0)
                                    {
                                        if (seller.credit - System.Math.Abs(result) >= 0)
                                        {
                                            seller.credit -= System.Math.Abs(result);
                                        }
                                        else
                                        {
                                            seller.debt = System.Math.Abs(seller.credit - System.Math.Abs(result));
                                            seller.credit = 0;
                                        }
                                    }
                                    else
                                    {
                                        seller.debt = System.Math.Abs(result);
                                    }
                                }
                                else if (result >= 0)
                                {
                                    if (seller.debt > 0)
                                    {
                                        if (seller.debt - result >= 0)
                                        {
                                            seller.debt -= result;
                                        }
                                        else
                                        {
                                            seller.credit = System.Math.Abs(seller.debt - result);
                                            seller.debt = 0;
                                        }
                                    }
                                    else if (seller.credit > 0)
                                    {
                                        seller.credit += result;
                                    }
                                    else
                                    {
                                        seller.credit = result;
                                    }
                                }
                            }
                            else if (now > 0)
                            {
                                var result = now + System.Math.Abs(beforeCreditDebt);
                                if (seller.credit > 0)
                                {
                                    if (seller.credit - result >= 0)
                                    {
                                        seller.credit -= result;
                                    }
                                    else
                                    {
                                        seller.debt = System.Math.Abs(seller.credit - result);
                                        seller.credit = 0;
                                    }
                                }
                                else if (seller.debt > 0)
                                {
                                    seller.debt += result;
                                }
                                else
                                {
                                    seller.debt = result;
                                }
                            }
                            else
                            {
                                if (seller.credit > 0)
                                {
                                    if (seller.credit - System.Math.Abs(beforeCreditDebt) >= 0)
                                    {
                                        seller.credit -= System.Math.Abs(beforeCreditDebt);
                                    }
                                    else
                                    {
                                        seller.debt = System.Math.Abs(seller.credit - System.Math.Abs(beforeCreditDebt));
                                        seller.credit = 0;
                                    }
                                }
                                else if (seller.debt > 0)
                                {
                                    seller.debt += System.Math.Abs(beforeCreditDebt);
                                }
                                else
                                {
                                    seller.debt = System.Math.Abs(beforeCreditDebt);
                                }
                            }
                        }

                        else if (beforeCreditDebt > 0)
                        {
                            if (now < 0)
                            {
                                var result = beforeCreditDebt + System.Math.Abs(now);
                                if (seller.credit > 0)
                                {
                                    seller.credit += result;
                                }
                                else if (seller.debt > 0)
                                {
                                    if (seller.debt - result >= 0)
                                    {
                                        seller.debt -= result;
                                    }
                                    else
                                    {
                                        seller.credit = System.Math.Abs(seller.debt - result);
                                        seller.debt = 0;
                                    }
                                }
                                else
                                {
                                    seller.credit = result;
                                }
                            }
                            else if (now > 0)
                            {
                                var result = now - beforeCreditDebt;
                                if (result < 0)
                                {
                                    if (seller.debt > 0)
                                    {
                                        if (seller.debt - System.Math.Abs(result) >= 0)
                                        {
                                            seller.debt -= System.Math.Abs(result);
                                        }
                                        else
                                        {
                                            seller.credit = System.Math.Abs(seller.debt - System.Math.Abs(result));
                                            seller.debt = 0;
                                        }
                                    }
                                    else if (seller.credit > 0)
                                    {
                                        seller.credit += System.Math.Abs(result);
                                    }
                                    else
                                    {
                                        seller.credit = System.Math.Abs(result);
                                    }
                                }
                                else if(result >= 0)
                                {
                                    if (seller.debt > 0)
                                    {
                                        seller.debt += result;
                                    }
                                    else if (seller.credit > 0)
                                    {
                                        if (seller.credit - result >= 0)
                                        {
                                            seller.credit -= result;
                                        }
                                        else
                                        {
                                            seller.debt = System.Math.Abs(seller.credit - result);
                                            seller.credit = 0;
                                        }
                                    }
                                    else
                                    {
                                        seller.debt = result;
                                    }
                                }
                            }
                            else
                            {
                                if (seller.credit > 0)
                                {
                                    seller.credit += beforeCreditDebt;
                                }
                                else if (seller.debt > 0)
                                {
                                    if (seller.debt - beforeCreditDebt >= 0)
                                    {
                                        seller.debt -= beforeCreditDebt;
                                    }
                                    else
                                    {
                                        seller.credit = System.Math.Abs(seller.debt - beforeCreditDebt);
                                        seller.debt = 0;
                                    }
                                }
                                else
                                {
                                    seller.credit = beforeCreditDebt;
                                }
                            }
                        }
                        else
                        {
                            if (now < 0)
                            {
                                if (seller.credit > 0)
                                {
                                    seller.credit += System.Math.Abs(now);
                                }
                                else if (seller.debt > 0)
                                {
                                    if (seller.debt - System.Math.Abs(now) >= 0)
                                    {
                                        seller.debt -= System.Math.Abs(now);
                                    }
                                    else
                                    {
                                        seller.credit = System.Math.Abs(seller.debt - System.Math.Abs(now));
                                        seller.debt = 0;
                                    }
                                }
                                else
                                {
                                    seller.credit = System.Math.Abs(now);
                                }
                            }
                            else if (now > 0)
                            {
                                if (seller.credit > 0)
                                {
                                    if (seller.credit - now >= 0)
                                    {
                                        seller.credit -= now;
                                    }
                                    else
                                    {
                                        seller.debt = System.Math.Abs(seller.credit - now);
                                        seller.credit = 0;
                                    }
                                }
                                else if (seller.debt > 0)
                                {
                                    seller.debt += now;
                                }
                                else
                                {
                                    seller.debt = now;
                                }
                            }
                        }                        
                    }
                    if (a == false)
                    {
                        string mushname;
                        int mushid;
                        var sale = _saleHistoryRepository.GetSaleHistoryById(id);
                        var mushroom = _mushroomRepository.GetAllMushrooms().ToList();
                        var customer = _customerRepository.GetCustomerById(sale.CustomerID);
                        foreach (var item in mushroom)
                        {
                            Mushid.Add(item.MushroomID);
                        }
                        if (txtMushroom.SelectedIndex != -1)
                        {
                            var Mushindex = txtMushroom.SelectedIndex;
                            int Mushroomid = Mushid[Mushindex];
                            var mush = _mushroomRepository.GetMushroomById(Mushroomid);
                            mushname = mush.Name;
                            mushid = mush.MushroomID;
                        }
                        else
                        {
                            mushname = sale.MushroomName;
                            mushid = sale.MushroomID;
                        }
                        int c = 0;
                        int d = 0;
                        if ((int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))) > (int)int.Parse(txtPaid.Text.Replace(",", "")))
                        {
                            d = (int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))) - (int)int.Parse(txtPaid.Text.Replace(",", ""));
                        }
                        else if ((int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))) < (int)int.Parse(txtPaid.Text.Replace(",", "")))
                        {
                            c = (int)int.Parse(txtPaid.Text.Replace(",", "")) - (int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", "")));
                        }
                        SaleHistory s = new SaleHistory()
                        {
                            CustomerID = sale.CustomerID,
                            SaleID = sale.SaleID,
                            CustomerName = sale.CustomerName,
                            Date = sale.Date,
                            MushroomID = mushid,
                            MushroomName = mushname,
                            amount = (int)int.Parse(txtAmount.Text),
                            Price = (int)int.Parse(txtPrice.Text.Replace(",", "")),
                            Sum = (int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))),
                            Paid = (int)int.Parse(txtPaid.Text.Replace(",", "")),
                            Credit = c,
                            Debt = d,
                            Description = txtDescription.Text
                        };
                        _saleHistoryRepository.UpdateSaleHistory(s);
                        _saleHistoryRepository.Save();
                        _customerRepository.UpdateCustomer(customer);
                        _customerRepository.Save();
                        MessageBox.Show("ویرایش با موفقیت انجام شد");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        string mushname;
                        int mushid;
                        var purchase = _purchaseHistoryRepository.GetPurchaseHistoryById(id);
                        var mushroom = _mushroomRepository.GetAllMushrooms().ToList();
                        var seller = _sellerRepository.GetSellerById(purchase.SellerID);
                        foreach (var item in mushroom)
                        {
                            Mushid.Add(item.MushroomID);
                        }
                        if (txtMushroom.SelectedIndex != -1)
                        {
                            var Mushindex = txtMushroom.SelectedIndex;
                            int Mushroomid = Mushid[Mushindex];
                            var mush = _mushroomRepository.GetMushroomById(Mushroomid);
                            mushname = mush.Name;
                            mushid = mush.MushroomID;
                        }
                        else
                        {
                            mushname = purchase.MushroomName;
                            mushid = purchase.MushroomID;
                        }
                        int c = 0;
                        int d = 0;
                        if ((int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))) > (int)int.Parse(txtPaid.Text.Replace(",", "")))
                        {
                            c = (int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))) - (int)int.Parse(txtPaid.Text.Replace(",", ""));
                        }
                        else if ((int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))) < (int)int.Parse(txtPaid.Text.Replace(",", "")))
                        {
                            d = (int)int.Parse(txtPaid.Text.Replace(",", "")) - (int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", "")));
                        }
                        PurchaseHistory p = new PurchaseHistory()
                        {
                            PurchaseID = purchase.PurchaseID,
                            SellerID = purchase.SellerID,
                            SellerName = purchase.SellerName,
                            Date = purchase.Date,
                            MushroomID = mushid,
                            MushroomName = mushname,
                            amount = (int)int.Parse(txtAmount.Text),
                            Price = (int)int.Parse(txtPrice.Text.Replace(",", "")),
                            Sum = (int)(int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", ""))),
                            Paid = (int)int.Parse(txtPaid.Text.Replace(",", "")),
                            Credit = c,
                            Debt = d,
                            Description = txtDescription.Text
                        };
                        _purchaseHistoryRepository.UpdatePurchaseHistory(p);
                        _purchaseHistoryRepository.Save();
                        _sellerRepository.UpdateSeller(seller);
                        _sellerRepository.Save();
                        MessageBox.Show("ویرایش با موفقیت انجام شد");
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text.Replace(",", "") != "" && int.Parse(txtPrice.Text.Replace(",", "")) > 0)
                {
                    var sum = (int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", "")));
                    txtSum.Text = sum.ToString();
                }
            }
            catch
            {

            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text == "" || txtPrice.Text == "0") return;
                decimal price;
                price = decimal.Parse(txtPrice.Text, System.Globalization.NumberStyles.Currency);
                txtPrice.Text = price.ToString("#,#");
                txtPrice.Select(txtPrice.Text.Length, 0);
                if (txtAmount.Text != "" && int.Parse(txtAmount.Text) > 0)
                {
                    var sum = (int.Parse(txtAmount.Text) * int.Parse(txtPrice.Text.Replace(",", "")));
                    txtSum.Text = sum.ToString();
                }
            }
            catch
            {

            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if (txtPaid.Text == "" || txtPaid.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtPaid.Text, System.Globalization.NumberStyles.Currency);
            txtPaid.Text = price.ToString("#,#");
            txtPaid.Select(txtPaid.Text.Length, 0);
        }

        private void txtSum_TextChanged(object sender, EventArgs e)
        {
            if (txtSum.Text == "" || txtSum.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtSum.Text, System.Globalization.NumberStyles.Currency);
            txtSum.Text = price.ToString("#,#");
            txtSum.Select(txtSum.Text.Length, 0);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if(txtAmount.Text == "")
            {
                txtAmount.Text = "1";
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text == "")
            {
                txtPrice.Text = "0";
            }
        }

        private void txtPaid_Leave(object sender, EventArgs e)
        {
            if (txtPaid.Text == "")
            {
                txtPaid.Text = "0";
            }
        }

        private void txtSum_Leave(object sender, EventArgs e)
        {
            if (txtSum.Text == "")
            {
                txtSum.Text = "0";
            }
        }
    }
}
