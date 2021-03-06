using System.Collections.Generic;
using Code.Config;
using Code.MainLogic.Controller;
using Code.MainLogic.Model;
using Code.Shop;
using UnityEngine;

namespace Code.MainLogic.View
{
    public class Root:MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private UpgradeItemRepository _upgradeItemRepository;
        [SerializeField] private List<AbilityItemConfig> _abilityConfigs;

        private ProfilePlayer _model;
        private MainController _mainController;
        private ShopTools _shopTools;
        private void Start()
        {
            _model = new ProfilePlayer(1.0f);
            _shopTools = new ShopTools(_shopItems.ShopItemsList);
            _mainController = new MainController(_model, _root, _shopItems.ShopItemsList, _upgradeItemRepository, _shopTools, _abilityConfigs);
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