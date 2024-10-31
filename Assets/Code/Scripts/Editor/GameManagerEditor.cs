using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;

        EditorGUILayout.LabelField("Room 1 (Food Court) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[0] = EditorGUILayout.TextArea(gameManager.roomInfo[0], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 2 (Clothing Store) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[1] = EditorGUILayout.TextArea(gameManager.roomInfo[1], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 3 (Music Store) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[2] = EditorGUILayout.TextArea(gameManager.roomInfo[2], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 4 (Vent Maze) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[3] = EditorGUILayout.TextArea(gameManager.roomInfo[3], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 5 (Playplace) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[4] = EditorGUILayout.TextArea(gameManager.roomInfo[4], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;


        base.OnInspectorGUI();
    }
}
