using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.AI.View
{
    public class ObserverView:MonoBehaviour
    {
        [SerializeField] private Button _moneyPlus;
        [SerializeField] private Button _moneyMinus;
        [SerializeField] private Button _powerPlus;
        [SerializeField] private Button _powerMinus;
        [SerializeField] private Button _healthPlus;
        [SerializeField] private Button _healthMinus;
        [SerializeField] private Button _crimePlus;
        [SerializeField] private Button _crimeMinus;
        [SerializeField] private Button _fight;
        [SerializeField] private Button _go;
        [SerializeField] private Button _exit;
        [SerializeField] private TMP_Text _moneyStat;
        [SerializeField] private TMP_Text _powerStat;
        [SerializeField] private TMP_Text _healthStat;
        [SerializeField] private TMP_Text _crimeStat;
        [SerializeField] private TMP_Text _enemyPowerStat;
        [SerializeField] private TMP_Text _fightStatus;

        public TMP_Text MoneyStat
        {
            get => _moneyStat;
            set => _moneyStat = value;
        }

        public TMP_Text PowerStat
        {
            get => _powerStat;
            set => _powerStat = value;
        }

        public TMP_Text HealthStat
        {
            get => _healthStat;
            set => _healthStat = value;
        }

        public TMP_Text CrimeStat
        {
            get => _crimeStat;
            set => _crimeStat = value;
        }

        public TMP_Text EnemyPowerStat
        {
            get => _enemyPowerStat;
            set => _enemyPowerStat = value;
        }

        public TMP_Text FightStatus
        {
            get => _fightStatus;
            set => _fightStatus = value;
        }

        public Button GO
        {
            get => _go;
            set => _go = value;
        }

        public void Init(UnityAction<bool> changeMoney, UnityAction<bool> changeHealth, UnityAction<bool> changePower, UnityAction<bool> changeCrime, UnityAction fight, UnityAction exit)
        {
            _moneyPlus.onClick.AddListener(() => changeMoney(true));
            _moneyMinus.onClick.AddListener(() => changeMoney(false));
            _healthPlus.onClick.AddListener(() => changeHealth(true));
            _healthMinus.onClick.AddListener(() => changeHealth(false));
            _powerPlus.onClick.AddListener(() => changePower(true));
            _powerMinus.onClick.AddListener(() => changePower(false));
            _crimePlus.onClick.AddListener(() => changeCrime(true));
            _crimeMinus.onClick.AddListener(() => changeCrime(false));
            _fight.onClick.AddListener(fight);
            _exit.onClick.AddListener(exit);
        }
    }
}