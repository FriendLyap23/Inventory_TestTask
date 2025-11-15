using System;

namespace Assets.Inventory_TestTask
{
    public interface IReadOnlyInventory
    {
        event Action<string, int> ItemAdded;
        event Action<string, int> ItemRemoved;

        string OwnerId { get; }

        int GetAmount(string itemId);
        bool Has(string itemId, int amount);
    }
}
