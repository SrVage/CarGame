using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu (order = 2, fileName = "Upgrade Item", menuName = "Config/Inventory/UpgradeItem")]
    public class UpgradeItemConfig:ScriptableObject
    {
        public InventoryItem InventoryItem;
        public UpgradeType UpgradeType;
        public Place Place;
        public float Value;
        public Sprite Sprite;
        public int ID => InventoryItem.ID;
    }

    public enum UpgradeType
    {
        None = 0,
        Speed = 1
    }

    public enum Place
    {
        None = 0,
        Wheels = 1,
        Forward = 2
    }
}