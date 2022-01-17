/*
 * FILE             : IServerHandler.cs
 * PROJECT          : Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 14
 * DESCRIPTION      : This file contains the IServerHandler interface, which provides an abstraction layer for
 *                    implementing the ServerHandler class.
 */

namespace InventoryTracker.Interfaces
{
    public interface IServerHandler
    {
        string SendToServer(string stringToSend);
    }
}