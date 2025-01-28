using UnityEngine;

namespace Inventory.View
{
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;

        public InventoryView InventoryView => _inventoryView;
    }
}