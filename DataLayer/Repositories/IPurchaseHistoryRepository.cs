using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPurchaseHistoryRepository
    {
        IEnumerable<PurchaseHistory> GetAllPurchaseHistory();
        PurchaseHistory GetPurchaseHistoryById(int id);
        bool InsertPurchaseHistory(PurchaseHistory PH);
        bool DeletePurchaseHistory(int id);
        bool DeletePurchaseHistory(PurchaseHistory PH);
        bool UpdatePurchaseHistory(PurchaseHistory PH);
        void Save();
    }
}
