using Code.Controller;
using Code.Model;
using Code.Tools;
using UnityEngine;

namespace Code.InputLogic
{
    internal class InputBaseController:BaseController
    {
        private BaseInputView _view;
        private readonly ResourcePath _path = new ResourcePath { PathResource = "Prefabs/endlessMove" };
        
        public InputBaseController(SubscriptionProperty<float> rightMove, SubscriptionProperty<float> leftMove, Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private BaseInputView LoadView()
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_path));
            AddGameObject(objectView);
            return objectView.GetComponent<BaseInputView>();
        }
    }
}