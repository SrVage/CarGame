using System;
using System.Collections.Generic;
using Code.Inventory.Controller;

namespace Code.Inventory.Model
{
    public interface IInventoryView
    {
       event EventHandler<IItem> Selected;
       event EventHandler<IItem> Diselected;
       void Init(InventoryController controller);
       void Display(IReadOnlyList<IItem> item);
       void Hide();
    }
}