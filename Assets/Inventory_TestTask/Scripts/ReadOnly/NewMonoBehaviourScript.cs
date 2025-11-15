using System;
using UnityEngine;

namespace Assets.Inventory_TestTask
{
    public interface IReadOnlyInventoryGrid : IReadOnlyInventory
    {
        event Action<Vector2Int> SizeChanged;
        Vector2Int Size { get; }

        IReadOnlyInventorySlot[,] GetSlots();

    }
}