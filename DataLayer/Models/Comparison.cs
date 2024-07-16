using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Comparison
    {
        [Key]
        public int ComparisonID { get; set; }
        public string Date { get; set; }
        public int MushroomID { get; set; }
        public string MushroomName { get; set; }
        public int PurchaseSumAmount { get; set; }
        public int SaleSumAmount { get; set; }
        public int PurchaseSumPrice { get; set; }
        public int SaleSumPrice { get; set; }

        public IEnumerable<Mushrooms> mushrooms { get; set; }


        public Comparison()
        {
                
        }

    }
}
