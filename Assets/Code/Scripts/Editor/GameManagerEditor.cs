using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var serializedObject = new SerializedObject(target);

        GameManager gameManager = (GameManager)target;

        EditorStyles.textField.wordWrap = true;

        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Room 1 (Food Court) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[0] = EditorGUILayout.TextField(gameManager.roomInfo[0], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 2 (Clothing Store) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[1] = EditorGUILayout.TextField(gameManager.roomInfo[1], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 3 (Music Store) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[2] = EditorGUILayout.TextField(gameManager.roomInfo[2], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 4 (Vent Maze) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[3] = EditorGUILayout.TextField(gameManager.roomInfo[3], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Room 5 (Playplace) Text:", EditorStyles.largeLabel, GUILayout.MinHeight(10f));
        EditorGUI.indentLevel++;
        gameManager.roomInfo[4] = EditorGUILayout.TextField(gameManager.roomInfo[4], GUILayout.MinHeight(30f));
        EditorGUI.indentLevel--;

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(gameManager);
        }

        //PrefabUtility.RecordPrefabInstancePropertyModifications(gameManager);
        //serializedObject.ApplyModifiedProperties();


        base.OnInspectorGUI();
    }
}
