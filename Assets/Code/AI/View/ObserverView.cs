using Code.AI.Model;
using TMPro;
using UnityEngine;
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
        [SerializeField] private TMP_Text _moneyStat;
        [SerializeField] private TMP_Text _powerStat;
        [SerializeField] private TMP_Text _healthStat;
        [SerializeField] private TMP_Text _crimeStat;
        [SerializeField] private TMP_Text _enemyPowerStat;
        [SerializeField] private TMP_Text _fightStatus;
        private Health _health;
        private Money _money;
        private Power _power;
        private Crime _crime;
        private Enemy _enemy;

        private void Start()
        {
            _moneyPlus.onClick.AddListener(() => ChangeMoney(true));
            _moneyMinus.onClick.AddListener(() => ChangeMoney(false));
            _healthPlus.onClick.AddListener(() => ChangeHealth(true));
            _healthMinus.onClick.AddListener(() => ChangeHealth(false));
            _powerPlus.onClick.AddListener(() => ChangePower(true));
            _powerMinus.onClick.AddListener(() => ChangePower(false));
            _crimePlus.onClick.AddListener(() => ChangeCrime(true));
            _crimeMinus.onClick.AddListener(() => ChangeCrime(false));
            _fight.onClick.AddListener(() =>Fight());
            _health = new Health(nameof(Health));
            _power = new Power(nameof(Power));
            _money = new Money(nameof(Money));
            _crime = new Crime(nameof(Crime));
            _enemy = new Enemy();
            var ui = new UIObserver(_moneyStat, _healthStat, _powerStat, _crimeStat);
            _health.AddObserver(_enemy);
            _health.AddObserver(ui);
            _power.AddObserver(_enemy);
            _power.AddObserver(ui);
            _money.AddObserver(_enemy);
            _money.AddObserver(ui);
            _crime.AddObserver(_enemy);
            _crime.AddObserver(ui);
            _enemy.OnUpdate += UpdateEnemyStat;
        }

        private void ChangeMoney(bool add)
        {
            if (add)
                _money.Money += 1;
            else
                _money.Money -= 1;
        }

        private void ChangePower(bool add)
        {
            if (add)
                _power.Power += 1;
            else
                _power.Power -= 1;
        }

        private void ChangeHealth(bool add)
        {
            if (add)
                _health.Health += 1;
            else
                _health.Health -= 1;
        }

        private void ChangeCrime(bool add)
        {
            if (add)
                _crime.Crime += 1;
            else
                _crime.Crime -= 1;
            if (_crime.Crime < 4) 
                _go.gameObject.SetActive(true);
            else
                _go.gameObject.SetActive(false);
        }

        private void Fight()
        {
            _fightStatus.gameObject.SetActive(true);
            if (_enemy.EnemyPower > _power.Power)
                _fightStatus.text = "You loose";
            else
                _fightStatus.text = "You win";
        }

        private void UpdateEnemyStat(int power)
        {
            _enemyPowerStat.text = $"Enemy Power: {_enemy.EnemyPower}";
        }
    }
}