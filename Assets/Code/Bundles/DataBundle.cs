using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace Code.Bundles
{
    [Serializable]
    public class DataBundle
    {
        public string Name;
        public AssetReference Object;
    }
}