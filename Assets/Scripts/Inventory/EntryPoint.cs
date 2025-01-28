using System;
using System.Collections.Generic;
using Inventory.Controllers;
using Inventory.Data;
using Inventory.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenView;
        
        private const string OWNER_1 = "Player";
        private const string OWNER_2 = "Container";

        private readonly string[] _itemIds =
            { "Helmet", "Pistol ammo", "Assault rifle ammo", "Medkit", "Jacket", "Cap", "Armor vest" };

        
        private InventoryService _inventoryService;
        private ScreenController _screenController;

        private string _cachedOwnerId;

        private void Start()
        {
            _inventoryService = new InventoryService();

            var inventoryDataPlayer = CreateTestInventory(OWNER_1);
            _inventoryService.RegisterInventory(inventoryDataPlayer);
            
            var inventoryDataContainer = CreateTestInventory(OWNER_2);
            _inventoryService.RegisterInventory(inventoryDataContainer);

            _screenController = new ScreenController(_inventoryService, _screenView);
            _screenController.OpenInventory(OWNER_1);
            _cachedOwnerId = OWNER_1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _screenController.OpenInventory(OWNER_1);
                _cachedOwnerId = OWNER_1;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenController.OpenInventory(OWNER_2);
                _cachedOwnerId = OWNER_2;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                var rIndex = Random.Range(0, _itemIds.Length);
                var rItemId = _itemIds[rIndex];
                var rAmount = Random.Range(1, 50);

                var result = _inventoryService.AddItemsToInventory(_cachedOwnerId, rItemId, rAmount);
                
                print($"Item added: {rItemId}. Amount added: {result.ItemsAddedAmount}");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                var rIndex = Random.Range(0, _itemIds.Length);
                var rItemId = _itemIds[rIndex];
                var rAmount = Random.Range(1, 50);

                var result = _inventoryService.RemoveItems(_cachedOwnerId, rItemId, rAmount);
                
                print($"Item removed: {rItemId}. Trying to remove: {result.ItemsToRemoveAmount}, Success: {result.Success}");
            }
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