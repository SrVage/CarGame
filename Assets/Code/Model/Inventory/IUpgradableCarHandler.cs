namespace Code.Model.Inventory
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