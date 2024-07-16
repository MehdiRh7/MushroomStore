using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Sellers
    {
        [Key]
        public int SellerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int credit { get; set; }
        public int debt { get; set; }


        public PurchaseHistory purchaseHistory { get; set; } 

        public Sellers()
        {

        }
    }
}
