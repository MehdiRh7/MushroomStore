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

namespace MushroomStore
{
    public partial class frmDebtsCredts : Form
    {
        public bool a = false;
        
        MyContext db = new MyContext();
        ICustomerRepository _customerRepository;
        ISellerRepository _sellerRepository;
        public frmDebtsCredts()
        {
            _customerRepository = new CustomerRepository(db);
            _sellerRepository = new SellerRepository(db);
            InitializeComponent();
        }

        private void frmDebtsCredts_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgDebtsCredits.Columns[4].DefaultCellStyle.Format = "#,#";
            dgDebtsCredits.Columns[5].DefaultCellStyle.Format = "#,#";

            if (a == false)
            {
                MyContext db = new MyContext();
                _customerRepository = new CustomerRepository(db);
                rdCustomer.Checked = true;
                dgDebtsCredits.AutoGenerateColumns = false;
                dgDebtsCredits.DataSource = _customerRepository.GetAllCustomers().Where(c => c.credit != 0 || c.debt != 0).ToList();
            }
            else
            {
                MyContext db = new MyContext();
                _sellerRepository = new SellerRepository(db);
                rdSeller.Checked = true;
                dgDebtsCredits.AutoGenerateColumns = false;
                dgDebtsCredits.DataSource = _sellerRepository.GetAllSellers().Where(s => s.credit != 0 || s.debt != 0).ToList();
            }
        }

        private void rdCustomer_CheckedChanged(object sender, EventArgs e)
        {
            dgDebtsCredits.Columns[4].DefaultCellStyle.Format = "#,#";
            dgDebtsCredits.Columns[5].DefaultCellStyle.Format = "#,#";
            MyContext db = new MyContext();
            _customerRepository = new CustomerRepository(db);
            dgDebtsCredits.Columns[0].DataPropertyName = "CustomerID";
            dgDebtsCredits.AutoGenerateColumns = false;
            dgDebtsCredits.DataSource = _customerRepository.GetAllCustomers().Where(c => c.credit != 0 || c.debt != 0).ToList();
        }

