using System.Collections.Generic;

namespace Assets.Inventory_TestTask
{
    public class InventoryGridController
    {
        public readonly List<InventorySlotController> _slotController = new();

        public InventoryGridController(IReadOnlyInventoryGrid inventory, InventoryView view) 
        {
            var size = inventory.Size;
            var slots = inventory.GetSlots();
            var lineLength = size.y;

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    var index = i * lineLength + j;
                    var slotView = view.GetInvenotorySlotView(index);
                    var slot = slots[i, j];

                    _slotController.Add(new InventorySlotController(slot, slotView));
                }
            }
        }
    }
}
