using System;
using System.Collections.Generic;
using Code.Model.Config;
using Code.Model.Shop;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace Code.View
{
    public class MainMenuView:MonoBehaviour
    {
        public event Action StartClick;
        public event Action<string> BuyItem;
        [SerializeField] private Button _startButton;
        [Header("Shop")]
        [SerializeField] private Button _shopButton;
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private Button _closeShop;
        [SerializeField] private GameObject _itemPanel;
        [Header("Inventory")]
        [SerializeField] private Button _inventoryButton;
        public GameObject _inventoryPanel;
        [SerializeField] private Button _closeInventory;
        [SerializeField] private GameObject _itemInventoryPanel;
        private ShopProvider _shopProvider;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnClick);
            _shopButton.onClick.AddListener(ShowShop);
            _closeShop.onClick.AddListener(ShowShop);
            _inventoryButton.onClick.AddListener(ShowInventory);
            _closeInventory.onClick.AddListener(ShowInventory);
        }

        public void OnClick()
        {
            StartClick?.Invoke();
        }

        public void ShowShop()
        {
            _shopPanel.SetActive(!_shopPanel.activeSelf);
        }

        public void InitializeShop(List<ShopItem> shopItem)
        {
            foreach (var item in shopItem)
            {
                var go = new GameObject(item.ShopProduct.ID);
                go.transform.parent = _itemPanel.transform;
                go.AddComponent<Image>().sprite = item.Icon;
                go.AddComponent<Button>().onClick.AddListener((() => Buy(go.name)));
                var textGO = new GameObject(item.ShopProduct.ID + "Text");
                textGO.AddComponent<Text>().text = item.Cost.ToString();
                textGO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                textGO.GetComponent<Text>().fontSize = 50;
                textGO.transform.parent = go.transform;
            }
        }

        public void InitializeInventory()
        {
            
        }

        public void ShowInventory()
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        }

        private void Buy(string id)
        {
            BuyItem?.Invoke(id);
        }
    }
}