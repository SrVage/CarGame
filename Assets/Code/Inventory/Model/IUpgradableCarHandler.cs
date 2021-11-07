namespace Code.Inventory.Model
{
    public interface IUpgradableCarHandler
    {
        IUpgradableCar Upgrade(IUpgradableCar upgradableCar);
    }

    public interface IUpgradableCar
    {
        float Speed { get; set; }
        void Restore();
    }
}