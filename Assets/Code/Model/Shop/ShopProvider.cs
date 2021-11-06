using System;
using System.Collections.Generic;
using Code.Model.Config;
using Code.View;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.Model.Shop
{
    public class ShopProvider
    {
        private const string MONEY = "MONEY";
        private IShop _shopTools;
        private List<ShopItem> _shopProducts;
        private ShopItem _currentProduct;


        public ShopProvider(IShop shopTools, List<ShopItem> shopProducts, MainMenuView view)
        {
            _shopTools = shopTools;
            _shopTools.OnSuccessPurchase.SubscribeOnChange(AddValue);
            _shopProducts = shopProducts;
        }

        private void AddValue()
        {
            Debug.Log("Add");
            var money = GetMoney();
            money += _currentProduct.ShopProduct.ProductModification.Value;
            SaveMoney(money);
        }

        private void Buy(string id)
        {
            foreach (var product in _shopProducts)
            {
                if (product.ShopProduct.ID == id)
                {
                    _currentProduct = product;
                }
            }
            _shopTools.Buy(id);
        }

        private int GetMoney()
        {
            if (PlayerPrefs.HasKey(MONEY))
            {
                return PlayerPrefs.GetInt(MONEY);
            }
            return 0;
        }

        private void SaveMoney(int money)
        {
            PlayerPrefs.SetInt(MONEY, money);
        }

        public void InitiatePurchase(Product product, string payload)
        {
            throw new NotImplementedException();
        }

        public void InitiatePurchase(string productId, string payload)
        {
            throw new NotImplementedException();
        }

        public void InitiatePurchase(Product product)
        {
            throw new NotImplementedException();
        }

        public void InitiatePurchase(string productId)
        {
            throw new NotImplementedException();
        }

        public void FetchAdditionalProducts(HashSet<ProductDefinition> additionalProducts, Action successCallback, Action<InitializationFailureReason> failCallback)
        {
            throw new NotImplementedException();
        }

        public void ConfirmPendingPurchase(Product product)
        {
            throw new NotImplementedException();
        }
    }
}