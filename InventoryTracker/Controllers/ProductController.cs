using InventoryTracker.Interfaces;
using InventoryTracker.Models;

namespace InventoryTracker.Controllers
{
    public class ProductController : ITableRead, ITableCUD
    {
        private IProduct productTable;

        public ProductController()
        {
        }

        // Create SQL query to execute the command in the product table
        public string BuildCUDQuery(object table, string command)
        {
            // Convert the object parameter into a Product
            productTable = (Product)table;

            string query = GetQuery(table, command);

            return query;
        }

        private string GetQuery(object table, string command)
        {
            string query = "";

            switch(command.ToUpper())
            {
                case "PUT":
                    query = InsertQuery(table, command);
                    break;
                case "POST":
                    query = UpdateQuery(table, command);
                    break;


            }
            return query;
        }

        private string InsertQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nINSERT INTO `Product` (`productName`, `isActive`) " +
                    $"VALUES ('{productTable.ProductName}', {productTable.IsActive});";
            return query;
        }

        private string UpdateQuery(object table, string command)
        {
            string query = "";
            // Use model properties to build the command query
            query = $"{command.ToUpper()}\nUPDATE `Product` SET productName='{productTable.ProductName}', " +
                    $"isActive={productTable.IsActive} WHERE productID={productTable.ProductID};";
            return query;
        }


        // Create SQL query to get inventory of all products
        public string BuildReadQuery()
        {
            string query = "GET\nSELECT * FROM `Product`;";
            return query;
        }
    }
}