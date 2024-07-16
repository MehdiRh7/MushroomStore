using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyContext:DbContext
    {
        public DbSet<Mushrooms> mushroom { get; set; }
        public DbSet<Customers> customer{ get; set; }
        public DbSet<PurchaseHistory> purchaseHistories { get; set; }
        public DbSet<Sellers> sellers { get; set; }
        public DbSet<SaleHistory> saleHistories { get; set; }
        public DbSet<Comparison> comparisons { get; set; }
        public DbSet<Login> login { get; set; }

    }
}
