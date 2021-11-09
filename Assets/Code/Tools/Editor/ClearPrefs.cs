using UnityEditor;
using UnityEngine;

namespace Code.Tools.Editor
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