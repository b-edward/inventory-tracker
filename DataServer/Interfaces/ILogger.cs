/*
 * FILE             : ILogger.cs
 * PROJECT          : DataServer for Inventory Tracker
 * PROGRAMMER       : Edward Boado
 * FIRST VERSION    : 2022 - 01 - 07
 * DESCRIPTION      : This file contains an interface for logging messages to a file.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
