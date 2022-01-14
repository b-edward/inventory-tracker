/*
 * FILE             : IRequestHandler.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for handling requests.
 */

using System;

namespace DataServer.Interfaces
{
    public interface IRequestHandler
    {
        bool HandleRequest(Object clientObject);

        string GetRequest(Object networkObject);
    }
}