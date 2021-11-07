using System;
using System.Collections.Generic;
using Code.Ability.Model;
using Code.Inventory.Model;

namespace Code.Ability.View
{
    public class AbilityCollectionViewStub:IAbilityCollectionView
    {
        public event EventHandler<IItem> UseRequest;
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            
        }

        public void Hide()
        {
            
        }
    }
}