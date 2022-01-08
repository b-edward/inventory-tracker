using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracker
{
    // This interface will implement CRUD commands, allowing different classes to 
    // implement their own query strings
    public interface IDatabaseCommand
    {
        string Create(string newRecord);                // Create a new record in the database
        string Read();                                  // Overloaded method to read all records
        string Read(string id);                         // Overloaded method to read a single record
        string Update(string id, string updates);       // Modify an existing entry
        string Delete(string id);                       // Delete an existing entry
    }
}
