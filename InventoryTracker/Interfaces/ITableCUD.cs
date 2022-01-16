namespace InventoryTracker.Interfaces
{
    public interface ITableCUD
    {
        string BuildCUDQuery(object table, string command);
    }
}