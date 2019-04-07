using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TimeManager),true)]
public class settingsEditor : Editor
{
    

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TimeManager tm = (TimeManager)target;
       

        if(GUILayout.Button("Reset Time"))
        {
            tm.resetTime();
        }

       
    }
}
