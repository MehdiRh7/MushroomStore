using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataLayer
{
    public class ComparisonRepository : IComparisonRepository
    {
        private MyContext db;

        public ComparisonRepository(MyContext context)
        {
            this.db = context;
        }

        public bool DeleteComparison(int id)
        {
            try
            {
                var com = GetComparisonById(id);
                DeleteComparison(com);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteComparison(Comparison com)
        {
            try
            {
                db.Entry(com).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Comparison> GetAllComparison()
        {
            return db.comparisons.ToList();
        }

        public Comparison GetComparisonById(int id)
        {
            return db.comparisons.Find(id);
        }

        public bool InsertComparison(Comparison com)
        {
            try
            {
                db.comparisons.Add(com);
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

        public bool UpdateComparison(Comparison com)
        {
            try
            {
                var local = db.Set<Comparison>()
                        .Local
                        .FirstOrDefault(c => c.MushroomID == com.MushroomID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(com).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
