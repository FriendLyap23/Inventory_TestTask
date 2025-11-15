using UnityEngine;

namespace Assets.Inventory_TestTask
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private InventoryView _invenotryView;

        public InventoryView InventoryView => _invenotryView;
    }
}
