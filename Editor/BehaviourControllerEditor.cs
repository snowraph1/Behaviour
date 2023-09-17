using UnityEngine;
using UnityEditor;
using Snowraph.Behaviour;

namespace Snowraph.Behaviour.Utilities
{
    [CustomEditor(typeof(BehaviourController))]
    public class InteractiveObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            BehaviourController behaviourControllerScript = (BehaviourController)target;
            if (GUILayout.Button("Update component list"))
            {
                behaviourControllerScript.UpdateComponentList();
            }
        }
    }
}
