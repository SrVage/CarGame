using System;
using System.Collections.Generic;
using Code.Inventory.Model;

namespace Code.Ability.Model
{
    public interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequest;
        void Display(IReadOnlyList<IItem> abilityItems);
        void Hide();
    }
}