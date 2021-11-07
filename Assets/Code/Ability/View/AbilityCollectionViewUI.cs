using System;
using System.Collections.Generic;
using Code.Ability.Model;
using Code.Inventory.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Ability.View
{
    public class AbilityCollectionViewUI:MonoBehaviour, IAbilityCollectionView
    {
        public event EventHandler<IItem> UseRequest;
        [SerializeField] private Transform _panel;
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            foreach (var item in abilityItems)
            {
                var go = new GameObject(item.ID.ToString());
                go.transform.parent = _panel;
                go.AddComponent<Image>().sprite = item.Sprite;
                go.AddComponent<Button>().onClick.AddListener((() => Ability(item)));
                var textGO = new GameObject(item.ItemInfo.Name + "Text");
                textGO.AddComponent<Text>().text = item.Value.ToString();
                textGO.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                textGO.GetComponent<Text>().fontSize = 50;
                textGO.transform.parent = go.transform;
            }
        }

        private void Ability(IItem item)
        {
            UseRequest?.Invoke(this, item);
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}