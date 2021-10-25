using System.Collections.Generic;
using UnityEngine;

namespace Code.Model.Config
{
    [CreateAssetMenu (order = 1, fileName = "Shop Items", menuName = "Config/Shop/Items List")]
    public class ShopItems:ScriptableObject
    {
        public List<ShopItem> ShopItemsList;
    }
}