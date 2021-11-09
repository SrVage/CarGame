using System.Threading.Tasks;
using Code.Ability.Model;
using Code.Bundles;
using Code.GamePlay.View;
using Code.MainLogic.Controller;
using Code.Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.GamePlay.Controller
{
    public class CarController:BaseController, IAbilityActivator
    {
        private readonly IReadOnlySubscriptionProperty<float> _left;
        private readonly IReadOnlySubscriptionProperty<float> _right;
        private readonly ResourcePath _path = new ResourcePath() { PathResource = "Prefabs/Car" };
        private CarView _carView;

        public CarController(IReadOnlySubscriptionProperty<float> left, IReadOnlySubscriptionProperty<float> right, GameObject car)
        {
            _left = left;
            _right = right;
            AddGameObject(car);
            _carView = car.GetComponent<CarView>();
            _carView.Init(left, right);
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    }
}