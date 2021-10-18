using System;
using Code.InputLogic;
using Code.Model;
using UnityEngine;

namespace Code.View
{
    public class Root:MonoBehaviour
    {
        [SerializeField] private Transform _root;

        private ProfilePlayer _model;
        private MainController _mainController;
        private void Start()
        {
            _model = new ProfilePlayer(1.0f);
            _mainController = new MainController(_model, _root);
            _model.CurrentState.value = GameState.Start;
        }

        private void OnDestroy()
        {
            _mainController?.Dispose();
            _mainController = null;
            _model = null;
        }
    }
}