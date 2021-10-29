using System;
using System.Collections.Generic;

namespace Code.AI.Model
{
    public abstract class PlayerData : IObservable
    {
        private List<IObserver> _enemy = new List<IObserver>();
        private List<IObserver> _otherObserver = new List<IObserver>();
        private string _dataTitle;
        private int _money;
        private int _power;
        private int _health;
        private int _crime;

        protected PlayerData(string title)
        {
            _dataTitle = title;
        }

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                if (_money < 0) _money = 0;
                Notification(this, DataType.Money);
            }
        }

        public int Power
        {
            get => _power;
            set
            {
                _power = value;
                if (_power < 0) _power = 0;
                Notification(this, DataType.Power);
            }
        }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health < 0) _health = 0;
                Notification(this, DataType.Health);
            }
        }

        public int Crime
        {
            get => _crime;
            set
            {
                _crime = value;
                if (_crime < 0) _crime = 0;
                Notification(this, DataType.Crime);
            }
        }


        public void AddObserver(IObserver observer)
        {
            if (observer is IEnemy)
                _enemy.Add(observer);
            else
                _otherObserver.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer is IEnemy)
                _enemy.Remove(observer);
            else
                _otherObserver.Remove(observer);
        }

        public void Notification(PlayerData data, DataType type)
        {
            foreach (var enemy in _enemy)
            {
                enemy.Update(data, type);
            }

            foreach (var observer in _otherObserver)
            {
                observer.Update(data, type);
            }
        }
    }


    public enum DataType
        {
            Money = 0,
            Power = 1,
            Health = 2,
            Crime = 3
        }
    
    public class Money:PlayerData
    {
        public Money(string title) : base(nameof(Money))
        {
        }
    }
    
    public class Power:PlayerData
    {
        public Power(string title) : base(nameof(Power))
        {
        }
    }
    
    public class Health:PlayerData
    {
        public Health(string title) : base(nameof(Health))
        {
        }
    }
    public class Crime:PlayerData
    {
        public Crime(string title) : base(nameof(Crime))
        {
        }
    }
}