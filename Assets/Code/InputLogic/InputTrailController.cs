using Code.Tools;
using Code.View;
using JoostenProductions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.InputLogic
{
    public class InputTrailController:BaseInputView, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private TrailView _trailView;
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void Move()
        {
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _trailView.ShowTrail(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _trailView.ShowTrail(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _trailView.transform.position = eventData.position;
        }
    }
}