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
using System.Globalization;

namespace MushroomStore
{


    public partial class frmSale : Form
    {
        bool IsRefresh = false;
        public bool aaa = false;
        public int debt = 0;
        public int credit = 0;
        List<int> debt2 = new List<int>();
        List<int> credit2 = new List<int>();
        MyContext db = new MyContext();
        IMushroomRepository _mushroomRepository;
        ICustomerRepository _customerRepository;
        ISaleHistoryRepository _saleHistoryRepository;
        ISellerRepository _sellerRepository;
        IPurchaseHistoryRepository _purchaseHistory;
        List<int> Cusid = new List<int>();
        List<int> Selid = new List<int>();
        List<int> Mushid = new List<int>();
        List<int> Mushid2 = new List<int>();


        public frmSale()
        {
            _mushroomRepository = new MushroomRepository(db);
            _customerRepository = new CustomerRepository(db);
            _saleHistoryRepository = new SaleHistoryRepository(db);
            _sellerRepository = new SellerRepository(db);
            _purchaseHistory = new PurchaseHistoryRepository(db);
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();

            rdKilo.Checked = true;
            label9.Text = GetDate();
            var mushroom = _mushroomRepository.GetAllMushrooms();

            if (aaa == false)
            {
                var customer = _customerRepository.GetAllCustomers();

                foreach (var item in mushroom)
                {
                    txtMushroomType.Items.Add(item.Name);
                    Mushid.Add(item.MushroomID);
                }
                foreach (var item in customer)
                {
                    txtCustomerSelect.Items.Add(item.FirstName + " " + item.LastName);
                    Cusid.Add(item.CustomerID);
                }
            }
            else
            {
                this.Text = "ثبت خرید";
                this.groupBox1.Text = "اطلاعات خرید";
                this.label4.Text = "انتخاب سالن دار";
                var Seller = _sellerRepository.GetAllSellers();

                foreach (var item in mushroom)
                {
                    txtMushroomType.Items.Add(item.Name);
                    Mushid2.Add(item.MushroomID);
                }
                foreach (var item in Seller)
                {
                    txtCustomerSelect.Items.Add(item.FirstName + " " + item.LastName);
                    Selid.Add(item.SellerID);
                }
            }

        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            if (aaa == false)
            {
                txtCustomerSelect.Items.Clear();
                Cusid.Clear();
                var customer = _customerRepository.GetAllCustomers().Where(c => c.FirstName.StartsWith(txtSearchCustomer.Text) || c.LastName.StartsWith(txtSearchCustomer.Text) || (c.FirstName + " " + c.LastName).StartsWith(txtSearchCustomer.Text)).ToList();
                foreach (var item in customer)
                {
                    txtCustomerSelect.Items.Add(item.FirstName + " " + item.LastName);
                    Cusid.Add(item.CustomerID);

                }
            }
            else
            {
                txtCustomerSelect.Items.Clear();
                Selid.Clear();
                var seller = _sellerRepository.GetAllSellers().Where(c => c.FirstName.StartsWith(txtSearchCustomer.Text) || c.LastName.StartsWith(txtSearchCustomer.Text) || (c.FirstName + " " + c.LastName).StartsWith(txtSearchCustomer.Text)).ToList();
                foreach (var item in seller)
                {
                    txtCustomerSelect.Items.Add(item.FirstName + " " + item.LastName);
                    Selid.Add(item.SellerID);

                }
            }
        }

