using Code.Shop;
using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu (order = 1, fileName = "Shop Item", menuName = "Config/Shop/Item")]
    public class ShopItem:ScriptableObject
    {
        public ShopProduct ShopProduct;
        public int Cost;
        public Sprite Icon;
    }
}