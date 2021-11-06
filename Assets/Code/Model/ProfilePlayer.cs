using Code.Rewards.View;
using Code.Tools;
using UnityEngine;

namespace Code.Model
{
    public class ProfilePlayer
    {
        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            Gold = new SubscriptionPlayerPrefs("GoldKey");
            Diamond = new SubscriptionPlayerPrefs("DiamondKey");
        } 
        public SubscriptionProperty<GameState> CurrentState { get; }
        public SubscriptionPlayerPrefs Gold { get; }
        public SubscriptionPlayerPrefs Diamond { get; }
        
        public Car CurrentCar { get; }
    }

    public class SubscriptionPlayerPrefs : SubscriptionProperty<int>, IReadOnlySubscriptionProperty<int>
    {
        private readonly string _key;

        public SubscriptionPlayerPrefs(string key)
        {
            _key = key;
            this.value = PlayerPrefs.GetInt(_key);
            this.SubscribeOnChange(UpdateValue);
        }

    private void UpdateValue(int value)
        {
            PlayerPrefs.SetInt(_key, value);
        }
    }
}