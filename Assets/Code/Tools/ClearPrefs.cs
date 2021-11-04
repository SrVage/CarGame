using UnityEngine;
using UnityEditor;

namespace Code.Tools
{
    public static class ClearPrefs
    {
        [MenuItem("Tools/Clear PlayerPrefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}