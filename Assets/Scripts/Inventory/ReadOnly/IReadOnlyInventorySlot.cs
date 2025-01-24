using System;

namespace Inventory.ReadOnly
{
    public interface IReadOnlyInventorySlot
    {
        event Action<string> ItemIdChanged;
        event Action<string> ItemAmountChanged;
        
        string ItemId { get; }
        int Amount { get; }
        bool IsEmpty { get; }
    }
}