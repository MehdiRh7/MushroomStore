using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Mushrooms
    {
        [Key]
        public int MushroomID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int amount { get; set; }



        public SaleHistory saleHistory { get; set; }
        public PurchaseHistory purchaseHistory { get; set; }
        public Comparison comparison { get; set; }


        public Mushrooms()
        {

        }
    }
}
