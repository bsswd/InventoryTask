﻿using System;
using Inventory.Data;
using Inventory.ReadOnly;

namespace Inventory
{
    public class InventorySlot : IReadOnlyInventorySlot
    {
        public event Action<string> ItemIdChanged;
        public event Action<int> ItemAmountChanged;

        public string ItemId
        {
            get => _data.ItemId;
            set
            {
                if (_data.ItemId != value)
                {
                    _data.ItemId = value;
                    ItemIdChanged?.Invoke(value);
                }
            }
        }

        public int Amount
        {
            get => _data.Amount;
            set
            {
                if (_data.Amount != value)
                {
                    _data.Amount = value;
                    ItemAmountChanged?.Invoke(value);
                }
            }
        }

        public int MaxAmount {get => _data.MaxAmount;}
        public float Weight {get => _data.Weight;}
        public bool IsEmpty => Amount == 0 && string.IsNullOrEmpty(ItemId);

        private readonly InventorySlotData _data;

        public InventorySlot(InventorySlotData data)
        {
            _data = data;
        }
    }
}