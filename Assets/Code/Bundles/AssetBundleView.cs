using UnityEngine;

namespace Code.Bundles
{
    public class AssetBundleView : MonoBehaviour
    {
        [SerializeField] private DataBundle[] _data;

        public DataBundle[] Data => _data;
    }
}