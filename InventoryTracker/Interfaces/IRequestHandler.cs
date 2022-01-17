/*
 * FILE             : IRequestHandler.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IRequestHandler interface, which provides an abstraction layer for
 *                    implementing the RequestHandler class.
 */

namespace InventoryTracker.Interfaces
{
    public interface IRequestHandler
    {
        string SendRequest(string request);
    }
}