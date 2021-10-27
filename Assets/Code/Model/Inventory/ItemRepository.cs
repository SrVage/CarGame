using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Code.Model.Config;

namespace Code.Model.Inventory
{
    public class ItemRepository:IItemRepository, IDisposable
    {
        public IReadOnlyDictionary<int, IItem> Content => _items;
        private Dictionary<int, IItem> _items = new Dictionary<int, IItem>();

        public ItemRepository(UpgradeItemRepository repository)
        {
            AddDictionaryFromCFG(repository, ref _items);
        }

        private void AddDictionaryFromCFG(UpgradeItemRepository repository, ref Dictionary<int, IItem> item)
        {
            foreach (var repositoryItem in repository.UpgradeItemConfigs)
            {
                if (item.ContainsKey(repositoryItem.ID)) continue;
                item.Add(repositoryItem.ID, CreateItem(repositoryItem));
            }
        }

        private IItem CreateItem(UpgradeItemConfig itemConfig)
        {
            return new Item()
            {
                ID = itemConfig.ID,
                ItemInfo = new ItemInfo() { Name = itemConfig.InventoryItem.Title },
                Place = itemConfig.Place,
                Sprite = itemConfig.Sprite,
                Value = itemConfig.Value,
                UpgradeType = itemConfig.UpgradeType
            };
        }
        
        public void Dispose()
        {
            _items.Clear();
            _items = null;
        }
    }
}