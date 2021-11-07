using System.Collections.Generic;

namespace Code.Inventory.Model
{
    public interface IInventory
    {
        IReadOnlyList<IItem> GetEquipedItems();
        void Equiped(IItem item);
        void Unequiped(IItem item);
    }
}