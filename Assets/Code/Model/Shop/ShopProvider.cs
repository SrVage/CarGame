using System;
using System.Collections.Generic;
using Code.Model.Config;
using Code.View;
using UnityEngine;

namespace Code.Model.Shop
{
    public class ShopProvider
    {
        private const string MONEY = "MONEY";
        private ShopTools _shopTools;
        private List<ShopItem> _shopProducts;
        private ShopItem _currentProduct;

        public ShopProvider(ShopTools shopTools, List<ShopItem> shopProducts, MainMenuView view)
        {
            _shopTools = shopTools;
            _shopTools.OnSuccessPurchase.SubscribeOnChange(AddValue);
            _shopProducts = shopProducts;
            view.BuyItem += Buy;
        }

        private void AddValue()
        {
            Debug.Log("Add");
            var money = GetMoney();
            money += _currentProduct.Value;
            SaveMoney(money);
        }

        private void Buy(string id)
        {
            foreach (var product in _shopProducts)
            {
                if (product.ID == id)
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
    }
}