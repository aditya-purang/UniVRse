using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(InstanceManager), true)]
public class InstanceManagerEditor : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        InstanceManager im = (InstanceManager)target;


        if (GUILayout.Button("generate and instatiate "))
            im.GenerateAndInstatiatePrefab();

        if (GUILayout.Button("instantiate prefab"))
            im.instatiatePrefab();
    }

}
