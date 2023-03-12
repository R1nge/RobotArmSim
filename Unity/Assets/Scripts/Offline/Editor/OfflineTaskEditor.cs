using UnityEditor;
using UnityEngine;

namespace Offline.Editor
{
    [CustomEditor(typeof(OfflineTask), true)]
    public class OfflineTaskEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            OfflineTask task = (OfflineTask)target;
            if (GUILayout.Button("Compile"))
            {
                task.Compile();
            }
            else if (GUILayout.Button("Execute"))
            {
                task.Execute();
            }
            else if (GUILayout.Button("Stop"))
            {
                task.Stop();
            }
        }
    }
}