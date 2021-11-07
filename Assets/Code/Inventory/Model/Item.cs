using Code.Config;
using UnityEngine;

namespace Code.Inventory.Model
{
    public class Item:IItem
    {
        public int ID { get; set; }
        public float Value { get; set; }
        public ItemInfo ItemInfo { get; set; }
        public UpgradeType UpgradeType { get; set; }
        public Place Place { get; set; }
        public Sprite Sprite { get; set; }
    }
}