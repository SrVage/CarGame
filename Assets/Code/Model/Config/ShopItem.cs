using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.Model.Config
{
    [CreateAssetMenu (order = 1, fileName = "Shop Item", menuName = "Config/Shop/Item")]
    public class ShopItem:ScriptableObject
    {
        public string ID;
        public ProductType CurrentProductType;
        public string Name;
        public int Cost;
        public Sprite Icon;
        public int Value;
    }
}