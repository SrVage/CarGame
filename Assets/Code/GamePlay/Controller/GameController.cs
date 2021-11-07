using Code.Ability.Controller;
using Code.Ability.Model;
using Code.Ability.View;
using Code.GamePlay.Model;
using Code.GamePlay.View;
using Code.InputLogic;
using Code.Inventory.Controller;
using Code.Inventory.Model;
using Code.MainLogic.Controller;
using Code.MainLogic.Model;
using Code.Tools;
using UnityEngine;

namespace Code.GamePlay.Controller
{
    public class GameController:BaseController
    {
        private readonly ResourcePath _path = new ResourcePath { PathResource = "Prefabs/Ability" };
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

           var ability = Object.Instantiate(ResourceLoader.LoadPrefab(_path)).GetComponent<AbilityCollectionViewUI>();

            var abilityController = new AbilityController(inventoryModel, abilityRepository,
                ability, carController);
            AddController(abilityController);
        }
    }
}