using System;
using System.Collections.Generic;
using Code.InputLogic;
using Code.Model;
using Code.Model.Config;
using Code.Model.Shop;
using Code.Rewards.View;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.View
{
    public class Root:MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private UpgradeItemRepository _upgradeItemRepository;
        [SerializeField] private List<AbilityItemConfig> _abilityConfigs;
        [SerializeField] private RewardView _rewardView;

        private ProfilePlayer _model;
        private MainController _mainController;
        private ShopTools _shopTools;
        private void Start()
        {
            _model = new ProfilePlayer(1.0f);
            _shopTools = new ShopTools(_shopItems.ShopItemsList);
            _mainController = new MainController(_model, _root, _shopItems.ShopItemsList, _upgradeItemRepository, _shopTools, _abilityConfigs, _rewardView);
            _model.CurrentState.value = GameState.Start;
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
            _mainController = null;
            _model = null;
        }
    }
}