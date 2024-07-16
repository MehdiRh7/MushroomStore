using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PurchaseHistoryRepository:IPurchaseHistoryRepository
    {
        private MyContext db;
        public PurchaseHistoryRepository(MyContext context)
        {
            this.db = context; 
        }
        public IEnumerable<PurchaseHistory> GetAllPurchaseHistory()
        {
            return db.purchaseHistories.ToList();
        }

        public PurchaseHistory GetPurchaseHistoryById(int id)
        {
            var PH = db.purchaseHistories.Find(id);
            return PH;
        }

        public bool InsertPurchaseHistory(PurchaseHistory PH)
        {
            try
            {
                db.purchaseHistories.Add(PH);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePurchaseHistory(int id)
        {
            try
            {
                var PH = db.purchaseHistories.Find(id);
                DeletePurchaseHistory(PH);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePurchaseHistory(PurchaseHistory PH)
        {
            try
            {
                db.Entry(PH).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePurchaseHistory(PurchaseHistory PH)
        {
            try
            {
                var local = db.Set<PurchaseHistory>()
                        .Local
                        .FirstOrDefault(p => p.SellerID == PH.SellerID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(PH).State = EntityState.Modified;
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
