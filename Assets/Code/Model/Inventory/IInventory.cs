using System.Collections.Generic;

namespace Code.Model.Inventory
{
    public interface IInventory
    {
        IReadOnlyList<IItem> GetEquipedItems();
        void Equiped(IItem item);
        void Unequiped(IItem item);
    }
}