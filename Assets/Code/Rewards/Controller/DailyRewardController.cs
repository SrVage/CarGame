using System;
using System.Collections;
using System.Collections.Generic;
using Code.MainLogic.Controller;
using Code.MainLogic.Model;
using Code.Rewards.View;
using Code.Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Rewards.Controller
{
    public class DailyRewardController:BaseController
    {
        private ResourcePath _rewardMenuResourcePath = new ResourcePath() { PathResource = "Prefabs/rewardPanel"};
        private const int WeekReward=500;
        private RewardView _rewardView;
        private List<ContainerSlotRewardView> _containerSlotReward;
        private readonly ProfilePlayer _model;
        private bool _isGetReward;
        private bool _isGetWeekReward;

        public DailyRewardController(Transform root, ProfilePlayer model)
        {
            _model = model;
            CreateView(root);
            InitSlot();
            SubscribeButton();
            _rewardView.StartCoroutine(RewardsStateUpdater());
            RefreshUI();
        }

        private void CreateView(Transform root)
        {
            var prefab = ResourceLoader.LoadPrefab(_rewardMenuResourcePath);
            var go = Object.Instantiate(prefab, root);
            AddGameObject(go);
            _rewardView = go.GetComponent<RewardView>();
            _rewardView.Show();
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
            if (_model.RewardModel.GetTimeRewardDay.HasValue)
            {
                var timeSpan = DateTime.UtcNow -_model.RewardModel.GetTimeRewardDay.Value;
                if (timeSpan.TotalSeconds > _rewardView.TimeDeadlineDay)
                {
                    _model.RewardModel.GetTimeRewardDay = null;
                    _rewardView.ActiveSlots = 0;
                }
                else if (timeSpan.TotalSeconds < _rewardView.TimeCooldownDay)
                {
                    _isGetReward = false;
                }
            }
            if (_model.RewardModel.GetTimeRewardWeek.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _model.RewardModel.GetTimeRewardWeek.Value;

                if (timeSpan.TotalSeconds > _rewardView.TimeDeadlineWeek)
                {
                    _model.RewardModel.GetTimeRewardWeek = null;
                }
                else if (timeSpan.TotalSeconds < _rewardView.TimeCooldownDay)
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
                if (_model.RewardModel.GetTimeRewardDay != null)
                {
                    var nextClaimTime = _model.RewardModel.GetTimeRewardDay.Value.AddSeconds(_rewardView.TimeCooldownDay);
                    var currentClaimDown = nextClaimTime - DateTime.UtcNow;
                    _rewardView.ProgressBar.fillAmount = 1 - ((float)currentClaimDown.TotalSeconds / _rewardView.TimeCooldownDay);
                }
                            
            }
            if (!_isGetWeekReward)
            {
                if (_model.RewardModel.GetTimeRewardWeek != null)
                {
                    var nextClaimTime = _model.RewardModel.GetTimeRewardWeek.Value.AddSeconds(_rewardView.TimeCooldownWeek);
                    var currentClaimDown = nextClaimTime - DateTime.UtcNow;
                    _rewardView.ProgressBarWeek.fillAmount = 1 - ((float)currentClaimDown.TotalSeconds / _rewardView.TimeCooldownWeek);
                }
            }
            for (int i = 0; i < _containerSlotReward.Count; i++)
            {
                _containerSlotReward[i].SetData(_rewardView.Rewards[i],i+1, i==_rewardView.ActiveSlots);
            }
        }

        private void SubscribeButton()
        {
            _rewardView.GETRewardButton.afterAnimationEvent.AddListener(GetReward);
            _rewardView.CloseButton.afterAnimationEvent.AddListener(Close);
        }

        private void Close()
        {
            _rewardView.Hide(_model);
        }

        private void GetReward()
        {
            if (_isGetReward)
            {
                var reward = _rewardView.Rewards[_rewardView.ActiveSlots];
                switch (reward.RewardType)
                {
                    case RewardType.Gold:
                        _model.RewardModel.Gold.value += reward.Value;
                        break;
                    case RewardType.Diamonds:
                        _model.RewardModel.Diamond.value += reward.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _model.RewardModel.GetTimeRewardDay = DateTime.UtcNow;
                _rewardView.ActiveSlots = (_rewardView.ActiveSlots + 1) % _rewardView.Rewards.Count;
            }
            if (_isGetWeekReward)
            {
                _model.RewardModel.Diamond.value += WeekReward;
                _model.RewardModel.GetTimeRewardWeek = DateTime.UtcNow;
            }
            RefreshRewardsState();
        }

    }
}