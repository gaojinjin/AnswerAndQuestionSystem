using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ObjectBuliderScript))]
public class ObjectBuliderEditor : Editor {
	public override void OnInspectorGUI()
	{
        DrawDefaultInspector();
        ObjectBuliderScript myScript = (ObjectBuliderScript)target;
        if (GUILayout.Button("Bulid object"))
        {
            myScript.BulidObject();
        }
    }

}
