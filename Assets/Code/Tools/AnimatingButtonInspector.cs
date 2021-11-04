using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Code.Tools
{
    [CustomEditor(typeof(AnimatingButton))]
    public class AnimatingButtonInspector:ButtonEditor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            var curveEase = new PropertyField(serializedObject.FindProperty(AnimatingButton.CurveEase));
            var duration = new PropertyField(serializedObject.FindProperty(AnimatingButton.Duration));
            var strenth = new PropertyField(serializedObject.FindProperty(AnimatingButton.Strength));
            
            root.Add(curveEase);
            root.Add(duration);
            root.Add(strenth);
            root.Add(new IMGUIContainer(OnInspectorGUI));
            
            return root;
        }
    }
}