using Code.GamePlay.View;
using Code.Inventory.Model;
using Code.MainLogic.Controller;
using JetBrains.Annotations;

namespace Code.Inventory.Controller
{
    public class InventoryController:BaseController, IInventoryController
    {
        private readonly IInventoryView _inventoryView;
        private readonly IInventory _inventoryModel;
        private readonly IItemRepository _itemRepository;
        private CarView _carView;

        public InventoryController([NotNull] IInventory inventoryModel,
            [NotNull] IItemRepository itemRepository)
        {
            _inventoryModel = inventoryModel;
            _itemRepository = itemRepository;
            //ApplyInventory();
            //_inventoryView = Object.FindObjectOfType<InventoryView>();
            //_inventoryView.Init(this);
        }

        public void InitCarView(CarView car)
        {
            _carView = car;
        }
        
        public void ApplyInventory()
        {
            foreach (var item in _itemRepository.Content.Values)
            {
                _inventoryModel.Equiped(item);
            }

            var equipedItems = _inventoryModel.GetEquipedItems();
            foreach (var item in equipedItems)
            {
                _carView.AddUpgrade(item);
            }

            //Object.FindObjectOfType<InventoryView>().Init(this);
            //_inventoryView.Display(equipedItems);
        }

        public void ShowInventory()
        {
            _inventoryView.Display(_inventoryModel.GetEquipedItems());
        }

        public void HideInventory()
        {
            //throw new NotImplementedException();
        }
    }
}