namespace Code.Model.Inventory
{
    public class SpeedUpgrade:IUpgradableCarHandler
    {
        private float _speed;

        public SpeedUpgrade(float speed)
        {
            _speed = speed;
        }
        
        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }
    }
}