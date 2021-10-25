using System;
using System.Collections.Generic;
using Code.Controller;
using Code.Model.Config;
using Code.Model.Inventory;
using Code.View;
using JetBrains.Annotations;

namespace Code.Model.Shed
{
    public class ShedController:BaseController, IShedController
    {
        private readonly Car _car;
        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemRepository _itemRepository;
        private readonly InventoryModel _inventory;
        private readonly InventoryController _inventoryController;

        public ShedController([NotNull] UpgradeItemRepository itemRepository, [NotNull] Car car)
        {
            if (itemRepository == null) throw new ArgumentNullException(nameof(itemRepository));
            _car = car ?? throw new ArgumentNullException(nameof(car));
            _itemRepository = new ItemRepository(itemRepository);
            _upgradeHandlersRepository = new UpgradeHandlersRepository(_itemRepository);
            AddController(_upgradeHandlersRepository);
            _inventory = new InventoryModel();
            _inventoryController = new InventoryController(_inventory, _itemRepository);
            AddController(_inventoryController);
        }
        
        public void Enter()
        {
            _inventoryController.ShowInventory();
        }

        public void Exit()
        {
            UpgradeCarWithEquipedItems(_car, _inventory.GetEquipedItems(), _upgradeHandlersRepository.UpgradeItems);
        }

        private void UpgradeCarWithEquipedItems(IUpgradableCar upgradableCar, IReadOnlyList<IItem> equipedItem, IReadOnlyDictionary<int, IUpgradableCarHandler> upgradableHandlers)
        {
            foreach (var item in equipedItem)
            {
                if (upgradableHandlers.TryGetValue(item.ID, out var handler))
                {
                    handler.Upgrade(upgradableCar);
                }
            }
        }
    }
}