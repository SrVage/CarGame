using Code.Tools;
using UnityEngine;

namespace Code.Tools
{
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