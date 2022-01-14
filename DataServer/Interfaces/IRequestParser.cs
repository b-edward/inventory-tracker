/*
 * FILE             : IRequestParser.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for parsing a request.
 */

namespace DataServer.Interfaces
{
    public interface IRequestParser
    {
        string ParseReceived(string received);
    }
}