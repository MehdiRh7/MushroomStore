using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SaleHistoryRepository:ISaleHistoryRepository
    {
        private MyContext db;
        public SaleHistoryRepository(MyContext context)
        {
            this.db = context;
        }
        public IEnumerable<SaleHistory> GetAllSaleHistory()
        {
            return db.saleHistories.ToList();
        }

        public SaleHistory GetSaleHistoryById(int id)
        {
            var SH = db.saleHistories.Find(id);
            return SH;
        }

        public bool InsertSaleHistory(SaleHistory SH)
        {
            try
            {
                db.saleHistories.Add(SH);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSaleHistory(int id)
        {
            try
            {
                var SH = db.saleHistories.Find(id);
                DeleteSaleHistory(SH);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSaleHistory(SaleHistory SH)
        {
            try
            {
                db.Entry(SH).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSaleHistory(SaleHistory SH)
        {
            try
            {
                var local = db.Set<SaleHistory>()
                        .Local
                        .FirstOrDefault(c => c.SaleID == SH.SaleID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(SH).State = EntityState.Modified;
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
