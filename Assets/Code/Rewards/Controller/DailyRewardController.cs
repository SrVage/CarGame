﻿using System;
using System.Collections;
using System.Collections.Generic;
using Code.Controller;
using Code.Rewards.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Rewards.Controller
{
    public class DailyRewardController:BaseController
    {
        private const int WeekReward=500;
        private RewardView _rewardView;
        private List<ContainerSlotRewardView> _containerSlotReward;
        private bool _isGetReward;
        private bool _isGetWeekReward;

        public DailyRewardController(RewardView view, Transform root)
        {
            _rewardView = view;
            _rewardView = Object.Instantiate(_rewardView, root);
            InitSlot();
            SubscribeButton();
            _rewardView.StartCoroutine(RewardsStateUpdater());
            RefreshUI();
        }
        
        private void InitSlot()
        {
            _containerSlotReward = new List<ContainerSlotRewardView>();
            for (int i = 0; i < _rewardView.Rewards.Count; i++)
            {
                var container =
                    Object.Instantiate(_rewardView.ContainerSlotReward, _rewardView.RewardContainer, false);
                container.transform.SetParent(_rewardView.RewardContainer);
                _containerSlotReward.Add(container);
            }
        }
        
        private IEnumerator RewardsStateUpdater()
        {
            while (true)
            {
                RefreshRewardsState();
                yield return new WaitForSeconds(1);
            }
        }

        private void RefreshRewardsState()
        {
            _isGetReward = true;
            _isGetWeekReward = true;
            if (_rewardView.GetTimeRewardDay.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _rewardView.GetTimeRewardDay.Value;

                if (timeSpan.Seconds > _rewardView.TimeDeadlineDay)
                {
                    _rewardView.GetTimeRewardDay = null;
                    _rewardView.ActiveSlots = 0;
                }
                else if (timeSpan.Seconds < _rewardView.TimeCooldownDay)
                {
                    _isGetReward = false;
                }
            }
            if (_rewardView.GetTimeRewardWeek.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _rewardView.GetTimeRewardWeek.Value;

                if (timeSpan.Seconds > _rewardView.TimeDeadlineWeek)
                {
                    _rewardView.GetTimeRewardWeek = null;
                }
                else if (timeSpan.Seconds < _rewardView.TimeCooldownDay)
                {
                    _isGetWeekReward = false;
                }
            }
            RefreshUI();
        }

        private void RefreshUI()
        {
            _rewardView.GETRewardButton.interactable = _isGetReward||_isGetWeekReward;
            if (!_isGetReward)
            {
                if (_rewardView.GetTimeRewardDay != null)
                {
                    var nextClaimTime = _rewardView.GetTimeRewardDay.Value.AddSeconds(_rewardView.TimeCooldownDay);
                    var currentClaimDown = nextClaimTime - DateTime.UtcNow;
                    _rewardView.ProgressBar.fillAmount = 1 - ((float)currentClaimDown.TotalSeconds / _rewardView.TimeCooldownDay);
                }
                
            }
            if (!_isGetWeekReward)
            {
                if (_rewardView.GetTimeRewardWeek != null)
                {
                    var nextClaimTime = _rewardView.GetTimeRewardWeek.Value.AddSeconds(_rewardView.TimeCooldownWeek);
                    var currentClaimDown = nextClaimTime - DateTime.UtcNow;
                    _rewardView.ProgressBarWeek.fillAmount = 1 - ((float)currentClaimDown.TotalSeconds / _rewardView.TimeCooldownWeek);
                }
            }
            for (int i = 0; i < _containerSlotReward.Count; i++)
            {
                _containerSlotReward[i].SetData(_rewardView.Rewards[i],i+1, i==_rewardView.ActiveSlots);
            }
            CurrencyView.Instance.RefreshText();
        }

        private void SubscribeButton()
        {
            _rewardView.GETRewardButton.onClick.AddListener(GetReward);
            _rewardView.CloseButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            _rewardView.gameObject.SetActive(false);
        }

        private void GetReward()
        {
            if (_isGetReward)
            {
                var reward = _rewardView.Rewards[_rewardView.ActiveSlots];
                switch (reward.RewardType)
                {
                    case RewardType.Gold:
                        CurrencyView.Instance.AddGold(reward.Value);
                        break;
                    case RewardType.Diamonds:
                        CurrencyView.Instance.AddDiamonds(reward.Value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _rewardView.GetTimeRewardDay = DateTime.UtcNow;
                _rewardView.ActiveSlots = (_rewardView.ActiveSlots + 1) % _rewardView.Rewards.Count;
            }
            if (_isGetWeekReward)
            {
                CurrencyView.Instance.AddDiamonds(WeekReward);
                _rewardView.GetTimeRewardWeek = DateTime.UtcNow;
            }
            RefreshRewardsState();
        }

    }
}