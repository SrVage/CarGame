using Code.Ability.Model;
using Code.GamePlay.View;
using Code.MainLogic.Controller;
using Code.Tools;
using UnityEngine;

namespace Code.GamePlay.Controller
{
    public class CarController:BaseController, IAbilityActivator
    {
        private readonly ResourcePath _path = new ResourcePath() { PathResource = "Prefabs/Car" };
        private readonly CarView _carView;

        public CarController(IReadOnlySubscriptionProperty<float> left, IReadOnlySubscriptionProperty<float> right)
        {
            _carView = CreateCar();
            _carView.Init(left, right);
        }

        private CarView CreateCar()
        {
            var prefab = Object.Instantiate(ResourceLoader.LoadPrefab(_path));
            AddGameObject(prefab);
            return prefab.GetComponent<CarView>();
        }

        public GameObject GetCar()
        {
            return _carView.gameObject;
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    }
}