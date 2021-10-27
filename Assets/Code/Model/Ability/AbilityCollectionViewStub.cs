﻿using System;
using System.Collections.Generic;
using Code.Model.Inventory;

namespace Code.Model.Ability
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