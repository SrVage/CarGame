using System;
using Code.Rewards.View;
using UnityEngine;

namespace Code.Rewards.Model
{
    [Serializable]
    public struct Reward
    {
        public string Name;
        public int Value;
        public Sprite Sprite;
        public RewardType RewardType;
    }
}