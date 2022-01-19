using InventoryTracker.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryTracker.Tests
{
    [TestClass]
    public class SelectControllerTests
    {
        [TestMethod]
        public void TestGetController()
        {
            WarehouseItemController controller = null;
            controller = (WarehouseItemController)SelectController.GetController("warehouseItem");
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void TestGetControllerException()
        {
            WarehouseItemController controller = null;
            controller = (WarehouseItemController)SelectController.GetController("shipments");
            Assert.IsNull(controller);
        }
    }
}