using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAllCustomers();
        Customers GetCustomerById(int id);
        bool InsertCustomer(Customers cus);
        bool DeleteCustomer(int id);
        bool DeleteCustomer(Customers cus);
        bool UpdateCustomer(Customers cus);
        void Save();
        
    }
}
