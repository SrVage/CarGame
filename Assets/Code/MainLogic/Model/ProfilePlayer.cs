using Code.GamePlay.Model;
using Code.Tools;

namespace Code.MainLogic.Model
{
    public class ProfilePlayer
    {

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            RewardModel = new RewardModel();
        } 
        public SubscriptionProperty<GameState> CurrentState { get; }
        
        public Car CurrentCar { get; }
        public RewardModel RewardModel { get; }
    }
}