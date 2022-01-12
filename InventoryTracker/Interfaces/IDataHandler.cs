/*
 * FILE             : IDataHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 09
 * DESCRIPTION      : This file contains an interface for making CRUD requests.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker.Interfaces
{
    public interface IDataHandler
    {
        bool Create(string query);
        string Read(string query);
        bool Update(string query);
        bool Delete(string query);
    }
}
