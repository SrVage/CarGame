using System;
using System.Collections.Generic;
using Code.Controller;
using Code.Model;
using Code.Model.Ability;
using Code.Model.Config;
using Code.Model.Inventory;
using Code.Model.Shed;
using Code.Model.Shop;
using UnityEngine;

namespace Code.InputLogic
{
    public class MainController:BaseController
    {
        private readonly ProfilePlayer _model;
        private readonly Transform _uiRoot;
        private MainMenuController _menuController;
        private GameController _gameController;
        private InventoryController _inventoryController;
        private ShedController _shedController;
        private List<ShopItem> _shopItems;
        private InventoryModel _inventoryModelModel;
        private ItemRepository _itemsRepository;
        private UpgradeItemRepository _upgradeItemRepository;
        private IShop _shop;
        private readonly List<AbilityItemConfig> _abilityConfigs;

        public MainController(ProfilePlayer model, Transform uiRoot, List<ShopItem> shopItems,
            UpgradeItemRepository item, IShop shop, List<AbilityItemConfig> abilityConfigs)
        {
            _model = model;
            _uiRoot = uiRoot;
            _shopItems = shopItems;
            _inventoryModelModel = new InventoryModel();
            _itemsRepository = new ItemRepository(item);
            _shop = shop;
            _abilityConfigs = abilityConfigs;
            _upgradeItemRepository = item;
            //_inventoryController = new InventoryController(_inventoryModelModel, _itemsRepository);
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
                    _gameController?.Dispose();
                    _gameController = null;
                    _menuController = new MainMenuController(_uiRoot, _model, _shopItems, _upgradeItemRepository, _shop);
                    //_inventoryController = new InventoryController(_inventoryModelModel, _itemsRepository);
                    break;
                case GameState.Game:
                    _menuController?.Dispose();
                    _menuController = null;
                    _gameController = new GameController(_model, _inventoryController, new AbilityRepository(_abilityConfigs), _inventoryModelModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}