        private void txtSearchMushroom_TextChanged(object sender, EventArgs e)
        {
            if (aaa == false)
            {
                txtMushroomType.Items.Clear();
                Mushid.Clear();
                var mushroom = _mushroomRepository.GetAllMushrooms().Where(m => m.Name.StartsWith(txtSearchMushroom.Text)).ToList();
                foreach (var item in mushroom)
                {
                    txtMushroomType.Items.Add(item.Name);
                    Mushid.Add(item.MushroomID);

                }
            }
            else
            {
                txtMushroomType.Items.Clear();
                Mushid2.Clear();
                var mushroom = _mushroomRepository.GetAllMushrooms().Where(m => m.Name.StartsWith(txtSearchMushroom.Text)).ToList();
                foreach (var item in mushroom)
                {
                    txtMushroomType.Items.Add(item.Name);
                    Mushid2.Add(item.MushroomID);
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMushroomType.Text == "")
                {
                    MessageBox.Show("لطفا نوع قارچ را وارد کنید");
                }
                else if (txtCustomerSelect.Text == "")
                {
                    MessageBox.Show("لطفا مشتری را وارد کنید");
                }
                else if (txtAmount.Text.Replace(",", "")== "")
                {
                    MessageBox.Show("لطفا مقدار را وارد کنید");
                }
                else if (int.Parse(txtAmount.Text.Replace(",", "")) <= 0)
                {
                    MessageBox.Show("لطفا مقدار را بیشتر از صفر تعیین کنید");
                }
                else if (txtPrice.Text.Replace(",", "")== "")
                {
                    MessageBox.Show("لطفا قیمت را وارد کنید");
                }
                else if (int.Parse(txtPrice.Text.Replace(",", "")) <= 0)
                {
                    MessageBox.Show("لطفا قیمت را بیشتر از صفر تعیین کنید");
                }
                else
                {
                    var sum = (int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", "")));
                    label11.Text = sum + "تومان";
                }
            }
            catch
            {
                MessageBox.Show("لطفا از اعداد برای فیلد مقدار ، قیمت ، پرداختی استفاده کنید");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmountPaid.Text.Replace(",", "") == "")
                {
                    txtAmountPaid.Text = "0";
                }

                if (aaa == false)
                {
                    var Cusindex = txtCustomerSelect.SelectedIndex;
                    int Customerid = Cusid[Cusindex];
                    var customer = _customerRepository.GetCustomerById(Customerid);

                    var sum = int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""));
                    var paid = int.Parse(txtAmountPaid.Text.Replace(",", ""));

                    debt2.Add(customer.debt);

                    credit2.Add(customer.credit);
                    if (label11.Text == "0 تومان")
                    {
                        MessageBox.Show("جمع مبلغ کل 0 می باشد.");
                    }
                    else
                    {
                        if (debt2[debt2.Count - 1] > 0)
                        {
                            if (sum - paid > 0)
                            {
                                debt2[debt2.Count - 1] += (sum - paid);
                                label14.Text = "مشتری" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                            }
                            else if (sum - paid < 0)
                            {
                                if (debt2[debt2.Count - 1] - System.Math.Abs(sum - paid) < 0)
                                {
                                    credit2[credit2.Count - 1] = System.Math.Abs(debt2[debt2.Count - 1] - System.Math.Abs(sum - paid));
                                    debt2[debt2.Count - 1] = 0;
                                    label14.Text = "مشتری" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                                }
                                else
                                {
                                    debt2[debt2.Count - 1] -= System.Math.Abs(sum - paid);
                                    if (debt2[debt2.Count - 1] > 0)
                                    {
                                        label14.Text = "مشتری" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                                    }
                                    else if (debt2[debt2.Count - 1] == 0)
                                    {
                                        label14.Text = "پرداخت شد";
                                    }
                                }
                            }
                            else
                            {
                                label14.Text = "مشتری" + " " + debt2[debt2.Count - 1].ToString("#,#") + " " + "تومان بدهکار است";
                            }
                        }
                        else if (credit2[credit2.Count - 1] > 0)
                        {
                            if (sum - paid > 0)
                            {
                                if (credit2[credit2.Count - 1] - (sum - paid) < 0)
                                {
                                    debt2[debt2.Count - 1] = System.Math.Abs(credit2[credit2.Count - 1] - (sum - paid));
                                    credit2[credit2.Count - 1] = 0;
                                    label14.Text = "مشتری" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                                }
                                else
                                {
                                    credit2[credit2.Count - 1] -= sum - paid;
                                    if (credit2[credit2.Count - 1] > 0)
                                    {
                                        label14.Text = "مشتری" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                                    }
                                    else if (credit2[credit2.Count - 1] == 0)
                                    {
                                        label14.Text = "پرداخت شد";
                                    }
                                }
                            }
                            else if (sum - paid < 0)
                            {
                                credit2[credit2.Count - 1] += System.Math.Abs(sum - paid);
                                label14.Text = "مشتری" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                            }
                            else
                            {
                                label14.Text = "مشتری" + " " + credit2[credit2.Count - 1].ToString("#,#") + " " + "تومان طلبکار است";
                            }
                        }
                        else
                        {
                            if (sum - paid > 0)
                            {
                                debt2[debt2.Count - 1] = (sum - paid);
                                label14.Text = "مشتری" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                            }
                            else if (sum - paid < 0)
                            {
                                credit2[credit2.Count - 1] = System.Math.Abs(sum - paid);
                                label14.Text = "مشتری" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                            }
                            else
                            {
                                label14.Text = "پرداخت شد";
                            }
                        }

                    }
                }
                else
                {
                    var selindex = txtCustomerSelect.SelectedIndex;
                    int Sellerid = Selid[selindex];
                    var seller = _sellerRepository.GetSellerById(Sellerid);
                    var sum = int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""));
                    var paid = int.Parse(txtAmountPaid.Text.Replace(",", ""));
                    debt2.Add(seller.debt);

