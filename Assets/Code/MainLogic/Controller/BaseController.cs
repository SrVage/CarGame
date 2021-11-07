using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.MainLogic.Controller
{
    public abstract class BaseController:IDisposable
    {
        private List<BaseController> _baseControllers;
        private List<GameObject> _gameObjects;
        private bool _isDispose;
        
        public void Dispose()
        {
            if (!_isDispose)
            {
                _isDispose = true;
                if (_baseControllers != null)
                {
                    foreach (var baseController in _baseControllers)
                    {
                        baseController?.Dispose();
                    }
                    _baseControllers.Clear();
                }

                if (_gameObjects != null)
                {
                    foreach (var gameObject in _gameObjects)
                    {
                        Object.Destroy(gameObject);
                    }
                    _gameObjects.Clear();
                }
                OnDispose();
            }
        }

        protected void AddController(BaseController baseController)
        {
            if (_baseControllers == null)
            {
                _baseControllers = new List<BaseController>();
            }
            _baseControllers.Add(baseController);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            if (_gameObjects == null)
            {
                _gameObjects = new List<GameObject>();
            }
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {
            
        }
    }
}