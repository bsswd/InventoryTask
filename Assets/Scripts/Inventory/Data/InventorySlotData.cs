using System;
using UnityEngine;

namespace Inventory.Data
{
    [Serializable]
    public class InventorySlotData
    {
        public string ItemId;
        public int Amount;
        public int MaxAmount;
        public float Weight;
    } 
}