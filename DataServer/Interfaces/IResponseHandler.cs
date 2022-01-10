using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Interfaces
{
    public interface IResponseHandler
    {
        string ReceivedCreate(string query);
        string ReceivedRead(string query);
        string ReceivedUpdate(string query);
        string ReceivedDelete(string query);
    }
}
