/*
 * FILE             : IResponseHandler.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IResponseHandler interface, which provides an abstraction layer for
 *                    implementing the ResponseHandler class.
 */

using System.Data;

namespace InventoryTracker.Interfaces
{
    public interface IResponseHandler
    {
        DataTable GetDataTable(string tableName, string response);

        string ParseResponse(string queryResponse);

        string ParseItemID(string itemResponse);
    }
}