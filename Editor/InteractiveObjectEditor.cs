using UnityEngine;
using UnityEditor;
using Snowraph.InteractiveObjects;

namespace Snowraph.InteractiveObjects.Utilities
{
    [CustomEditor(typeof(InteractiveObject))]
    public class InteractiveObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            InteractiveObject interactiveObjectScript = (InteractiveObject)target;
            if (GUILayout.Button("Update component list"))
            {
                interactiveObjectScript.UpdateComponentList();
            }
        }
    }
}
