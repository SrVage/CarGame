using System;
using System.Collections.Generic;

namespace Code.AI.Model
{
    public class Enemy:IEnemy
    {
        public event Action<int> OnUpdate; 
        private int _playerPower;
        private int _playerHealth;
        private int _playerMoney;
        private float _kMoney = 0.05f;
        private float _kPower = 0.7f;
        private float _kHealth = 0.15f;

        public int EnemyPower
        {
            get => (int)(_playerPower*_kPower + _playerHealth*_kHealth + _playerMoney*_kMoney);
        }
        
        public void Update(PlayerData data, DataType type)
        {
            switch (type)
            {
                case DataType.Money:
                    _playerMoney = data.Money;
                    break;
                case DataType.Power:
                    _playerPower = data.Power;
                    break;
                case DataType.Health:
                    _playerHealth = data.Health;
                    break;
                case DataType.Crime:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            OnUpdate?.Invoke(EnemyPower);
        }
        
    }
}