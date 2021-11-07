using System;
using Code.Tools;
using UnityEngine;

namespace Code.GamePlay.Model
{
    public class RewardModel
    {
        private const string LastTimeReward = nameof(LastTimeReward);
        private const string LastTimeRewardWeek = nameof(LastTimeRewardWeek);
        public SubscriptionPlayerPrefs Gold { get; }
        public SubscriptionPlayerPrefs Diamond { get; }

        public RewardModel()
        {
            Gold = new SubscriptionPlayerPrefs("GoldKey");
            Diamond = new SubscriptionPlayerPrefs("DiamondKey");
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
    }
}