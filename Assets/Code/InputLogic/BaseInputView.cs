using Code.Tools;
using UnityEditor;
using UnityEngine;

namespace Code.InputLogic
{
    internal abstract class BaseInputView:MonoBehaviour
    {
        protected float _speed;
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        
        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            _speed = speed;
            _leftMove = leftMove;
            _rightMove = rightMove;
        }

        protected virtual void OnLeftMove(float value)
        {
            _leftMove.value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _rightMove.value = value;
        }
    }
}