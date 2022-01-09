using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Interfaces
{
    public interface IDataRequester
    {
        string Create(string query);
        string Read(string query);
        string Update(string query);
        string Delete(string query);
    }
}
