using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MushroomStore
{
    public partial class frmSaleHistory : Form
    {
        MyContext db = new MyContext();
        ISaleHistoryRepository _saleHistoryRepository;
        IPurchaseHistoryRepository _purchaseHistoryRepository;
        ISellerRepository _sellerRepository;
        ICustomerRepository _customerRepository;
        public int id = 0;
        public bool a = false;
        public bool aa = false;
        public int before = 0;
        public frmSaleHistory()
        {
            _saleHistoryRepository = new SaleHistoryRepository(db);
            _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
            _sellerRepository = new SellerRepository(db);
            _customerRepository = new CustomerRepository(db);
            InitializeComponent();
        }

        private void frmSaleHistory_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            dgSaleHistory.Columns[6].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[7].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[8].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[9].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[10].DefaultCellStyle.Format = "#,#";

            dgPurchaseHistory.Columns[6].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[7].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[8].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[9].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[10].DefaultCellStyle.Format = "#,#";
            if (a == true)
            {
                dgPurchaseHistory.Visible = false;
                dgSaleHistory.Visible = true;
                var sale = _saleHistoryRepository.GetAllSaleHistory();
                var sale2 = sale.Where(s => s.CustomerID == id).ToList();
                dgSaleHistory.AutoGenerateColumns = false;
                dgSaleHistory.DataSource = sale2;
                label2.Text = sale2.Select(s => s.Sum).Sum().ToString("#,#");
                label4.Text = sale2.Select(s => s.Debt).Sum().ToString("#,#");
                label6.Text = sale2.Select(s => s.Credit).Sum().ToString("#,#");
            }
            else
            {
                dgPurchaseHistory.Visible = true;
                dgSaleHistory.Visible = false;
                var pur = _purchaseHistoryRepository.GetAllPurchaseHistory();
                var pur2 = pur.Where(s => s.SellerID == id).ToList();
                dgPurchaseHistory.AutoGenerateColumns = false;
                dgPurchaseHistory.DataSource = pur2;
                label2.Text = pur2.Select(p => p.Sum).Sum().ToString("#,#");
                label4.Text = pur2.Select(p => p.Debt).Sum().ToString("#,#");
                label6.Text = pur2.Select(p => p.Credit).Sum().ToString("#,#");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditHistory frm = new frmEditHistory();
            if (aa == false)
            {

                if (dgSaleHistory.CurrentRow != null)
                {
                    int SaleId = int.Parse(dgSaleHistory.CurrentRow.Cells[0].Value.ToString());
                    frm.id = SaleId;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MyContext db = new MyContext();
                        _saleHistoryRepository = new SaleHistoryRepository(db);
                        var sale = _saleHistoryRepository.GetAllSaleHistory();
                        var sale2 = sale.Where(s => s.CustomerID == id).ToList();
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.DataSource = sale2;
                        label2.Text = sale2.Select(s => s.Sum).Sum().ToString("#,#");
                        label4.Text = sale2.Select(s => s.Debt).Sum().ToString("#,#");
                        label6.Text = sale2.Select(s => s.Credit).Sum().ToString("#,#");

                    }
                }
            }
            else
            {

                if (dgPurchaseHistory.CurrentRow != null)
                {
                    int PurchaseId = int.Parse(dgPurchaseHistory.CurrentRow.Cells[0].Value.ToString());
                    frm.id = PurchaseId;
                    frm.a = true;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MyContext db = new MyContext();
                        _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
                        var pur = _purchaseHistoryRepository.GetAllPurchaseHistory();
                        var pur2 = pur.Where(s => s.SellerID == id).ToList();
                        dgPurchaseHistory.AutoGenerateColumns = false;
                        dgPurchaseHistory.DataSource = pur2;
                        label2.Text = pur2.Select(p => p.Sum).Sum().ToString("#,#");
                        label4.Text = pur2.Select(p => p.Debt).Sum().ToString("#,#");
                        label6.Text = pur2.Select(p => p.Credit).Sum().ToString("#,#");

                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Description");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Debt");
            dt.Columns.Add("Paid");
            dt.Columns.Add("Sum");
            dt.Columns.Add("Price");
            dt.Columns.Add("Amount");
            dt.Columns.Add("MushroomName");
            dt.Columns.Add("Name");
            dt.Columns.Add("ID");
            dt.Columns.Add("Date");
            if (a == true)
            {
                foreach (DataGridViewRow item in dgSaleHistory.Rows)
                {
                    dt.Rows.Add(
                        item.Cells[11].Value.ToString(),
                        item.Cells[10].Value.ToString(),
                        item.Cells[9].Value.ToString(),
                        item.Cells[8].Value.ToString(),
                        item.Cells[7].Value.ToString(),
                        item.Cells[6].Value.ToString(),
                        item.Cells[5].Value.ToString(),
                        item.Cells[4].Value.ToString(),
                        item.Cells[3].Value.ToString(),
                        item.Cells[2].Value.ToString(),
                        item.Cells[1].Value.ToString()
                        );
                }
                stiReport1.Load(Application.StartupPath + @"\Report5.mrt");
                stiReport1.RegData("DT", dt);
            }
            else
            {
                foreach (DataGridViewRow item in dgPurchaseHistory.Rows)
                {
                    dt.Rows.Add(
                        item.Cells[11].Value.ToString(),
                        item.Cells[10].Value.ToString(),
                        item.Cells[9].Value.ToString(),
                        item.Cells[8].Value.ToString(),
                        item.Cells[7].Value.ToString(),
                        item.Cells[6].Value.ToString(),
                        item.Cells[5].Value.ToString(),
                        item.Cells[4].Value.ToString(),
                        item.Cells[3].Value.ToString(),
                        item.Cells[2].Value.ToString(),
                        item.Cells[1].Value.ToString()
                        );
                }
                stiReport1.Load(Application.StartupPath + @"\Report6.mrt");
                stiReport1.RegData("DT", dt);
            }
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("BuySum");
            dt2.Columns.Add("DebtSum");
            dt2.Columns.Add("CreditSum");
            dt2.Rows.Add(
                label2.Text.Replace(",", ""),
                label4.Text.Replace(",", ""),
                label6.Text.Replace(",", "")
                );
            if (a == true)
            {
                stiReport1.Load(Application.StartupPath + @"\Report5.mrt");
            }
            else
            {
                stiReport1.Load(Application.StartupPath + @"\Report6.mrt");
            }
            stiReport1.RegData("DT2", dt2);
            stiReport1.Show();
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            if (aa == false)
            {

                if (dgSaleHistory.CurrentRow != null)
                {
                    int SaleId = int.Parse(dgSaleHistory.CurrentRow.Cells[0].Value.ToString());
                    if (MessageBox.Show($"آیا از حذف اطمینان دارید ؟\n با حذف این تاریخچه لیست بدهی و طلب ها بروز میشود", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        var s = _saleHistoryRepository.GetSaleHistoryById(SaleId);
                        var customer = _customerRepository.GetCustomerById(id);

                        if (customer.debt > 0)
                        {
                            if (s.Debt > 0)
                            {
                                if (customer.debt - s.Debt >= 0)
                                {
                                    customer.debt -= s.Debt;
                                }
                                else
                                {
                                    customer.credit = System.Math.Abs(customer.debt - s.Debt);
                                    customer.debt = 0;
                                }
                            }
                            else if (s.Credit > 0)
                            {
                                customer.debt += s.Credit;
                            }
                        }
                        else if (customer.credit > 0)
                        {
                            if (s.Debt > 0)
                            {
                                customer.credit += s.Debt;
                            }
                            else if (s.Credit > 0)
                            {
                                if(customer.credit - s.Credit >= 0)
                                {
                                    customer.credit -= s.Credit;
                                }
                                else
                                {
                                    customer.debt = System.Math.Abs(customer.credit - s.Credit);
                                    customer.credit = 0;
                                }
                            }
                        }
                        else
                        {
                            if(s.Debt > 0)
                            {
                                customer.credit = s.Debt;
                            }
                            else if(s.Credit > 0)
                            {
                                customer.debt = s.Credit;
                            }
                        }


                        _customerRepository.UpdateCustomer(customer);
                        _customerRepository.Save();
                        MyContext db = new MyContext();
                        _saleHistoryRepository = new SaleHistoryRepository(db);
                        _saleHistoryRepository.DeleteSaleHistory(SaleId);
                        _saleHistoryRepository.Save();
                        dgPurchaseHistory.Visible = false;
                        dgSaleHistory.Visible = true;
                        var sale = _saleHistoryRepository.GetAllSaleHistory();
                        var sale2 = sale.Where(ss => ss.CustomerID == id).ToList();
                        dgSaleHistory.AutoGenerateColumns = false;
                        dgSaleHistory.DataSource = sale2;
                        label2.Text = sale2.Select(ss => ss.Sum).Sum().ToString();
                        label4.Text = sale2.Select(ss => ss.Debt).Sum().ToString();
                        label6.Text = sale2.Select(ss => ss.Credit).Sum().ToString();
                        Program.ch = 1;
                    }
                }
            }
            else
            {

                if (dgPurchaseHistory.CurrentRow != null)
                {
                    int PurchaseId = int.Parse(dgPurchaseHistory.CurrentRow.Cells[0].Value.ToString());
                    if (MessageBox.Show($"آیا از حذف اطمینان دارید ؟\n با حذف این تاریخچه لیست بدهی و طلب ها بروز میشود", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var p = _purchaseHistoryRepository.GetPurchaseHistoryById(PurchaseId);
                        var seller = _sellerRepository.GetSellerById(id);

                        if(seller.debt > 0)
                        {
                            if(p.Debt > 0)
                            {
                                if(seller.debt - p.Debt >= 0)
                                {
                                    seller.debt -= p.Debt;
                                }
                                else
                                {
                                    seller.credit = System.Math.Abs(seller.debt - p.Debt);
                                    seller.debt = 0;
                                }
                            }
                            else if(p.Credit > 0)
                            {
                                seller.debt += p.Credit;
                            }
                        }
                        else if(seller.credit > 0)
                        {
                            if(p.Debt > 0)
                            {
                                seller.credit += p.Debt;
                            }
                            else if(p.Credit > 0)
                            {
                                if(seller.credit - p.Credit >= 0)
                                {
                                    seller.credit -= p.Credit;
                                }
                                else
                                {
                                    seller.debt = System.Math.Abs(seller.credit - p.Credit);
                                    seller.credit = 0;
                                }
                            }
                        }
                        else
                        {
                            if (p.Debt > 0)
                            {
                                seller.credit = p.Debt;
                            }
                            else if (p.Credit > 0)
                            {
                                seller.debt = p.Credit;
                            }
                        }


                        _sellerRepository.UpdateSeller(seller);
                        _sellerRepository.Save();
                        MyContext db = new MyContext();
                        _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
                        _purchaseHistoryRepository.DeletePurchaseHistory(PurchaseId);
                        _purchaseHistoryRepository.Save();
                        dgPurchaseHistory.Visible = true;
                        dgSaleHistory.Visible = false;
                        var pur = _purchaseHistoryRepository.GetAllPurchaseHistory();
                        var pur2 = pur.Where(s => s.SellerID == id).ToList();
                        dgPurchaseHistory.AutoGenerateColumns = false;
                        dgPurchaseHistory.DataSource = pur2;
                        label2.Text = pur2.Select(pp => p.Sum).Sum().ToString();
                        label4.Text = pur2.Select(pp => p.Debt).Sum().ToString();
                        label6.Text = pur2.Select(pp => p.Credit).Sum().ToString();
                        Program.ch = 1;
                    }
                }
            }
        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            dgSaleHistory.Columns[6].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[7].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[8].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[9].DefaultCellStyle.Format = "#,#";
            dgSaleHistory.Columns[10].DefaultCellStyle.Format = "#,#";

            dgPurchaseHistory.Columns[6].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[7].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[8].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[9].DefaultCellStyle.Format = "#,#";
            dgPurchaseHistory.Columns[10].DefaultCellStyle.Format = "#,#";
            if (aa == false)
            {

                if (txtFromDate.Text != "    /  /")
                {
                    var sale = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text && s.CustomerID == id).ToList();
                    dgSaleHistory.AutoGenerateColumns = false;
                    dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.Date == txtFromDate.Text && s.CustomerID == id).ToList();
                    label2.Text =sale.Select(s => s.Sum).Sum().ToString("#,#");
                    label4.Text =sale.Select(s => s.Debt).Sum().ToString("#,#");
                    label6.Text =sale.Select(s => s.Credit).Sum().ToString("#,#");
                    txtFromDate.Text = "    /  /";
                }
                else
                {
                    var sale = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.CustomerID == id).ToList();
                    dgSaleHistory.AutoGenerateColumns = false;
                    dgSaleHistory.DataSource = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.CustomerID == id).ToList();
                    label2.Text = sale.Select(s => s.Sum).Sum().ToString("#,#");
                    label4.Text = sale.Select(s => s.Debt).Sum().ToString("#,#");
                    label6.Text = sale.Select(s => s.Credit).Sum().ToString("#,#");
                }
            }
            else
            {

                if (txtFromDate.Text != "    /  /")
                {
                    var pur = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text && p.SellerID == id).ToList();
                    dgPurchaseHistory.AutoGenerateColumns = false;
                    dgPurchaseHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.Date == txtFromDate.Text && p.SellerID == id).ToList();
                    label2.Text = pur.Select(p => p.Sum).Sum().ToString("#,#");
                    label4.Text = pur.Select(p => p.Debt).Sum().ToString("#,#");
                    label6.Text = pur.Select(p => p.Credit).Sum().ToString("#,#");
                    txtFromDate.Text = "    /  /";
                }
                else
                {
                    var pur = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.SellerID == id).ToList();
                    dgPurchaseHistory.AutoGenerateColumns = false;
                    dgPurchaseHistory.DataSource = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.SellerID == id).ToList();
                    label2.Text = pur.Select(p => p.Sum).Sum().ToString("#,#");
                    label4.Text = pur.Select(p => p.Debt).Sum().ToString("#,#");
                    label6.Text = pur.Select(p => p.Credit).Sum().ToString("#,#");
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

        private void frmSaleHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
