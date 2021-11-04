using System;
using System.Collections.Generic;
using Code.Rewards.Model;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Rewards.View
{
    public class RewardView:MonoBehaviour
    {
        private const string LastTimeReward = nameof(LastTimeReward);
        private const string LastTimeRewardWeek = nameof(LastTimeRewardWeek);
        private const string ActiveSlot = nameof(ActiveSlot);
        [SerializeField] private float _timeCooldownDay = 86400;
        [SerializeField] private float _timeDeadlineDay = 172800;
        [SerializeField] private float _timeCooldownWeek = 604800;
        [SerializeField] private float _timeDeadlineWeek = 1209600;
        [SerializeField] private Button _getReward;
        [SerializeField] private Button _closeButton;
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
        public Button GETRewardButton => _getReward;
        public Button CloseButton => _closeButton;
        public Image ProgressBar => _progressBar;
        private float _showTime = 1f;

        public Image ProgressBarWeek => _progressBarWeek;

        public void Show()
        {
            gameObject.SetActive(true);
            transform.DOScale(Vector3.zero, _showTime).From();
        }

        public void Hide()
        {
            transform.DOScale(Vector3.zero, _showTime).OnComplete(() => gameObject.SetActive(false));
        }

        public int ActiveSlots
        {
            get => PlayerPrefs.GetInt(ActiveSlot, 0);
            set => PlayerPrefs.SetInt(ActiveSlot, value);
        }

        public DateTime? GetTimeRewardDay
        {
            get
            {
                var data = PlayerPrefs.GetString(LastTimeReward, null);
                if (string.IsNullOrEmpty(data)) return null;
                return DateTime.Parse(data);
            }
            set
            {
                if (value == null)
                    PlayerPrefs.DeleteKey(LastTimeReward);
                else
                    PlayerPrefs.SetString(LastTimeReward, value.ToString());
            }
        }        
        public DateTime? GetTimeRewardWeek
        {
            get
            {
                var data = PlayerPrefs.GetString(LastTimeRewardWeek, null);
                if (string.IsNullOrEmpty(data)) return null;
                return DateTime.Parse(data);
            }
            set
            {
                if (value == null)
                    PlayerPrefs.DeleteKey(LastTimeRewardWeek);
                else
                    PlayerPrefs.SetString(LastTimeRewardWeek, value.ToString());
            }
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