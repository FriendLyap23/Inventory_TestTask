using System;
using UnityEngine;

public interface IReadOnlyInventorySlot
{
    event Action<string> ItemIdChanged;
    event Action<int> ItemAmountChanged;

    string ItemId { get; }
    int Amount { get; }
    bool IsEmpty { get; }
}
