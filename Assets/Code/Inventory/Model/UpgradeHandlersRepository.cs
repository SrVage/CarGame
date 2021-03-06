using System.Collections.Generic;
using Code.Config;
using Code.MainLogic.Controller;

namespace Code.Inventory.Model
{
    public class UpgradeHandlersRepository:BaseController
    {
        public IReadOnlyDictionary<int, IUpgradableCarHandler> UpgradeItems => _upgradeItemsById;
        private Dictionary<int, IUpgradableCarHandler> _upgradeItemsById = new Dictionary<int, IUpgradableCarHandler>();

        public UpgradeHandlersRepository(IItemRepository itemRepository)
        {
            
        }

        private void AddItemsInDictionary(ref Dictionary<int,IUpgradableCarHandler> upgradableCarHandlers, IItemRepository repository)
        {
            foreach (var item in repository.Content.Values)
            {
                if (upgradableCarHandlers.ContainsKey(item.ID)) continue;
                upgradableCarHandlers.Add(item.ID, CreateHandler(item));
            }
            
        }

        private IUpgradableCarHandler CreateHandler(IItem item)
        {
            switch (item.UpgradeType)
            {
                case UpgradeType.None:
                    return null;
                    break;
                case UpgradeType.Speed:
                    return new SpeedUpgrade(item.Value);
                    break;
                default:
                    return null;
            }
        }

        protected override void OnDispose()
        {
            _upgradeItemsById.Clear();
            _upgradeItemsById = null;
        }
    }
}