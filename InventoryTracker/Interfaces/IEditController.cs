namespace InventoryTracker.Interfaces
{
    public interface IEditController
    {
        string ExecuteCUD(object table, string command, string tableName);
    }
}