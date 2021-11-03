using UnityEditor;
using UnityEngine;

namespace Code.Tools
{
    public class ClearPrefs
    {
        [MenuItem("Tools/Clear PlayerPrefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}