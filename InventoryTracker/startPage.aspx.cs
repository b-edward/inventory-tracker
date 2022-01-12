using InventoryTracker.DataServerAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryTracker
{
    public partial class startPage : System.Web.UI.Page
    {
        ServerHandler serverHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeTracker();
        }        

        protected void InitializeTracker()
        {
            serverHandler = new ServerHandler();
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            txtOutput.Text = serverHandler.SendToServer("GET\nSELECT * FROM `Product`;");
        }
    }
}
