using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameParameterSO))]
public class GameStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isfloat"));

        SerializedProperty hasSpecificName = serializedObject.FindProperty("hasSpecificName");

        EditorGUILayout.PropertyField(hasSpecificName);

        if (hasSpecificName.boolValue)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("specificName"));

        serializedObject.ApplyModifiedProperties();
    }
}
