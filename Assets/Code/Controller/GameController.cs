using Code.Controller;
using Code.Model;
using Code.Model.Ability;
using Code.Model.Inventory;
using Code.Tools;
using Code.View;
using UnityEngine;

namespace Code.InputLogic
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