﻿using InventoryTracker.DataServerAccess;
using InventoryTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTracker.Controllers
{
    public class EditController : IEditController
    {
        private IRequestHandler requestHandler;
        private IResponseHandler responseHandler;
        private ITableRead tableReader;
        private ITableCUD tableEditor;

        public EditController()
        {
            requestHandler = new RequestHandler();
            responseHandler = new ResponseHandler();
        }


        public string ExecuteCUD(object table, string command, string tableName)
        {
            string response = "";

            return response;
        }
    }
}