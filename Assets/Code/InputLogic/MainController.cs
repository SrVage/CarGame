using System;
using Code.Controller;
using Code.Model;
using UnityEngine;

namespace Code.InputLogic
{
    public class MainController:BaseController
    {
        private readonly ProfilePlayer _model;
        private readonly Transform _uiRoot;
        private MainMenuController _menuController;
        private GameController _gameController;
        public MainController(ProfilePlayer model, Transform uiRoot)
        {
            _model = model;
            _uiRoot = uiRoot;
            model.CurrentState.SubscribeOnChange(OnStateChange);
        }

        private void OnStateChange(GameState state)
        {
            switch (state)
            {
                case GameState.None:
                    break;
                case GameState.Start:
                    _gameController?.Dispose();
                    _gameController = null;
                    _menuController = new MainMenuController(_uiRoot, _model);
                    break;
                case GameState.Game:
                    _menuController?.Dispose();
                    _menuController = null;
                    _gameController = new GameController();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }

    public class GameController:BaseController
    {
        
    }
}