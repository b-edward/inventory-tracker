using System.Data;

namespace InventoryTracker.Interfaces
{
    public interface IReadController
    {
        DataTable GetTable(string tableName);
        string GetNewItemID();
    }
}