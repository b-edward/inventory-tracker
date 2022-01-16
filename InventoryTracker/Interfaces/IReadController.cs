using System.Data;

namespace InventoryTracker.Interfaces
{
    public interface IReadController
    {
        DataTable GetInventory();

        DataTable GetTable(string tableName);
    }
}