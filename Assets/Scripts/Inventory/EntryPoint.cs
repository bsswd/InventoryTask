using System;
using System.Collections.Generic;
using Inventory.Data;
using UnityEngine;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        
        
        private InventoryService _inventoryService;

        private void Start()
        {
            _inventoryService = new InventoryService();
            
            
        }

        private InventoryGridData CreateTestInventory(string ownerId)
        {
            var size = new Vector2Int(6, 5);
            var createdInventorySlots = new List<InventorySlotData>();
            var length = size.x * size.y;
            for (var i = 0; i < length; i++)
            {
               createdInventorySlots.Add(new InventorySlotData());
            }

            var createdInventoryData = new InventoryGridData
            {
                OwnerId = ownerId,
                Size = size,
                Slots = createdInventorySlots
            };
            
            return createdInventoryData;
        }
    }
}