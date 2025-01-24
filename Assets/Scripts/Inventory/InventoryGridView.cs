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
            
            for (var i = 0; i < size.x; i++)
            {
                for (var j = 0; j < size.y; j++)
                {
                    var slot = slots[i, j];
                    
                    print($"Slot ({i}:{j}). Item: {slot.ItemId}, Amount: {slot.Amount}");
                }
            }
        }
    }
}