using Code.Tools;

namespace Code.Model
{
    internal class ProfilePlayer
    {
        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
        } 
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
    }
}