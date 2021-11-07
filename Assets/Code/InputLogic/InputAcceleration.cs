using Code.Tools;
using JoostenProductions;
using UnityEngine;

namespace Code.InputLogic
{
    internal class InputAcceleration:BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            Vector3 direction = Vector3.zero;
#if UNITY_EDITOR
            direction.x = -Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
#else
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;
            if (direction.sqrMagnitude>1)
                direction.Normalize();
#endif
            OnRightMove(direction.sqrMagnitude/20*_speed);
        }
    }
}