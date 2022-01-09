using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Interfaces
{
    public interface IRequestHandler
    {
        bool HandleRequest(Object clientObject);
        string GetRequest(Object networkObject);
        bool SendResponse(Object networkObject, string response);
    }
}
