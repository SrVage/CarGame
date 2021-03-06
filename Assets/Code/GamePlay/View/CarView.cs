using System;
using Code.Config;
using Code.Inventory.Model;
using Code.Tools;
using UnityEngine;

namespace Code.GamePlay.View
{
    public class CarView:MonoBehaviour
    {
        [SerializeField] private Transform _frontWheel;
        [SerializeField] private Transform _backWheel;
        [SerializeField] private SpriteRenderer _turbine;
        private IReadOnlySubscriptionProperty<float> _left;
        private IReadOnlySubscriptionProperty<float> _right;
        private float _speedWheel=15;

        public void AddUpgrade(IItem item)
        {
            switch (item.Place)
            {
                case Place.None:
                    break;
                case Place.Wheels:
                    _frontWheel.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                    _backWheel.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                    break;
                case Place.Forward:
                    _turbine.sprite = item.Sprite;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Init(IReadOnlySubscriptionProperty<float> speedLeft, IReadOnlySubscriptionProperty<float> speedRight)
        {
            _left = speedLeft;
            _right = speedRight;
            _left.SubscribeOnChange(Rotate);
            _right.SubscribeOnChange(Rotate);
        }

        private void Rotate(float speed)
        {
            _frontWheel.Rotate(new Vector3(0,0,-speed*_speedWheel));
            _backWheel.Rotate(new Vector3(0,0,-speed*_speedWheel));
        }
    }
}