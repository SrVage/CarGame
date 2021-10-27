using System;
using System.Collections.Generic;
using Code.Model.Inventory;

namespace Code.Model.Ability
{
    public interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequest;
        void Display(IReadOnlyList<IItem> abilityItems);
        void Hide();
    }
}