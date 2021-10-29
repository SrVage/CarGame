namespace Code.AI.Model
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notification(PlayerData data, DataType type);
    }
}