using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Data
{
    [Serializable]
    public class InventoryGridData
    {
        public string ownerId;
        public List<InventorySlotData> slot;
        public Vector2Int size;

    }
}