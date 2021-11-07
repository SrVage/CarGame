using System.Collections.Generic;
using Code.MainLogic.Model;
using Code.Rewards.Model;
using Code.Tools;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Rewards.View
{
    public class RewardView:MonoBehaviour
    {
        private const string ActiveSlot = nameof(ActiveSlot);
        [SerializeField] private float _timeCooldownDay = 86400;
        [SerializeField] private float _timeDeadlineDay = 172800;
        [SerializeField] private float _timeCooldownWeek = 604800;
        [SerializeField] private float _timeDeadlineWeek = 1209600;
        [SerializeField] private AnimatingButton _getReward;
        [SerializeField] private AnimatingButton _closeButton;
        [SerializeField] private ContainerSlotRewardView _containerSlotReward;
        [SerializeField] private Image _progressBar;
        [SerializeField] private Image _progressBarWeek;
        
        public float TimeCooldownWeek => _timeCooldownWeek;
        public float TimeDeadlineWeek => _timeDeadlineWeek;
        public float TimeCooldownDay => _timeCooldownDay;
        public float TimeDeadlineDay => _timeDeadlineDay;
        public ContainerSlotRewardView ContainerSlotReward => _containerSlotReward;
        public Transform RewardContainer;
        public List<Reward> Rewards;
        public AnimatingButton GETRewardButton => _getReward;
        public AnimatingButton CloseButton => _closeButton;
        public Image ProgressBar => _progressBar;
        private float _showTime = 1f;

        public Image ProgressBarWeek => _progressBarWeek;

        public void Show()
        {
            gameObject.SetActive(true);
            transform.DOScale(Vector3.zero, _showTime).From();
        }

        public void Hide(ProfilePlayer model)
        {
            transform.DOScale(Vector3.zero, _showTime).OnComplete(() => model.CurrentState.value = GameState.Start);
        }

        public int ActiveSlots
        {
            get => PlayerPrefs.GetInt(ActiveSlot, 0);
            set => PlayerPrefs.SetInt(ActiveSlot, value);
        }
        
        private void OnDestroy()
        {
            GETRewardButton.onClick.RemoveAllListeners();
        }
    }

    public enum RewardType
    {
        Gold=0,
        Diamonds = 1
    }
}