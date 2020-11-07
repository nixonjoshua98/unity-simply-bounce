using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelEditor))]
public class LevelEditorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelEditor script = (LevelEditor)target;

        if (GUILayout.Button("Serialize"))
        {
            script.Serialize();
        }
    }
}
