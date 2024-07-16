using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISellerRepository
    {
        IEnumerable<Sellers> GetAllSellers();
        Sellers GetSellerById(int id);
        bool InsertSeller(Sellers sel);
        bool DeleteSeller(int id);
        bool DeleteSeller(Sellers sel);
        bool UpdateSeller(Sellers sel);
        void Save();
    }
}
