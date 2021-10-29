using System;
using TMPro;

namespace Code.AI.Model
{
    public class UIObserver:IObserver
    {
        private TMP_Text _money;
        private TMP_Text _health;
        private TMP_Text _power;
        private TMP_Text _crime;

        public UIObserver(TMP_Text money, TMP_Text health, TMP_Text power, TMP_Text crime)
        {
            _money = money;
            _health = health;
            _power = power;
            _crime = crime;
        }

        public void Update(PlayerData data, DataType type)
        {
            switch (type)
            {
                case DataType.Money:
                    _money.text = $"Money: {data.Money}";
                    break;
                case DataType.Power:
                    _power.text = $"Power: {data.Power}";
                    break;
                case DataType.Health:
                    _health.text = $"Health: {data.Health}";
                    break;
                case DataType.Crime:
                    _crime.text = $"Crime: {data.Crime}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}