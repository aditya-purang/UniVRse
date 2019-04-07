using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class AssetUtility  
{
      public static void clearAssetFolder(string FolderPath)
    {
        getAssetPaths(FolderPath).ForEach(ExtensionPath => AssetDatabase.DeleteAsset(ExtensionPath));
        
    }

    public static string[] getAssetPaths(string folderPath)
    {
        return AssetDatabase.FindAssets("", new[] { folderPath }).Select(guid => AssetDatabase.GUIDToAssetPath(guid)).ToArray(); 
    }

    public static void saveMeshAssets(string folderPath,Mesh mesh)
    {
        string assetpath = folderPath + "/" + mesh.name + ".mesh";
        AssetDatabase.CreateAsset(mesh, assetpath);
    }

    public static T[] GetAssetsAtPath<T>(string folderPath) where T:UnityEngine.Object
    {
        return getAssetPaths(folderPath).Select(p => AssetDatabase.LoadAssetAtPath<T>(p)).ToArray();
    }


    public static void SavePrefabAsset(string folderPath,GameObject instance)
    {
        string assetpath = folderPath + "/" + instance.name + ".prefab";
        PrefabUtility.CreatePrefab(assetpath, instance,ReplacePrefabOptions.Default);
        GameObject.DestroyImmediate(instance);
    }
}
