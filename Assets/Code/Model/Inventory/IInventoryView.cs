using System;
using System.Collections.Generic;

namespace Code.Model.Inventory
{
    public interface IInventoryView
    {
       event EventHandler<IItem> Selected;
       event EventHandler<IItem> Diselected;
       void Init(InventoryController controller);
       void Display(IReadOnlyList<IItem> item);
    }
}