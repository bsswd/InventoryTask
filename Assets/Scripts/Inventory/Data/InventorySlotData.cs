using System;
using UnityEngine;

namespace Inventory.Data
{
    [Serializable]
    public class InventorySlotData
    {
        public string itemId;
        public int amount;
        public int maxAmount;
    } 
}