using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssetGenerator), true)]
public class AssetGeneratorEditor : Editor
{

    
     
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AssetGenerator dl = (AssetGenerator)target;

            if (GUILayout.Button("generate assets"))
                dl.generate();
        }
    

}
