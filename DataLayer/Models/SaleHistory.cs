using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SaleHistory
    {
        [Key]
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int MushroomID { get; set; }
        public string MushroomName { get; set; }
        public string Date { get; set; }
        public int amount { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
        public int Paid { get; set; }
        public int Debt { get; set; }
        public int Credit { get; set; }
        [MaxLength]
        public string Description { get; set; }





        public IEnumerable<Customers> customers { get; set; }
        public IEnumerable<Mushrooms> mushrooms { get; set; }

        public SaleHistory()
        {

        }

    }
}
