using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoopListView))]
public class LoopListViewEditor : Editor
{
    public enum ArrangeType{ topDown, leftRight, leftRight_topDown}

    [SerializeField] ArrangeType arrangeToDisplay;

    public override void OnInspectorGUI()
    {
        arrangeToDisplay = (ArrangeType)EditorGUILayout.EnumPopup("Display", arrangeToDisplay);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("ItemPrefab"));

        EditorGUILayout.Space();

        switch (arrangeToDisplay)
        {
            case ArrangeType.topDown:
                DisplayTopDown();
                break;

            case ArrangeType.leftRight:
                DisplayLeftRight();
                break;

            case ArrangeType.leftRight_topDown:
                DisplayLeftRight_topDown();
                break;

        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DisplayTopDown()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ItemPadding_vertical"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("topDownMode"));
    }

    private void DisplayLeftRight()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ItemPadding_horizontal"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("leftRightMode"));
    }

    private void DisplayLeftRight_topDown()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ItemPadding_vertical"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ItemPadding_horizontal"));
        

        EditorGUILayout.PropertyField(serializedObject.FindProperty("numElementInLine"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("leftRight_topDownMode"));
    }
}
