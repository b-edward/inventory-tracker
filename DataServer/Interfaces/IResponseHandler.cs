/*
 * FILE             : IDatabaseHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for handling responses to CRUD requests.
 */

using System;

namespace DataServer.Interfaces
{
    public interface IResponseHandler
    {
        string ReceivedCreate(string query);

        string ReceivedRead(string query);

        string ReceivedUpdate(string query);

        string ReceivedDelete(string query);

        bool SendResponse(Object networkObject, string response);
    }
}