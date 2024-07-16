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
    public partial class frmCustomers : Form
    {
        public byte ch = 0;
        MyContext db = new MyContext();
        ICustomerRepository _customerRepository;
        ISellerRepository _sellerRepository;
        ISaleHistoryRepository _saleHistoryRepository;
        IPurchaseHistoryRepository _purchaseHistoryRepository;
        public bool a = false;
        public frmCustomers()
        {
            _customerRepository = new CustomerRepository(db);
            _sellerRepository = new SellerRepository(db);
            _saleHistoryRepository = new SaleHistoryRepository(db);
            _purchaseHistoryRepository = new PurchaseHistoryRepository(db);
            InitializeComponent();
        }


        private void frmCustomers_Load_1(object sender, EventArgs e)
        {
            dgCustomers.Visible = true;
            dataGridView1.Visible = false;
            if (a == true)
            {
                this.Text = "اطلاعات سالن داران";
                this.btnAddCustomer.Text = "افزودن سالن دار";
                this.btnEditCustomer.Text = "ویرایش سالن دار";
                dgCustomers.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _sellerRepository.GetAllSellers().ToList();
            }
            else
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = _customerRepository.GetAllCustomers().ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmSaleHistory frm = new frmSaleHistory();
            if (a == false)
            {
                if (dgCustomers.CurrentRow != null)
                {
                    int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                    frm.id = CustomerId;
                    frm.a = true;
                    frm.aa = false;

                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                       
                    }
                }
            }
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int SellerId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    frm.id = SellerId;
                    frm.a = false;
                    frm.aa = true;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                frmAddCustomer frm = new frmAddCustomer();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else
            {
                frmAddCustomer frm = new frmAddCustomer();
                frm.aa = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = _sellerRepository.GetAllSellers().ToList();
                }
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            if (a == false)
            {

                if (dgCustomers.CurrentRow != null)
                {
                    int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                    frm.id = CustomerId;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MyContext db = new MyContext();
                        _customerRepository = new CustomerRepository(db);
                        BindGrid();
                    }
                }
            }
            else
            {

                if (dataGridView1.CurrentRow != null)
                {
                    int SellerId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    frm.id = SellerId;
                    frm.aa = true;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MyContext db = new MyContext();
                        _sellerRepository = new SellerRepository(db);
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = _sellerRepository.GetAllSellers().ToList();
                    }
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                if (dgCustomers.CurrentRow != null)
                {
                    int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                    string FName = dgCustomers.CurrentRow.Cells[1].Value.ToString();
                    string LName = dgCustomers.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {FName + " " + LName} اطمینان دارید ؟\n با حذف مشتری تمامی اطلاعاتشان از برنامه پاک میشود", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var sale = _saleHistoryRepository.GetAllSaleHistory().Where(s => s.CustomerID == CustomerId).ToList();
                        foreach (var item in sale)
                        {
                            _saleHistoryRepository.DeleteSaleHistory(item.SaleID);
                            _saleHistoryRepository.Save();
                        }
                        _customerRepository.DeleteCustomer(CustomerId);
                        _customerRepository.Save();
                        BindGrid();
                        Program.ch = 1;
                    }
                }
            }
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int SellerId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string FName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string LName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    if (MessageBox.Show($"آیا از حذف {FName + " " + LName} اطمینان دارید ؟\n با حذف سالن دار تمامی اطلاعاتشان از برنامه پاک میشود", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var purchase = _purchaseHistoryRepository.GetAllPurchaseHistory().Where(p => p.SellerID == SellerId).ToList();
                        foreach(var item in purchase)
                        {
                            _purchaseHistoryRepository.DeletePurchaseHistory(item.PurchaseID);
                            _purchaseHistoryRepository.Save();
                        }
                        _sellerRepository.DeleteSeller(SellerId);
                        _sellerRepository.Save();
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = _sellerRepository.GetAllSellers().ToList();
                        Program.ch = 1;
                    }
                }
            }

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (a == false)
            {
                dgCustomers.DataSource = _customerRepository.GetAllCustomers().Where(c => c.FirstName.StartsWith(txtFilter.Text) || c.LastName.StartsWith(txtFilter.Text) || (c.FirstName + " " + c.LastName).StartsWith(txtFilter.Text)).ToList();
            }
            else
            {
                dataGridView1.DataSource = _sellerRepository.GetAllSellers().Where(s => s.FirstName.StartsWith(txtFilter.Text) || s.LastName.StartsWith(txtFilter.Text) || (s.FirstName + " " + s.LastName).StartsWith(txtFilter.Text)).ToList();
            }
        }

        private void frmCustomers_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
