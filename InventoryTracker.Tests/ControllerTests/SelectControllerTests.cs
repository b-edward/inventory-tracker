using InventoryTracker.Controllers;
using InventoryTracker.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

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