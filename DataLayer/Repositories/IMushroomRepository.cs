using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IMushroomRepository
    {
        IEnumerable<Mushrooms> GetAllMushrooms();
        Mushrooms GetMushroomById(int id);
        bool InsertMushroom(Mushrooms mush);
        bool DeleteMushroom(int id);
        bool DeleteMushroom(Mushrooms mush);
        bool UpdateMushroom(Mushrooms mush);
        void Save();
    }
}