                    credit2.Add(seller.credit);


                    if (label11.Text == "0 تومان")
                    {
                        MessageBox.Show("جمع مبلغ کل 0 می باشد.");
                    }
                    else
                    {
                        if (debt2[debt2.Count - 1] > 0)
                        {
                            if (sum - paid < 0)
                            {
                                debt2[debt2.Count - 1] += System.Math.Abs((sum - paid));
                                label14.Text = "سالن دار" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                            }
                            else if (sum - paid > 0)
                            {
                                if (debt2[debt2.Count - 1] - (sum - paid) < 0)
                                {
                                    credit2[credit2.Count - 1] = System.Math.Abs(debt2[debt2.Count - 1] - (sum - paid));
                                    debt2[debt2.Count - 1] = 0;
                                    label14.Text = "سالن دار" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                                }
                                else
                                {
                                    debt2[debt2.Count - 1] -= sum - paid;
                                    if (debt2[debt2.Count - 1] > 0)
                                    {
                                        label14.Text = "سالن دار" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                                    }
                                    else if (debt2[debt2.Count - 1] == 0)
                                    {
                                        label14.Text = "پرداخت شد";
                                    }
                                }
                            }
                            else
                            {
                                label14.Text = "سالن دار" + " " + debt2[debt2.Count - 1].ToString("#,#") + " " + "تومان بدهکار است";
                            }
                        }
                        else if (credit2[credit2.Count - 1] > 0)
                        {
                            if (sum - paid < 0)
                            {
                                if (credit2[credit2.Count - 1] - System.Math.Abs(sum - paid) < 0)
                                {
                                    debt2[debt2.Count - 1] = System.Math.Abs(credit2[credit2.Count - 1] - System.Math.Abs(sum - paid));
                                    credit2[credit2.Count - 1] = 0;
                                    label14.Text = "سالن دار" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                                }
                                else
                                {
                                    credit2[credit2.Count - 1] -= System.Math.Abs(sum - paid);
                                    if (credit2[credit2.Count - 1] > 0)
                                    {
                                        label14.Text = "سالن دار" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                                    }
                                    else if (credit2[credit2.Count - 1] == 0)
                                    {
                                        label14.Text = "پرداخت شد";
                                    }
                                }
                            }
                            else if (sum - paid > 0)
                            {
                                credit2[credit2.Count - 1] += sum - paid;
                                label14.Text = "سالن دار" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                            }
                            else
                            {
                                label14.Text = "سالن دار" + " " + credit2[credit2.Count - 1].ToString("#,#") + " " + "تومان طلبکار است";
                            }
                        }
                        else
                        {
                            if (sum - paid < 0)
                            {
                                debt2[debt2.Count - 1] = System.Math.Abs(sum - paid);
                                label14.Text = "سالن دار" + " " + (debt2[debt2.Count - 1].ToString("#,#")) + " " + "تومان بدهکار است";
                            }
                            else if (sum - paid > 0)
                            {
                                credit2[credit2.Count - 1] = sum - paid;
                                label14.Text = "سالن دار" + " " + (credit2[credit2.Count - 1].ToString("#,#")) + " " + "تومان طلبکار است";
                            }
                            else
                            {
                                label14.Text = "پرداخت شد";
                            }
                        }

                    }

                }
                IsRefresh = true;
            }
            catch
            {
                MessageBox.Show("لطفا از اعداد برای فیلد مقدار ، قیمت ، پرداختی استفاده کنید");
            }
        }


        private void btnMushroomRecord_Click(object sender, EventArgs e)
        {
            if (txtMushroomType.Text == "")
            {
                MessageBox.Show("لطفا نوع قارچ را وارد کنید");
            }
            else if (txtCustomerSelect.Text == "")
            {
                if (aaa == false)
                {
                    MessageBox.Show("لطفا مشتری را وارد کنید");
                }
                else
                {
                    MessageBox.Show("لطفا سالن دار را وارد کنید");
                }
            }
            else if (txtAmount.Text.Replace(",", "")== "")
            {
                MessageBox.Show("لطفا مقدار را وارد کنید");
            }
            else if (int.Parse(txtAmount.Text.Replace(",", "")) == 0)
            {
                MessageBox.Show("لطفا مقدار را بیشتر از صفر تعیین کنید");
            }
            else if (txtPrice.Text.Replace(",", "")== "")
            {
                MessageBox.Show("لطفا قیمت را وارد کنید");
            }
            else if (int.Parse(txtPrice.Text.Replace(",", "")) == 0)
            {
                MessageBox.Show("لطفا قیمت را بیشتر از صفر تعیین کنید");
            }
            else if (label11.Text == "0 تومان")
            {
                MessageBox.Show("جمع مبلغ کل 0 می باشد.");
            }
            else if (label14.Text == "" || IsRefresh == false)
            {
                MessageBox.Show("لطفا ابتدا دکمه پرداخت را بزنید");
            }
            else
            {
                Program.ch = 1;

                if (aaa == false)
                {
                    if (txtCustomerSelect.Text != null)
                    {
                        var Cusindex = txtCustomerSelect.SelectedIndex;
                        var Mushindex = txtMushroomType.SelectedIndex;
                        int Customerid = Cusid[Cusindex];
                        int Mushroomid = Mushid[Mushindex];
                        var customer = _customerRepository.GetCustomerById(Customerid);
                        var mush = _mushroomRepository.GetMushroomById(Mushroomid);
                        var date = "";
                        if (txtDate.Text != "    /  /")
                        {
                            date = txtDate.Text;
                        }
                        else
                        {
                            date = GetDate();
                        }
                        PersianCalendar pc = new PersianCalendar();
                        int c = 0;
                        int d = 0;
                        if ((int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))) > (int)int.Parse(txtAmountPaid.Text.Replace(",", "")))
                        {
                            d = (int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))) - (int)int.Parse(txtAmountPaid.Text.Replace(",", ""));
                        }
                        else if ((int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))) < (int)int.Parse(txtAmountPaid.Text.Replace(",", "")))
                        {
                            c = (int)int.Parse(txtAmountPaid.Text.Replace(",", "")) - (int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", "")));
                        }
                        SaleHistory sale = new SaleHistory()
                        {
                            CustomerID = customer.CustomerID,
                            CustomerName = customer.FirstName + " " + customer.LastName,
                            MushroomID = mush.MushroomID,
                            MushroomName = mush.Name,
                            amount = (int)int.Parse(txtAmount.Text.Replace(",", "")),
                            Date = date,
                            Price = (int)int.Parse(txtPrice.Text.Replace(",", "")),
                            Sum = (int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))),
                            Paid = (int)int.Parse(txtAmountPaid.Text.Replace(",", "")),
                            Credit = c,
                            Debt = d,
                            Description = txtDescription.Text
                        };

                        _saleHistoryRepository.InsertSaleHistory(sale);
                        _saleHistoryRepository.Save();
                        customer.credit = credit2[credit2.Count - 1];
                        customer.debt = debt2[debt2.Count - 1];
                        _customerRepository.UpdateCustomer(customer);
                        _customerRepository.Save();
                        MessageBox.Show("فروش با موفقیت ثبت شد");
                        txtAmount.Text = "";
                        txtAmountPaid.Text = "";

                        txtPrice.Text = "";
                        txtSearchCustomer.Text = "";
                        txtSearchMushroom.Text = "";
                        label11.Text = "0 تومان";
                        label14.Text = "";
                        txtDate.Text = "    /  /";
                        txtDescription.Text = "";
                    }

                }
                else
                {
                    if (txtCustomerSelect.Text != null)
                    {
                        var Selindex = txtCustomerSelect.SelectedIndex;
                        var Mushindex = txtMushroomType.SelectedIndex;
                        int Sellerid = Selid[Selindex];
                        int Mushroomid = Mushid2[Mushindex];
                        var seller = _sellerRepository.GetSellerById(Sellerid);
                        var mush = _mushroomRepository.GetMushroomById(Mushroomid);
                        var date = "";
                        if (txtDate.Text != "    /  /")
                        {
                            date = txtDate.Text;
                        }
                        else
                        {
                            date = GetDate();
                        }
                        PersianCalendar pc = new PersianCalendar();
                        int c = 0;
                        int d = 0;
                        if ((int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))) > (int)int.Parse(txtAmountPaid.Text.Replace(",", "")))
                        {
                            c = (int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))) - (int)int.Parse(txtAmountPaid.Text.Replace(",", ""));
                        }
                        else if ((int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))) < (int)int.Parse(txtAmountPaid.Text.Replace(",", "")))
                        {
                            d = (int)int.Parse(txtAmountPaid.Text.Replace(",", "")) - (int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", "")));
                        }
                        PurchaseHistory ph = new PurchaseHistory()
                        {
                            SellerID = seller.SellerID,
                            SellerName = seller.FirstName + " " + seller.LastName,
                            MushroomID = mush.MushroomID,
                            MushroomName = mush.Name,
                            amount = (int)int.Parse(txtAmount.Text.Replace(",", "")),
                            Date = date,
                            Price = (int)int.Parse(txtPrice.Text.Replace(",", "")),
                            Sum = (int)(int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", ""))),
                            Paid = (int)int.Parse(txtAmountPaid.Text.Replace(",", "")),
                            Credit = c,
                            Debt = d,
                            Description = txtDescription.Text
                        };
                        _purchaseHistory.InsertPurchaseHistory(ph);
                        _purchaseHistory.Save();
                        seller.credit = credit2[credit2.Count - 1];
                        seller.debt = debt2[debt2.Count - 1];
                        _sellerRepository.UpdateSeller(seller);
                        _sellerRepository.Save();
                        MessageBox.Show("خرید با موفقیت ثبت شد");
                        txtAmount.Text = "";
                        txtAmountPaid.Text = "";

                        txtPrice.Text = "";
                        txtSearchCustomer.Text = "";
                        txtSearchMushroom.Text = "";
                        label11.Text = "0 تومان";
                        label14.Text = "";
                        txtDate.Text = "    /  /";
                        txtDescription.Text = "";
                    }
                }
            }
        }
        private string GetDate()
        {
            PersianCalendar pc = new PersianCalendar();

            DateTime dt = DateTime.Now;

            string Year = pc.GetYear(dt).ToString();

            string Month = pc.GetMonth(dt).ToString().Length == 1 ? "0" + pc.GetMonth(dt).ToString() : pc.GetMonth(dt).ToString();

            string Day = pc.GetDayOfMonth(dt).ToString().Length == 1 ? "0" + pc.GetDayOfMonth(dt).ToString() : pc.GetDayOfMonth(dt).ToString();

            return string.Format("{0}/{1}/{2}", Year, Month, Day);
        }

        private void frmSale_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text.Replace(",", "")== "" || txtAmount.Text.Replace(",", "")== "0") return;
                decimal price;
                price = decimal.Parse(txtAmount.Text, System.Globalization.NumberStyles.Currency);
                txtAmount.Text = price.ToString("#,#");

                txtAmount.Select(txtAmount.TextLength, 0);
                if (txtPrice.Text.Replace(",", "") != "" && int.Parse(txtPrice.Text.Replace(",", "")) > 0)
                {
                    var sum = (int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", "")));
                    label11.Text = sum.ToString("#,#") + "تومان";
                    IsRefresh = false;
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
                if (txtPrice.Text.Replace(",", "")== "" || txtPrice.Text.Replace(",", "") == "0") return;
                decimal price;
                price = decimal.Parse(txtPrice.Text, System.Globalization.NumberStyles.Currency);
                txtPrice.Text = price.ToString("#,#");

                txtPrice.Select(txtPrice.TextLength, 0);
                if (txtAmount.Text.Replace(",", "") != "" && int.Parse(txtAmount.Text.Replace(",", "")) > 0)
                {
                    var sum = (int.Parse(txtAmount.Text.Replace(",", "")) * int.Parse(txtPrice.Text.Replace(",", "")));
                    label11.Text = sum.ToString("#,#") + "تومان";
                    IsRefresh = false;
                }
            }
            catch
            {

            }
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text == "" || txtAmountPaid.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtAmountPaid.Text, System.Globalization.NumberStyles.Currency);
            txtAmountPaid.Text = price.ToString("#,#");

            txtAmountPaid.Select(txtAmountPaid.TextLength, 0);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmountPaid_Leave(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text == "")
            {
                txtAmountPaid.Text = "0";
            }
        }
    }
}
