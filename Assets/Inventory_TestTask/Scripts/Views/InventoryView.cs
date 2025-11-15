using TMPro;
using UnityEngine;

namespace Assets.Inventory_TestTask
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventorySlotView[] _slots;
        [SerializeField] private TMP_Text _textOwner;

        public string OwnerId 
        {
            get => _textOwner.text;
            set => _textOwner.text = value;
        }

        public InventorySlotView GetInvenotorySlotView(int index) 
        {
            return _slots[index];
        }
    }
}
