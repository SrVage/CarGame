using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.MainLogic.View
{
    public class MainMenuView:MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _rewardButton;
        [SerializeField] private Button _fightButton;

        public void Init(UnityAction start, UnityAction reward, UnityAction fight)
        {
            _startButton.onClick.AddListener(start);
            _rewardButton.onClick.AddListener(reward);
            _fightButton.onClick.AddListener(fight);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _rewardButton.onClick.RemoveAllListeners();
            _fightButton.onClick.RemoveAllListeners();
        }
    }
}