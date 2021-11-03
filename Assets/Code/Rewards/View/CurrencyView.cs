using System;
using TMPro;
using UnityEngine;

namespace Code.Rewards.View
{
    public class CurrencyView:MonoBehaviour
    {
        private const string GoldKey = nameof(GoldKey);
        private const string DiamondsKey = nameof(DiamondsKey);
        [SerializeField] private TMP_Text _currentGold;
        [SerializeField] private TMP_Text _currentDiamonds;
        public static CurrencyView Instance;

        private void Awake()
        {
            Instance = this;
        }

        public int Gold
        {
            get => PlayerPrefs.GetInt(GoldKey, 0);
            set => PlayerPrefs.SetInt(GoldKey, value);
        }

        public int Diamonds
        {
            get => PlayerPrefs.GetInt(DiamondsKey, 0);
            set => PlayerPrefs.SetInt(DiamondsKey, value);
        }

        public void AddGold(int value)
        {
            Gold += value;
            RefreshText();
        }

        public void AddDiamonds(int value)
        {
            Diamonds += value;
            RefreshText();
        }

        public void RefreshText()
        {
            _currentGold.text = Gold.ToString();
            _currentDiamonds.text = Diamonds.ToString();
        }
    }
}