/*
 * FILE             : IRequestHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for handling requests.
 */

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
    }
}
