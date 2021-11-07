using Code.MainLogic.Controller;
using Code.MainLogic.Model;
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
            CreateView(root);
            ShowStartValue();
            Subscribe();
        }

        private void CreateView(Transform root)
        {
            var prefab = ResourceLoader.LoadPrefab(_currencyResourcePath);
            var go = Object.Instantiate(prefab, root);
            AddGameObject(go);
            _currencyView = go.GetComponent<CurrencyView>();
        }

        private void ShowStartValue()
        {
            _currencyView.Diamonds = _model.RewardModel.Diamond.value;
            _currencyView.Gold = _model.RewardModel.Gold.value;
        }

        private void Subscribe()
        {
            _model.RewardModel.Gold.SubscribeOnChange(v => _currencyView.Gold = v);
            _model.RewardModel.Diamond.SubscribeOnChange(v => _currencyView.Diamonds = v);
        }
    }
}