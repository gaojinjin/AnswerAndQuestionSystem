using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LevelScript))]
public class LevelScritptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        LevelScript myLevelScript = (LevelScript)target;
        myLevelScript.exp = EditorGUILayout.IntField("Experience", myLevelScript.exp);
        EditorGUILayout.LabelField("Level", myLevelScript.Lev.ToString());

    }
}
