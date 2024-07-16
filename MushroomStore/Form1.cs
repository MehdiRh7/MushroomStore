using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using Stimulsoft.Report.Components;

namespace MushroomStore
{
    public partial class Form1 : Form
    {
        MyContext db = new MyContext();
        ICustomerRepository _customerRepository;
        IMushroomRepository _mushroomRepository;
        ISaleHistoryRepository _saleHistoryRepository;
        IPurchaseHistoryRepository _purchaseHistoryRepository;
        IComparisonRepository _comparisonRepository;
        public bool checklogin = false;
        public bool check = false;
        public Form1()
        {
            _customerRepository = new CustomerRepository(db);
            _mushroomRepository = new MushroomRepository(db);
            _saleHistoryRepository = new SaleHistoryRepository(db);
            _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
            _comparisonRepository = new ComparisonRepository(db);
            InitializeComponent();

        }

        private void btnMushroomAdd_Click(object sender, EventArgs e)
        {
            frmAddMushroom frm = new frmAddMushroom();
            frm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Program.ch == 1)
                {
                    label4.Text = "";
                    label6.Text = "";
                    Program.ch = 0;
                }
                MyContext db = new MyContext();
                _saleHistoryRepository = new SaleHistoryRepository(db);
                _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
                if (txtFromDate.Text == "    /  /")
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                else
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
            }
        }

        private void btnSellers_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.a = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Program.ch == 1)
                {
                    label4.Text = "";
                    label6.Text = "";
                    Program.ch = 0;
                }
                MyContext db = new MyContext();
                _saleHistoryRepository = new SaleHistoryRepository(db);
                _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
                if (txtFromDate.Text == "    /  /")
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                else
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Program.ch == 1)
                {
                    label4.Text = "";
                    label6.Text = "";
                    Program.ch = 0;
                }
                MyContext db = new MyContext();
                _saleHistoryRepository = new SaleHistoryRepository(db);
                _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
                if (txtFromDate.Text == "    /  /")
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                else
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            frmLogin frm = new frmLogin();
            if (checklogin == false)
            {
                this.Hide();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    PersianCalendar pc = new PersianCalendar();
                    this.Text = GetDate() + " " + "حسابداری و خرید و فروش قارچ";
                    rdSale.Checked = true;
                    dgSaleHistory.AutoGenerateColumns = false;
                    dgSaleHistory.Columns[6].DefaultCellStyle.Format = "#,#";
                    dgSaleHistory.Columns[7].DefaultCellStyle.Format = "#,#";
                    dgSaleHistory.Columns[8].DefaultCellStyle.Format = "#,#";
                    dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();


                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void rdSale_CheckedChanged(object sender, EventArgs e)
        {
            MyContext db = new MyContext();
            _saleHistoryRepository = new SaleHistoryRepository(db);
            dgSaleHistory.AutoGenerateColumns = false;
            dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
            dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
            dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
            dgSaleHistory.Columns[6].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[7].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[8].DefaultCellStyle.Format = "#,#";
            if (txtFromDate.Text == "    /  /")
            {
                dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();
                var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                txtBuySum.Text = buysum.Sum().ToString();
                var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                txtSaleSum.Text = salesum.Sum().ToString();
            }
            else
            {
                dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).ToList();
                var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                txtBuySum.Text = buysum.Sum().ToString();
                var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                txtSaleSum.Text = salesum.Sum().ToString();
            }


        }

        private void rdBuy_CheckedChanged(object sender, EventArgs e)
        {
            MyContext db = new MyContext();
            _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
            dgSaleHistory.AutoGenerateColumns = false;
            dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
            dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
            dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
            dgSaleHistory.Columns[6].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[7].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[8].DefaultCellStyle.Format = "#,#";
            if (txtFromDate.Text == "    /  /")
            {
                dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).ToList();
                var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                txtBuySum.Text = buysum.Sum().ToString();
                var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                txtSaleSum.Text = salesum.Sum().ToString();
            }
            else
            {
                dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                txtBuySum.Text = buysum.Sum().ToString();
                var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                txtSaleSum.Text = salesum.Sum().ToString();
            }



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            frmSale frm = new frmSale();
            frm.aaa = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Program.ch == 1)
                {
                    label4.Text = "";
                    label6.Text = "";
                    Program.ch = 0;
                }
                MyContext db = new MyContext();
                _saleHistoryRepository = new SaleHistoryRepository(db);
                _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
                if (txtFromDate.Text == "    /  /")
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                else
                {
                    if (rdSale.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                        dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                        dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).ToList();
                    }
                    else if (rdBuy.Checked)
                    {
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                        dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                        dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                        dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                    }
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                if (check == false)
                {
                    label4.Text = "";
                    label6.Text = "";
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtCostetc.Text != "")
            {
                int sum = int.Parse(txtBuySum.Text.Replace(",", "")) + int.Parse(txtCostetc.Text.Replace(",", ""));
                int sum2 = int.Parse(txtSaleSum.Text.Replace(",", "")) - sum;
                if (sum2 > 0)
                {
                    label6.Text = $"{sum2}";
                    label4.Text = "تومان سود کرده اید";
                }
                else if (sum2 < 0)
                {
                    label6.Text = $"{-sum2}";
                    label4.Text = "تومان ضرر کرده اید";
                }
                else
                {
                    label6.Text = "";
                    label4.Text = "0 تومان";
                }
                check = true;
            }
            else
            {
                int sum = int.Parse(txtSaleSum.Text.Replace(",", "")) - int.Parse(txtBuySum.Text.Replace(",", ""));
                if (sum > 0)
                {
                    label6.Text = $"{sum}";
                    label4.Text = "تومان سود کرده اید";
                }
                else if (sum < 0)
                {
                    label6.Text = $"{-sum}";
                    label4.Text = "تومان ضرر کرده اید";
                }
                else
                {
                    label6.Text = "";
                    label4.Text = "0 تومان";
                }

                check = true;
            }

            var mush = _mushroomRepository.GetAllMushrooms().ToList();
            var date = "";
            if (txtFromDate.Text == "    /  /")
            {
                date = GetDate();
            }
            else
            {
                date = txtFromDate.Text;
            }
            var salehis = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == date).ToList();
            var Purchasehis = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == date).ToList();
            int saleSumAmount = 0;
            int saleSumPrice = 0;
            int PurchaseSumAmount = 0;
            int PurchaseSumPrice = 0;
            foreach (var item in mush)
            {

                saleSumAmount = 0;
                saleSumPrice = 0;
                PurchaseSumAmount = 0;
                PurchaseSumPrice = 0;
                if (salehis.Any(s => s.MushroomID == item.MushroomID))
                {
                    foreach (var item2 in salehis)
                    {
                        if (item2.MushroomID == item.MushroomID)
                        {
                            saleSumAmount += item2.amount;
                            saleSumPrice += item2.Sum;
                        }
                    }
                }
                if (Purchasehis.Any(p => p.MushroomID == item.MushroomID))
                {
                    foreach (var item2 in Purchasehis)
                    {
                        if (item2.MushroomID == item.MushroomID)
                        {
                            PurchaseSumAmount += item2.amount;
                            PurchaseSumPrice += item2.Sum;
                        }
                    }
                }
                var date2 = "";
                if (txtFromDate.Text == "    /  /")
                {
                    date2 = GetDate();
                }
                else
                {
                    date2 = txtFromDate.Text;
                }
                if (salehis.Any(s => s.MushroomID == item.MushroomID && s.amount > 0) || Purchasehis.Any(p => p.MushroomID == item.MushroomID && p.amount > 0))
                {

                    Comparison com = new Comparison()
                    {
                        Date = date2,
                        MushroomID = item.MushroomID,
                        MushroomName = item.Name,
                        PurchaseSumAmount = PurchaseSumAmount,
                        PurchaseSumPrice = PurchaseSumPrice,
                        SaleSumAmount = saleSumAmount,
                        SaleSumPrice = saleSumPrice
                    };
                    var comparison = _comparisonRepository.GetAllComparison().ToList();
                    var count = _comparisonRepository.GetAllComparison().Where(c => c.Date == date2).Count();
                    if (comparison.Any(c => c.MushroomID == item.MushroomID && c.Date == date2))
                    {
                        var comparison2 = _comparisonRepository.GetAllComparison().Where(c => c.Date == date2);
                        foreach (var item3 in comparison2)
                        {
                            if (item3.MushroomID == item.MushroomID)
                            {
                                item3.Date = date2;
                                item3.MushroomID = item.MushroomID;
                                item3.MushroomName = item.Name;
                                item3.PurchaseSumAmount = PurchaseSumAmount;
                                item3.PurchaseSumPrice = PurchaseSumPrice;
                                item3.SaleSumAmount = saleSumAmount;
                                item3.SaleSumPrice = saleSumPrice;
                                _comparisonRepository.UpdateComparison(item3);
                                _comparisonRepository.Save();
                            }
                        }
                    }
                    else
                    {
                        _comparisonRepository.InsertComparison(com);
                        _comparisonRepository.Save();
                    }
                }
                else
                {
                    var comparison = _comparisonRepository.GetAllComparison().ToList();
                    if (comparison.Any(c => c.MushroomID == item.MushroomID))
                    {
                        foreach (var c in comparison)
                        {
                            if (c.MushroomID == item.MushroomID)
                            {
                                _comparisonRepository.DeleteComparison(c);
                                _comparisonRepository.Save();
                            }
                        }
                    }
                }
            }

        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            if (rdSale.Checked)
            {
                dgSaleHistory.AutoGenerateColumns = false;
                dgSaleHistory.Columns[3].HeaderText = "نام مشتری";
                dgSaleHistory.Columns[3].DataPropertyName = "CustomerName";
                dgSaleHistory.Columns[2].DataPropertyName = "CustomerID";
                dgSaleHistory.Columns[6].DefaultCellStyle.Format = "#,#";
                dgSaleHistory.Columns[7].DefaultCellStyle.Format = "#,#";
                dgSaleHistory.Columns[8].DefaultCellStyle.Format = "#,#";
                if (txtFromDate.Text == "    /  /")
                {
                    dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).ToList();
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();

                }
                else
                {
                    dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
            }
            else
            {
                dgSaleHistory.AutoGenerateColumns = false;
                dgSaleHistory.Columns[3].HeaderText = "نام سالن دار";
                dgSaleHistory.Columns[3].DataPropertyName = "SellerName";
                dgSaleHistory.Columns[2].DataPropertyName = "SellerID";
                if (txtFromDate.Text == "    /  /")
                {
                    dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(s => s.Date == GetDate()).ToList();
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == GetDate()).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == GetDate()).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
                else
                {
                    dgSaleHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).ToList();
                    var buysum = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text).Select(p => p.Sum).ToList();
                    txtBuySum.Text = buysum.Sum().ToString();
                    var salesum = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text).Select(s => s.Sum).ToList();
                    txtSaleSum.Text = salesum.Sum().ToString();
                }
            }
            label4.Text = "";
            label6.Text = "";
            txtCostetc.Text = "";
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


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmDebtsCredts frm = new frmDebtsCredts();
            frm.a = false;
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (label4.Text != "")
            {
                DataTable datetime = new DataTable();
                datetime.Columns.Add("date");
                if (txtFromDate.Text == "    /  /")
                {
                    datetime.Rows.Add(GetDate());
                }
                else
                {
                    datetime.Rows.Add(txtFromDate.Text);
                }
                if (rdSale.Checked)
                {
                    stiReport1.Load(Application.StartupPath + @"\Report.mrt");
                }
                else
                {
                    stiReport1.Load(Application.StartupPath + @"\Report2.mrt");
                }
                stiReport1.RegData("datetime", datetime);

                DataTable dt = new DataTable();

                dt.Columns.Add("Date");
                dt.Columns.Add("ID");
                dt.Columns.Add("CustomerName");
                dt.Columns.Add("MushroomName");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Price");
                dt.Columns.Add("Sum");
                dt.Columns.Add("Paid");
                dt.Columns.Add("Description");
                //if (rdSale.Checked)
                //{
                foreach (DataGridViewRow item in dgSaleHistory.Rows)
                {
                    dt.Rows.Add(
                        item.Cells[1].Value.ToString(),
                        item.Cells[2].Value.ToString(),
                        item.Cells[3].Value.ToString(),
                        item.Cells[4].Value.ToString(),
                        item.Cells[5].Value.ToString(),
                        item.Cells[6].Value.ToString(),
                        item.Cells[7].Value.ToString(),
                        item.Cells[8].Value.ToString(),
                        item.Cells[9].Value?.ToString()
                        );
                }
                if (rdSale.Checked)
                {
                    stiReport1.Load(Application.StartupPath + @"\Report.mrt");
                    stiReport1.RegData("DT", dt);
                }
                else
                {
                    stiReport1.Load(Application.StartupPath + @"\Report2.mrt");
                    stiReport1.RegData("DT", dt);
                }
                //}
                //else
                //{
                //    foreach (DataGridViewRow item in dgPurchaseHistory.Rows)
                //    {
                //        dt.Rows.Add(
                //            item.Cells[1].Value.ToString(),
                //            item.Cells[2].Value.ToString(),
                //            item.Cells[3].Value.ToString(),
                //            item.Cells[4].Value.ToString(),
                //            item.Cells[5].Value.ToString(),
                //            item.Cells[6].Value.ToString(),
                //            item.Cells[7].Value.ToString(),
                //            item.Cells[8].Value.ToString(),
                //            item.Cells[9].Value?.ToString()
                //            );
                //    }
                //    
                //}




                DataTable dt2 = new DataTable();
                dt2.Columns.Add("PurchaseSum");
                dt2.Columns.Add("SaleSum");
                dt2.Columns.Add("Costetc");
                dt2.Columns.Add("Check");
                dt2.Rows.Add(
                    txtBuySum.Text.Replace(",", ""),
                    txtSaleSum.Text.Replace(",", ""),
                    txtCostetc.Text.Replace(",", ""),
                    Convert.ToInt32(label6.Text).ToString("#,#") + " " + label4.Text
                    );
                if (rdSale.Checked)
                {
                    stiReport1.Load(Application.StartupPath + @"\Report.mrt");
                }
                else
                {
                    stiReport1.Load(Application.StartupPath + @"\Report2.mrt");
                }
                stiReport1.RegData("DT2", dt2);

                DataTable dt3 = new DataTable();
                dt3.Columns.Add("SaleSumPrice");
                dt3.Columns.Add("SaleSumAmount");
                dt3.Columns.Add("PurchaseSumPrice");
                dt3.Columns.Add("PurchaseSumAmount");
                dt3.Columns.Add("MushroomName");

                var date = "";
                if (txtFromDate.Text == "    /  /")
                {
                    date = GetDate();
                }
                else
                {
                    date = txtFromDate.Text;
                }
                var com = _comparisonRepository.GetAllComparison().Where(c => c.Date == date).ToList();
                foreach (var item in com)
                {
                    dt3.Rows.Add(
                             item.SaleSumPrice,
                             item.SaleSumAmount,
                             item.PurchaseSumPrice,
                             item.PurchaseSumAmount,
                             item.MushroomName
                            );
                }

                if (rdSale.Checked)
                {
                    stiReport1.Load(Application.StartupPath + @"\Report.mrt");
                }
                else
                {
                    stiReport1.Load(Application.StartupPath + @"\Report2.mrt");
                }
                stiReport1.RegData("DT3", dt3);
                stiReport1.Show();
            }
            else
            {
                MessageBox.Show("لطفا ابتدا سود و زیان را محاسبه کنید");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.a = true;
            frm.ShowDialog();
        }
        public string LabelText4
        {
            get
            {
                return this.label4.Text;
            }
            set
            {
                this.label4.Text = value;
            }
        }
        public string LabelText6
        {
            get
            {
                return this.label6.Text;
            }
            set
            {
                this.label6.Text = value;
            }
        }
        public void SetLabel4(string newText)
        {
            Invoke(new Action(() => label4.Text = newText));
        }
        public void SetLabel6(string newText)
        {
            Invoke(new Action(() => label6.Text = newText));
        }

        private void txtBuySum_TextChanged(object sender, EventArgs e)
        {
            if (txtBuySum.Text == "" || txtBuySum.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtBuySum.Text, System.Globalization.NumberStyles.Currency);
            txtBuySum.Text = price.ToString("#,#");

            txtBuySum.Select(txtBuySum.TextLength, 0);
        }

        private void txtSaleSum_TextChanged(object sender, EventArgs e)
        {
            if (txtSaleSum.Text == "" || txtSaleSum.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtSaleSum.Text, System.Globalization.NumberStyles.Currency);
            txtSaleSum.Text = price.ToString("#,#");
            txtSaleSum.Select(txtSaleSum.TextLength, 0);
        }

        private void txtCostetc_TextChanged(object sender, EventArgs e)
        {
            if (txtCostetc.Text == "" || txtCostetc.Text == "0") return;
            decimal price;
            price = decimal.Parse(txtCostetc.Text, System.Globalization.NumberStyles.Currency);
            txtCostetc.Text = price.ToString("#,#");
            txtCostetc.Select(txtCostetc.TextLength, 0);
        }

        private void txtBuySum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSaleSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCostetc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuySum_Leave(object sender, EventArgs e)
        {
            if(txtBuySum.Text == "")
            {
                txtBuySum.Text = "0";
            }
        }

        private void txtSaleSum_Leave(object sender, EventArgs e)
        {
            if (txtSaleSum.Text == "")
            {
                txtSaleSum.Text = "0";
            }
        }

        private void txtCostetc_Leave(object sender, EventArgs e)
        {
            if (txtCostetc.Text == "")
            {
                txtCostetc.Text = "0";
            }
        }
    }
}
