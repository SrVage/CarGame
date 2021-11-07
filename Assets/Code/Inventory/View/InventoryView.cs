using System;
using System.Collections.Generic;
using Code.Inventory.Controller;
using Code.Inventory.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Inventory.View
{
    public class InventoryView:MonoBehaviour, IInventoryView
    {
        [SerializeField] private Transform _panel;
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Diselected;
        private InventoryController _inventoryController;

        private IReadOnlyList<IItem> _items;

        public void Init(InventoryController controller)
        {
            _inventoryController = controller;
        }
        
        private void OnEnable()
        {
            _inventoryController.ShowInventory();
        }

        public void Display(IReadOnlyList<IItem> items)
        {
            _items = items;
            foreach (var item in _items)
            {
                var go = new GameObject(item.ID.ToString());
                go.transform.parent = _panel;
                go.AddComponent<Image>().sprite = item.Sprite;
               // go.AddComponent<Button>().onClick.AddListener((() => Buy(go.name)));
                var textGO = new GameObject(item.ItemInfo.Name + "Text");
                textGO.AddComponent<Text>().text = item.Value.ToString();
                textGO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                textGO.GetComponent<Text>().fontSize = 50;
                textGO.transform.parent = go.transform;
            }
        }

        public void Hide()
        {
            //throw new NotImplementedException();
        }


        protected virtual void OnSelected(IItem e)
        {
            Selected?.Invoke(this, e);
        }

        protected virtual void OnDiselected(IItem e)
        {
            Diselected?.Invoke(this, e);
        }
        
    }
}