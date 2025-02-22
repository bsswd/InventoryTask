﻿using System;

namespace Inventory.ReadOnly
{
    public interface IReadOnlyInventorySlot
    {
        event Action<string> ItemIdChanged;
        event Action<int> ItemAmountChanged;
        
        string ItemId { get; }
        int Amount { get; }

        int MaxAmount { get; }
        float Weight { get; }
        bool IsEmpty { get; }
    }
}