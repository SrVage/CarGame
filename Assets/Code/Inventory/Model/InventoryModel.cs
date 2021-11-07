using System.Collections.Generic;

namespace Code.Inventory.Model
{
    public class InventoryModel:IInventory
    {
        private static readonly List<IItem> _emptyCollection = new List<IItem>();
        private readonly List<IItem> _items = new List<IItem>();
        
        public IReadOnlyList<IItem> GetEquipedItems()
        {
            return _items ?? _emptyCollection;
        }

        public void Equiped(IItem item)
        {
            if (_items.Contains(item)) return;
            _items.Add(item);
        }

        public void Unequiped(IItem item)
        {
            _items.Remove(item);
        }
    }
}