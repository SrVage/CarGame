using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.View
{
    public class MainMenuView:MonoBehaviour
    {
        public event Action StartClick;
        [SerializeField] private Button _startButton;

        private void Awake() => _startButton.onClick.AddListener(OnClick);

        public void OnClick()
        {
            StartClick?.Invoke();
        }
        
    }
}