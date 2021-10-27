using System.Collections.Generic;
using Code.Controller;
using Code.Model;
using Code.Model.Config;
using Code.Model.Shed;
using Code.Model.Shop;
using Code.Tools;
using Code.View;
using UnityEngine;

namespace Code.InputLogic
{
    public class MainMenuController:BaseController
    {
        private ResourcePath _mainMenuResourcePath = new ResourcePath() { PathResource = "Prefabs/mainMenu"};
        private ProfilePlayer _model;
        private List<ShopItem> _shopItems;
        private ShedController _shedController;
        private MainMenuView _view;

        public MainMenuController(Transform canvasParent, ProfilePlayer model, List<ShopItem> shopItems, UpgradeItemRepository upgradeItemRepository, IShop shop)
        {
            _shopItems = shopItems;
            _view = CreateView(canvasParent);
            var shopProvider = new ShopProvider(shop, shopItems, _view);
            AddGameObject(_view.gameObject);
            _model = model;
            _view.StartClick += OnStart;
            _shedController = new ShedController(upgradeItemRepository, _model.CurrentCar);
        }

        private void OnStart()
        {
            _model.CurrentState.value = GameState.Game;
        }

        private MainMenuView CreateView(Transform canvasParent)
        {
            var prefab = ResourceLoader.LoadPrefab(_mainMenuResourcePath);
            var go = GameObject.Instantiate(prefab, canvasParent);
            var view = go.GetComponent<MainMenuView>();
            view.InitializeShop(_shopItems);
            return view;
        }

        public MainMenuView GetMainMenu()
        {
            return _view;
        }
    }
}