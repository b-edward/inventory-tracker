using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.Log
{
    public interface ILogger
    {
        // Property
        string LogPath { get; set; }

        // Methods
        bool Log(string message);
    }
}