        private void rdSeller_CheckedChanged(object sender, EventArgs e)
        {
            dgDebtsCredits.Columns[4].DefaultCellStyle.Format = "#,#";
            dgDebtsCredits.Columns[5].DefaultCellStyle.Format = "#,#";
            MyContext db = new MyContext();
            _sellerRepository = new SellerRepository(db);
            dgDebtsCredits.Columns[0].DataPropertyName = "SellerID";
            dgDebtsCredits.AutoGenerateColumns = false;
            dgDebtsCredits.DataSource = _sellerRepository.GetAllSellers().Where(s => s.credit != 0 || s.debt != 0).ToList();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmMinus frm = new frmMinus();
            frm.aa = false;
            if (rdCustomer.Checked)
            {
                if (dgDebtsCredits.CurrentRow != null)
                {
                    if ((int)dgDebtsCredits.CurrentRow.Cells[4].Value > 0)
                    {
                        int CustomerId = int.Parse(dgDebtsCredits.CurrentRow.Cells[0].Value.ToString());
                        frm.id = CustomerId;
                        frm.a = false;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            MyContext db = new MyContext();
                            _customerRepository = new CustomerRepository(db);
                            dgDebtsCredits.Columns[0].DataPropertyName = "CustomerID";
                            dgDebtsCredits.AutoGenerateColumns = false;
                            dgDebtsCredits.DataSource = _customerRepository.GetAllCustomers().Where(c => c.credit != 0 || c.debt != 0).ToList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("مشتری بدهی ندارد");
                    }
                }
                
            }
            else
            {
                if (dgDebtsCredits.CurrentRow != null)
                {
                    if ((int)dgDebtsCredits.CurrentRow.Cells[4].Value > 0)
                    {
                        int SellerId = int.Parse(dgDebtsCredits.CurrentRow.Cells[0].Value.ToString());
                        frm.id = SellerId;
                        frm.a = true;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            MyContext db = new MyContext();
                            _sellerRepository = new SellerRepository(db);
                            dgDebtsCredits.Columns[0].DataPropertyName = "SellerID";
                            dgDebtsCredits.AutoGenerateColumns = false;
                            dgDebtsCredits.DataSource = _sellerRepository.GetAllSellers().Where(s => s.credit != 0 || s.debt != 0).ToList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("سالن دار بدهی ندارد");
                    }
                }
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmMinus frm = new frmMinus();
            frm.aa = true;
            if (rdCustomer.Checked)
            {
                if (dgDebtsCredits.CurrentRow != null)
                {
                    if ((int)dgDebtsCredits.CurrentRow.Cells[5].Value > 0)
                    {
                        int CustomerId = int.Parse(dgDebtsCredits.CurrentRow.Cells[0].Value.ToString());
                        frm.id = CustomerId;
                        frm.a = false;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            MyContext db = new MyContext();
                            _customerRepository = new CustomerRepository(db);
                            dgDebtsCredits.Columns[0].DataPropertyName = "CustomerID";
                            dgDebtsCredits.AutoGenerateColumns = false;
                            dgDebtsCredits.DataSource = _customerRepository.GetAllCustomers().Where(c => c.credit != 0 || c.debt != 0).ToList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("مشتری طلبی ندارد");
                    }
                }

            }
            else
            {
                if (dgDebtsCredits.CurrentRow != null)
                {
                    if ((int)dgDebtsCredits.CurrentRow.Cells[5].Value > 0)
                    {
                        int SellerId = int.Parse(dgDebtsCredits.CurrentRow.Cells[0].Value.ToString());
                        frm.id = SellerId;
                        frm.a = true;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            MyContext db = new MyContext();
                            _sellerRepository = new SellerRepository(db);
                            dgDebtsCredits.Columns[0].DataPropertyName = "SellerID";
                            dgDebtsCredits.AutoGenerateColumns = false;
                            dgDebtsCredits.DataSource = _sellerRepository.GetAllSellers().Where(s => s.credit != 0 || s.debt != 0).ToList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("سالن دار طلبی ندارد");
                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable datetime = new DataTable();
            datetime.Columns.Add("date");
            datetime.Rows.Add(GetDate());

            if (rdCustomer.Checked)
            {
                stiReport1.Load(Application.StartupPath + @"\Report3.mrt");
            }
            else
            {
                stiReport1.Load(Application.StartupPath + @"\Report4.mrt");
            }
            stiReport1.RegData("datetime", datetime);
            DataTable dt = new DataTable();
            dt.Columns.Add("Credit");
            dt.Columns.Add("Debt");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("LastName");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("ID");

            if (rdCustomer.Checked)
            {
                foreach (DataGridViewRow item in dgDebtsCredits.Rows)
                {
                    dt.Rows.Add(
                        item.Cells[5].Value.ToString(),
                        item.Cells[4].Value.ToString(),
                        item.Cells[3].Value.ToString(),
                        item.Cells[2].Value.ToString(),
                        item.Cells[1].Value.ToString(),
                        item.Cells[0].Value.ToString()
                        );
                }
                stiReport1.Load(Application.StartupPath + @"\Report3.mrt");
                stiReport1.RegData("DT", dt);
            }
            else
            {
                foreach (DataGridViewRow item in dgDebtsCredits.Rows)
                {
                    dt.Rows.Add(
                        item.Cells[5].Value.ToString(),
                        item.Cells[4].Value.ToString(),
                        item.Cells[3].Value.ToString(),
                        item.Cells[2].Value.ToString(),
                        item.Cells[1].Value.ToString(),
                        item.Cells[0].Value.ToString()
                        );
                }
                stiReport1.Load(Application.StartupPath + @"\Report4.mrt");
                stiReport1.RegData("DT", dt);
            }
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

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
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
    }
}
