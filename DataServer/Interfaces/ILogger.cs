/*
 * FILE             : ILogger.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for logging messages to a file.
 */

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