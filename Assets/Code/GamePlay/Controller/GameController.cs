using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Ability.Controller;
using Code.Ability.Model;
using Code.Ability.View;
using Code.Bundles;
using Code.GamePlay.View;
using Code.InputLogic;
using Code.Inventory.Controller;
using Code.Inventory.Model;
using Code.MainLogic.Controller;
using Code.MainLogic.Model;
using Code.Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Code.GamePlay.Controller
{
    public class GameController:BaseController
    {
        private readonly ProfilePlayer _model;
        private readonly InventoryController _inventoryController;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IInventory _inventoryModel;
        private readonly ResourcePath _path = new ResourcePath { PathResource = "Prefabs/Ability" };
        private List<AsyncOperationHandle> _asyncs;
        public GameController(ProfilePlayer model, 
            InventoryController inventoryController, 
            IAbilityRepository abilityRepository, 
            IInventory inventoryModel)
        {
            _model = model;
            _inventoryController = inventoryController;
            _abilityRepository = abilityRepository;
            _inventoryModel = inventoryModel;
            _asyncs = new List<AsyncOperationHandle>();
            LoadLevel();
        }
        
        private async void LoadLevel()
        { 
            var leftMove = new SubscriptionProperty<float>();
            var rightMove = new SubscriptionProperty<float>();
         
            var inputController = new InputBaseController(leftMove, rightMove, _model.CurrentCar);
            AddController(inputController);

            var time = DateTime.Now;
            var _data = Object.FindObjectOfType<AssetBundleView>().Data;
            foreach (var data in _data)
            {
                if (data.Name == "Car")
                {
                    var go = await CreateGameObject(data);
                    var carController = new CarController(leftMove, rightMove, go.Result);
                    AddController(carController);
                    _inventoryController.InitCarView(go.Result.GetComponent<CarView>());
                    _inventoryController.ApplyInventory();
                    var ability = Object.Instantiate(ResourceLoader.LoadPrefab(_path)).GetComponent<AbilityCollectionViewUI>();
                    var abilityController = new AbilityController(_inventoryModel, _abilityRepository,
                                    ability, carController);
                    AddController(abilityController);
                }

                if (data.Name == "Background")
                {
                    var go = await CreateGameObject(data);
                    var backgroundController = new BackgroundController(leftMove, rightMove, go.Result);
                    AddController(backgroundController);
                }
            }
            Debug.Log((DateTime.Now-time).TotalSeconds);
        }

        private async Task<AsyncOperationHandle<GameObject>> CreateGameObject(DataBundle data)
        {
            var go = Addressables.InstantiateAsync(data.Object);
            await Task.WhenAll(go.Task);
            Debug.Log(go.Result);
            _asyncs.Add(go);
            return go;
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            foreach (var asyn in _asyncs)
            {
                Addressables.Release(asyn);
            }
            _asyncs.Clear();
        }
    }
}