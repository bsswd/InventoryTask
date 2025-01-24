using Inventory.ReadOnly;
using UnityEngine;

namespace Inventory
{
    public class InventoryGridView : MonoBehaviour
    {
        public void Setup(IReadOnlyInventoryGrid inventory)
        {
            var slots = inventory.GetSlots();
            var size = inventory.Size;
        }
    }
}