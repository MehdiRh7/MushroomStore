using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SellerRepository:ISellerRepository
    {
        private MyContext db;
        public SellerRepository(MyContext context)
        {
            this.db = context;
        }
        public IEnumerable<Sellers> GetAllSellers()
        {
            return db.sellers;
        }

        public Sellers GetSellerById(int id)
        {
            var sel = db.sellers.Find(id);
            return sel;
        }

        public bool InsertSeller(Sellers sel)
        {
            try
            {
                db.sellers.Add(sel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSeller(int id)
        {
            try
            {
                var sel = db.sellers.Find(id);
                DeleteSeller(sel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSeller(Sellers sel)
        {
            try
            {
                db.Entry(sel).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSeller(Sellers sel)
        {
            try
            {
                db.Entry(sel).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
