/*
 * FILE             : IDatabaseHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for handling CRUD commands on a database.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServer.DataAccess
{
    public interface IDatabaseHandler
    {
        bool Connect();
        bool Disconnect();
        bool Execute(string sqlCommand);        // Used for Create, Update, Delete
        DataTable Select(string selectQuery);   // Used for Read
    }
}
