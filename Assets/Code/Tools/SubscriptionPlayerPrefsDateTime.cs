using System;
using UnityEngine;

namespace Code.Tools
{
    public class SubscriptionPlayerPrefsDateTime:SubscriptionProperty<DateTime?>
    {
        private readonly string _key;

        public SubscriptionPlayerPrefsDateTime(string key)
        {
            _key = key;
            var data = PlayerPrefs.GetString(_key, null);
            if (string.IsNullOrEmpty(data)) this.value=null;
            else this.value = DateTime.Parse(data);
            this.SubscribeOnChange(UpdateValue);
        }

        private void UpdateValue(DateTime? value)
        {
            PlayerPrefs.SetString(_key, value.ToString());
        }
    }
}