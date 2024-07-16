using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IComparisonRepository
    {
        IEnumerable<Comparison> GetAllComparison();
        Comparison GetComparisonById(int id);
        bool InsertComparison(Comparison com);
        bool DeleteComparison(int id);
        bool DeleteComparison(Comparison com);
        bool UpdateComparison(Comparison com);
        void Save();
    }
}
