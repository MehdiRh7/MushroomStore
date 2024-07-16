using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private MyContext db;
        public CustomerRepository(MyContext context)
        {
            this.db = context;
        }
        public IEnumerable<Customers> GetAllCustomers()
        {
            return db.customer.ToList();
        }

        public Customers GetCustomerById(int id)
        {
            var cus = db.customer.Find(id);
            return cus;
        }

        public bool InsertCustomer(Customers cus)
        {
            try
            {
                db.customer.Add(cus);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                var cus = db.customer.Find(id);
                DeleteCustomer(cus);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customers cus)
        {
            try
            {
                db.Entry(cus).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCustomer(Customers cus)
        {
            try
            {
                var local = db.Set<Customers>()
                        .Local
                        .FirstOrDefault(c => c.CustomerID == cus.CustomerID);
                if (local != null)
                {
                    db.Entry(local).State = EntityState.Detached;
                }
                db.Entry(cus).State = EntityState.Modified;
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
