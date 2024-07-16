using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
    public class MushroomRepository : IMushroomRepository
    {

        private MyContext db;
        public MushroomRepository(MyContext context)
        {
            this.db = context;
        }
        public IEnumerable<Mushrooms> GetAllMushrooms()
        {
            return db.mushroom;
        }

        public Mushrooms GetMushroomById(int id)
        {
            var mush = db.mushroom.Find(id);
            return mush;
        }

        public bool InsertMushroom(Mushrooms mush)
        {
            try
            {
                db.mushroom.Add(mush);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteMushroom(int id)
        {
            try
            {
                var mush = db.mushroom.Find(id);
                DeleteMushroom(mush);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMushroom(Mushrooms mush)
        {
            try
            {
                db.Entry(mush).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateMushroom(Mushrooms mush)
        {
            try
            {
                db.Entry(mush).State = EntityState.Modified;
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
