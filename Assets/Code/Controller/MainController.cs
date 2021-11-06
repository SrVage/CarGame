using System;
using System.Collections.Generic;
using Code.Controller;
using Code.Model;
using Code.Model.Ability;
using Code.Model.Config;
using Code.Model.Inventory;
using Code.Model.Shed;
using Code.Model.Shop;
using Code.Rewards.Controller;
using Code.Rewards.View;
using UnityEngine;

namespace Code.InputLogic
{
    public class MainController:BaseController
    {
        private List<BaseController> _controllers = new List<BaseController>();
        private readonly ProfilePlayer _model;
        private readonly Transform _uiRoot;
        private MainMenuController _menuController;
        private GameController _gameController;
        private InventoryController _inventoryController;
        private CurrencyController _currencyController;
        private ShedController _shedController;
        private List<ShopItem> _shopItems;
        private InventoryModel _inventoryModel;
        private ItemRepository _itemsRepository;
        private UpgradeItemRepository _upgradeItemRepository;
        private DailyRewardController _rewardController;
        private IShop _shop;
        private readonly List<AbilityItemConfig> _abilityConfigs;

        public MainController(ProfilePlayer model, Transform uiRoot, List<ShopItem> shopItems,
            UpgradeItemRepository item, IShop shop, List<AbilityItemConfig> abilityConfigs)
        {
            _model = model;
            _uiRoot = uiRoot;
            _shopItems = shopItems;
            _inventoryModel = new InventoryModel();
            _itemsRepository = new ItemRepository(item);
            _shop = shop;
            _abilityConfigs = abilityConfigs;
            _upgradeItemRepository = item;
            _inventoryController = new InventoryController(_inventoryModel, _itemsRepository);
            _shedController = new ShedController(item, _model.CurrentCar);
            model.CurrentState.SubscribeOnChange(OnStateChange);
        }

        private void OnStateChange(GameState state)
        {
            switch (state)
            {
                case GameState.None:
                    break;
                case GameState.Start:
                    ClearControllers();
                    _menuController = new MainMenuController(_uiRoot, _model);
                    _controllers.Add(_menuController);
                    break;
                case GameState.Game:
                    ClearControllers();
                    _gameController = new GameController(_model, _inventoryController, new AbilityRepository(_abilityConfigs), _inventoryModel);
                   _controllers.Add(_gameController);
                    break;
                case GameState.Reward:
                    _rewardController = new DailyRewardController(_uiRoot, _model);
                    _controllers.Add(_rewardController);
                    _currencyController = new CurrencyController(_model, _uiRoot);
                    _controllers.Add(_currencyController);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void ClearControllers()
        {
            for (int i = 0; i < _controllers.Count; i++)
            {
                _controllers[i].Dispose();
                _controllers[i] = null;
            }
            _controllers.Clear();
        }
    }
}