using Code.Controller;
using Code.Model;
using Code.Tools;
using Code.View;
using UnityEngine;

namespace Code.InputLogic
{
    public class MainMenuController:BaseController
    {
        private ResourcePath _mainMenuResourcePath = new ResourcePath() { PathResource = "Prefabs/mainMenu"};
        private ProfilePlayer _model;
        private MainMenuView _view;

        public MainMenuController(Transform canvasParent, ProfilePlayer model)
        {
            _view = CreateView(canvasParent);
            AddGameObject(_view.gameObject);
            _view.Init(OnStart, Reward, Fight);
            _model = model;
        }

        private void OnStart()
        {
            _model.CurrentState.value = GameState.Game;
        }

        private void Reward()
        {
            _model.CurrentState.value = GameState.Reward;
        }

        private void Fight()
        {
            _model.CurrentState.value = GameState.Fight;
        }

        private MainMenuView CreateView(Transform canvasParent)
        {
            var prefab = ResourceLoader.LoadPrefab(_mainMenuResourcePath);
            var go = GameObject.Instantiate(prefab, canvasParent);
            var view = go.GetComponent<MainMenuView>();
            return view;
        }
    }
}