using Code.Controller;
using Code.Model;
using Code.Rewards.View;
using Code.Tools;
using UnityEngine;

namespace Code.Rewards.Controller
{
    public class CurrencyController:BaseController
    {
        private readonly ProfilePlayer _model;
        private ResourcePath _currencyResourcePath = new ResourcePath() { PathResource = "Prefabs/resourcesPanel"};
        private CurrencyView _currencyView;
        
        public CurrencyController(ProfilePlayer model, Transform root)
        {
            _model = model;
            var prefab = ResourceLoader.LoadPrefab(_currencyResourcePath);
            var go = Object.Instantiate(prefab, root);
            AddGameObject(go);
            _currencyView = go.GetComponent<CurrencyView>();
            _currencyView.Diamonds = _model.Diamond.value;
            _currencyView.Gold = _model.Gold.value;
            _model.Gold.SubscribeOnChange(v=>_currencyView.Gold=v);
            _model.Diamond.SubscribeOnChange(v=>_currencyView.Diamonds=v);
        }
    }
}