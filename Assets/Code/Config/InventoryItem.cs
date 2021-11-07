using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu (order = 1, fileName = "Inventory Item", menuName = "Config/Inventory/Item")]
    public class InventoryItem:ScriptableObject
    {
        public int ID;
        public string Title;
    }
}