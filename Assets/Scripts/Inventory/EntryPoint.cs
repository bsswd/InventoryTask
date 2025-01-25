using System;
using System.Collections.Generic;
using Inventory.Data;
using UnityEngine;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        public InventoryGridView _view;
        private InventoryService _inventoryService;

        private void Start()
        {
            _inventoryService = new InventoryService();
            
            var ownerId = "Player";
            var inventoryData = CreateTestInventory(ownerId);
            var inventory = _inventoryService.RegisterInventory(inventoryData);
            
            _view.Setup(inventory);
            
            var addedResult = _inventoryService.AddItemsToInventory(ownerId, "pistol ammo", 50);
            print($"Items added. ItemId: pistol ammo, amount to add: 50, amount added: {addedResult.ItemsAddedAmount}");
            
            addedResult = _inventoryService.AddItemsToInventory(ownerId, "rifle ammo", 200);
            print($"Items added. ItemId: rifle ammo, amount to add: 50, amount added: {addedResult.ItemsAddedAmount}");
            
            addedResult = _inventoryService.AddItemsToInventory(ownerId, "jacket", 1);
            print($"Items added. ItemId: jacket, amount to add: 50, amount added: {addedResult.ItemsAddedAmount}");
            
            _view.PrintInfo();
            
            var removedResult = _inventoryService.RemoveItems(ownerId, "pistol ammo",30 );
            print($"Items removed. ItemId: pistol ammo, amount to remove: 30, amount removed: {removedResult.Success}");
            
            _view.PrintInfo();
            
            removedResult = _inventoryService.RemoveItems(ownerId, "pistol ammo",21 );
            print($"Items removed. ItemId: pistol ammo, amount to remove: 30, amount removed: {removedResult.Success}");
            
            _view.PrintInfo();
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