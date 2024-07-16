using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {

        private MyContext db;
        public LoginRepository(MyContext context)
        {
            this.db = context;
        }
        public IEnumerable<Login> GetAllLogins()
        {
            return db.login.ToList();
        }

        public bool InsertLogin(Login log)
        {
            try
            {
                db.login.Add(log);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteLogin(int id)
        {
            try
            {
                DeleteLogin(db.login.Find(id));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLogin(Login log)
        {
            try
            {
                db.Entry(log).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateLogin(Login log)
        {
            try
            {
                var local = db.Set<Login>()
                        .Local
                        .FirstOrDefault(c => c.LoginID == log.LoginID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(log).State = System.Data.Entity.EntityState.Modified;
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
