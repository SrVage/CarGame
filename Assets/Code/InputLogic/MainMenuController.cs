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

        public MainMenuController(Transform canvasParent, ProfilePlayer model)
        {
            var view = CreateView(canvasParent);
            AddGameObject(view.gameObject);
            _model = model;
            view.StartClick += OnStart;
        }

        private void OnStart()
        {
            _model.CurrentState.value = GameState.Game;
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