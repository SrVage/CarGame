using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Tools
{
    public class AnimatingButton:Button
    {
        public static string CurveEase => nameof(_ease);
        public static string Duration => nameof(_duration);
        public static string Strength => nameof(_strength);
        
        public ButtonClickedEvent afterAnimationEvent = new ButtonClickedEvent();
        private RectTransform _rectTransform;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _strength = 40;
        [SerializeField] private Ease _ease;

        protected override void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            ActivateAnimation();
        }

        private void ActivateAnimation()
        {
            _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_ease)
                .OnComplete(() => afterAnimationEvent?.Invoke());
        }
        
        
        
    }
}