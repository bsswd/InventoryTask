using System;
using System.Collections.Generic;
using Inventory.Data;
using UnityEngine;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        public InventoryGridView _view;

        private void Start()
        {
            var inventoryData = new InventoryGridData()
            {
                Size = new Vector2Int(6, 5),
                OwnerId = "Player",
                Slots = new List<InventorySlotData>()
            };


            var size = inventoryData.Size;
            for (var i = 0; i < size.x; i++)
            {
                for (var j = 0; j < size.y; j++)
                {
                    var index = i * size.y + j;
                    inventoryData.Slots.Add(new InventorySlotData());
                }
            }

            
            
            var slotData = inventoryData.Slots[0];
            slotData.ItemId = "Medkit";
            slotData.Amount = 50;

            var inventory = new InventoryGrid(inventoryData);
            
            _view.Setup(inventory);
        }
    }
}