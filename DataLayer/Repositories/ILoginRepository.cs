using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILoginRepository
    {
        IEnumerable<Login> GetAllLogins();
        bool InsertLogin(Login log);
        bool DeleteLogin(int id);
        bool DeleteLogin(Login log);
        bool UpdateLogin(Login log);
        void Save();
    }
}
