namespace Assets.Inventory_TestTask
{
    public  class InventorySlotController
    {
        private readonly InventorySlotView _view;
        public InventorySlotController(IReadOnlyInventorySlot slot, InventorySlotView view)
        {
            _view = view;

            slot.ItemIdChanged += OnSlotOnItemIdChanged;
            slot.ItemAmountChanged += OnSlotItemAmountChanged;

            view.Title = slot.ItemId;
            view.Amount = slot.Amount;
        }

        private void OnSlotOnItemIdChanged(string newItemId)
        {
            _view.Title = newItemId;
        }

        private void OnSlotItemAmountChanged(int newAmount)
        {
            _view.Amount = newAmount;
        }
    }
}
