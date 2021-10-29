namespace Code.AI.Model
{
    public interface IObserver
    {
        void Update(PlayerData data, DataType type);
    }
}