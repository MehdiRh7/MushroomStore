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
    public partial class frmAddMushroom : Form
    {
        MyContext db = new MyContext();
        IMushroomRepository _mushroomRepository;
        public frmAddMushroom()
        {
            _mushroomRepository = new MushroomRepository(db);
            InitializeComponent();
        }

        private void btnMushroomRecord_Click(object sender, EventArgs e)
        {
            if (txtMushroomName.Text == "")
            {
                MessageBox.Show("لطفا نوع قارچ را وارد کنید");
            }
            
            else
            {
                Mushrooms mush = new Mushrooms()
                {
                    Name = txtMushroomName.Text
                };
                _mushroomRepository.InsertMushroom(mush);
                _mushroomRepository.Save();
                txtMushroomName.Text = "";
            }
        }


    }
}
