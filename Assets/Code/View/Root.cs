using System;
using System.Collections.Generic;
using Code.InputLogic;
using Code.Model;
using Code.Model.Shop;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.View
{
    public class Root:MonoBehaviour
    {
        [SerializeField] private Transform _root;

        private ProfilePlayer _model;
        private MainController _mainController;
        private ShopTools _shopTools;
        private void Start()
        {
            _model = new ProfilePlayer(1.0f);
            _mainController = new MainController(_model, _root);
            _model.CurrentState.value = GameState.Start;
            _shopTools = new ShopTools(CreateProducts());

        }

        private List<ShopProduct> CreateProducts()
        {
            List<ShopProduct> products = new List<ShopProduct>();
            var gems = new ShopProduct(){CurrentProductType = ProductType.Consumable, ID = "1"};
            products.Add(gems);
            return products;
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
            _mainController = null;
            _model = null;
        }
    }
}