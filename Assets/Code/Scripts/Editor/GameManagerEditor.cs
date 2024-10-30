using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;

        EditorGUILayout.LabelField("Room 1 Text:", EditorStyles.whiteLargeLabel);
        EditorGUI.indentLevel++;
        gameManager.roomInfo[0] = EditorGUILayout.TextArea(gameManager.roomInfo[0]);

        EditorGUILayout.LabelField("Room 2 Text:");
        gameManager.roomInfo[1] = EditorGUILayout.TextArea(gameManager.roomInfo[1]);
        EditorGUILayout.LabelField("Room 3 Text:");
        gameManager.roomInfo[2] = EditorGUILayout.TextArea(gameManager.roomInfo[2]);
        gameManager.roomInfo[3] = EditorGUILayout.TextArea(gameManager.roomInfo[3]);
        gameManager.roomInfo[4] = EditorGUILayout.TextArea(gameManager.roomInfo[4]);

        base.OnInspectorGUI();
    }
}
