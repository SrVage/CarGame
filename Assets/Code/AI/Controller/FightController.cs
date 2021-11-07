using Code.AI.Model;
using Code.AI.View;
using Code.MainLogic.Controller;
using Code.MainLogic.Model;
using Code.Tools;
using UnityEngine;

namespace Code.AI.Controller
{
    public class FightController:BaseController
    {
        private ResourcePath _fightResourcePath = new ResourcePath() { PathResource = "Prefabs/fightPanel"};
        private ProfilePlayer _model;
        private ObserverView _view;
        private Health _health;
        private Money _money;
        private Power _power;
        private Crime _crime;
        private Enemy _enemy;
        
        public FightController(Transform uiRoot, ProfilePlayer model)
        {
            _model = model;
            CreateView(uiRoot);
            CreateStats();
            _enemy = new Enemy();
            AddObserver(_enemy);
            AddObserver(new UIObserver(_view.MoneyStat, _view.HealthStat, _view.PowerStat, _view.CrimeStat));
            _enemy.OnUpdate += UpdateEnemyStat;
        }

        private void CreateStats()
        {
            _health = new Health(nameof(Health));
            _power = new Power(nameof(Power));
            _money = new Money(nameof(Money));
            _crime = new Crime(nameof(Crime));
        }

        private void CreateView(Transform uiRoot)
        {
            var prefab = ResourceLoader.LoadPrefab(_fightResourcePath);
            var go = GameObject.Instantiate(prefab, uiRoot);
            AddGameObject(go);
            _view = go.GetComponent<ObserverView>();
            _view.Init(ChangeMoney, ChangeHealth, ChangePower, ChangeCrime, Fight, Exit);
        }

        private void AddObserver(IObserver observer)
        {
            _health.AddObserver(observer);
            _power.AddObserver(observer);
            _money.AddObserver(observer);
            _crime.AddObserver(observer);
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
                _view.GO.gameObject.SetActive(true);
            else
                _view.GO.gameObject.SetActive(false);
        }
        
        private void UpdateEnemyStat(int power)
        {
            _view.EnemyPowerStat.text = $"Enemy Power: {_enemy.EnemyPower}";
        }

        private void Fight()
        {
            _view.FightStatus.gameObject.SetActive(true);
            if (_enemy.EnemyPower > _power.Power)
                _view.FightStatus.text = "You loose";
            else
                _view.FightStatus.text = "You win";
        }

        private void Exit()
        {
            _model.CurrentState.value = GameState.Start;
        }
    }
}