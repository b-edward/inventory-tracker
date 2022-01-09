using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.DataAccess
{
    public interface IDatabase
    {
        bool Connect();
        bool Disconnect();
        bool Execute(string sqlCommand);
        DataTable Select(string selectQuery);
    }
}
