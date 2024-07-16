using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISaleHistoryRepository
    {
        IEnumerable<SaleHistory> GetAllSaleHistory();
        SaleHistory GetSaleHistoryById(int id);
        bool InsertSaleHistory(SaleHistory SH);
        bool DeleteSaleHistory(int id);
        bool DeleteSaleHistory(SaleHistory SH);
        bool UpdateSaleHistory(SaleHistory SH);
        void Save();
    }
}
