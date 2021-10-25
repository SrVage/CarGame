using Code.Tools;
using Code.View;
using UnityEngine;

namespace Code.Controller
{
    public class CarController:BaseController
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
    }
}