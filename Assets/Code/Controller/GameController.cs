using Code.Controller;
using Code.Model;
using Code.Model.Ability;
using Code.Model.Inventory;
using Code.Tools;
using Code.View;

namespace Code.InputLogic
{
    public class GameController:BaseController
    {
        public GameController(ProfilePlayer model, 
            InventoryController inventoryController, 
            IAbilityRepository abilityRepository, 
            IInventory inventoryModel)
        {
            var leftMove = new SubscriptionProperty<float>();
            var rightMove = new SubscriptionProperty<float>();

            var inputController = new InputBaseController(leftMove, rightMove, model.CurrentCar);
            AddController(inputController);

            var backgroundController = new BackgroundController(leftMove, rightMove);
            AddController(backgroundController);
            
            var carController = new CarController(leftMove, rightMove);
            AddController(carController);
            
            inventoryController.InitCarView(carController.GetCar().GetComponent<CarView>());
            inventoryController.ApplyInventory();

            var abilityController = new AbilityController(inventoryModel, abilityRepository,
                new AbilityCollectionViewStub(), carController);
        }
    }
}