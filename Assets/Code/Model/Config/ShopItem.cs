using Code.Model.Shop;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.Model.Config
{
    [CreateAssetMenu (order = 1, fileName = "Shop Item", menuName = "Config/Shop/Item")]
    public class ShopItem:ScriptableObject
    {
        public ShopProduct ShopProduct;
        public int Cost;
        public Sprite Icon;
    }
}