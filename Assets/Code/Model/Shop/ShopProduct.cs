using System;
using UnityEngine.Purchasing;

namespace Code.Model.Shop
{
    [Serializable]
    public class ShopProduct
    {
        public string ID;
        public ProductType CurrentProductType;
        public ProductModification ProductModification;
    }

    [Serializable]
    public class ProductModification
    {
        public Modification Modification;
        public int Value;
    }

    public enum Modification
    {
        None = 0,
        Gold = 1,
        Item = 2,
        NoAds = 3
    }
}