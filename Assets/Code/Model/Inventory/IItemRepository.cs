using System.Collections.Generic;

namespace Code.Model.Inventory
{
    public interface IItemRepository
    {
        IReadOnlyDictionary<int,IItem> Items { get; }
    }
}