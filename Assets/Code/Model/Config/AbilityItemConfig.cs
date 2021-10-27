using Code.Tools;
using UnityEngine;

namespace Code.Model.Config
{
    [CreateAssetMenu (order = 5, fileName = "Ability Item", menuName = "Config/Ability/Item")]
    public class AbilityItemConfig:ScriptableObject, IUnique<int>
    {
        public InventoryItem Item;
        public GameObject View;
        public AbitityType Type;
        public float Value;
        public int ID => Item.ID;
    }

    public enum AbitityType
    {
        None = 0,
        Gun = 1
    }
}