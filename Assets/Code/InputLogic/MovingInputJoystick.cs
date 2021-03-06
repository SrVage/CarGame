using Code.Tools;
using JoostenProductions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

namespace Code.InputLogic
{
    internal class MovingInputJoystick:BaseInputView,IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private CanvasGroup _canvasGroup;
        private bool _usedJoystick;

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
            float moveStep = 10*Time.deltaTime*CrossPlatformInputManager.GetAxis("Horizontal");
            if (moveStep>0)
                OnRightMove(moveStep);
            else if (moveStep<0)
            {
                OnLeftMove(moveStep);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _joystick.transform.position = eventData.position;
            _joystick.SetStartPosition(eventData.position);
            _joystick.OnPointerDown(eventData);
            _usedJoystick = this;
            _canvasGroup.alpha = 1;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _usedJoystick = false;
            _canvasGroup.alpha = 0;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _joystick.OnDrag(eventData);
        }
    }
}