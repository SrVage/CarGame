﻿using System;
using System.Collections.Generic;
using System.Linq;
using Code.Controller;
using Code.Model.Inventory;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Model.Ability
{
    public class AbilityController:BaseController
    {
        [NotNull] private readonly IInventory _inventoryModel;
        [NotNull] private readonly IAbilityRepository _abilityRepository;
        [NotNull] private readonly IAbilityCollectionView _abilityCollectionView;
        [NotNull] private readonly IAbilityActivator _abilityActivator;

        public AbilityController([NotNull] IInventory inventoryModel, [NotNull] IAbilityRepository abilityRepository,
            [NotNull] IAbilityCollectionView abilityCollectionView, [NotNull] IAbilityActivator abilityActivator)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
            _abilityCollectionView =
                abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));

            var equiped = inventoryModel.GetEquipedItems();
            var equipedAbilities = equiped.Where(i => _abilityRepository.Content.ContainsKey(i.ID));
            _abilityCollectionView.Display(equipedAbilities.ToList());
            _abilityCollectionView.UseRequest += OnAbilityUseRequested;
        }

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.Content.TryGetValue(e.ID, out var ability))
            {
                ability.Apply(_abilityActivator);
            }
        }

        protected override void OnDispose()
        {
            _abilityCollectionView.UseRequest -= OnAbilityUseRequested;
        }
    }
}