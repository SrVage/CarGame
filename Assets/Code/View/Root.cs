using System;
using System.Collections.Generic;
using Code.InputLogic;
using Code.Model;
using Code.Model.Config;
using Code.Model.Shop;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.View
{
    public class Root:MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private UpgradeItemRepository _upgradeItemRepository;

        private ProfilePlayer _model;
        private MainController _mainController;
        private ShopTools _shopTools;
        private void Start()
        {
            _model = new ProfilePlayer(1.0f);
            _mainController = new MainController(_model, _root, _shopItems.ShopItemsList, _upgradeItemRepository);
            _model.CurrentState.value = GameState.Start;
            _shopTools = new ShopTools(_shopItems.ShopItemsList);
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
            _mainController = null;
            _model = null;
        }
    }
}