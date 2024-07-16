using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PurchaseHistory
    {
        [Key]
        public int PurchaseID { get; set; }
        public int SellerID { get; set; }
        public string SellerName { get; set; }
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




        public IEnumerable<Sellers> sellers { get; set; }
        public IEnumerable<Mushrooms> mushrooms { get; set; }

        public PurchaseHistory() 
        {

        }
    }
}
