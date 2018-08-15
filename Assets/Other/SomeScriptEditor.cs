using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor {
	public override void OnInspectorGUI()
	{
        /* SomeScript myScript = (SomeScript)target;
         EditorGUILayout.IntField("Level",myScript.level); 
         EditorGUILayout.FloatField("Health",myScript.health); 
         EditorGUILayout.Vector3Field("Level",myScript.target); */
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This is a help box.",MessageType.Warning);
    }

}
