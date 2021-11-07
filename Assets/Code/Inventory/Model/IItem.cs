using Code.Config;
using UnityEngine;

namespace Code.Inventory.Model
{
    public interface IItem
    {
        public int ID { get;}
        
        public float Value { get; }
        public ItemInfo ItemInfo { get;}
        
        public UpgradeType UpgradeType { get; }
        
        public Place Place { get; }

        public Sprite Sprite { get; }
    }
}