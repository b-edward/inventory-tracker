using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Interfaces
{
    public interface IDataHandler
    {
        bool Create(string query);
        DataTable Read(string query);
        bool Update(string query);
        bool Delete(string query);
    }
}
