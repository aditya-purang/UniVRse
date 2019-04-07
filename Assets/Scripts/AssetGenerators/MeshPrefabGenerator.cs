using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="starchart/Asset Generator/Mesh generator")]
public class MeshPrefabGenerator : AssetGenerator
{
    public AssetGenerator MeshGenerator;

    public string prefabName = "mesh prefab";

    public Material material;

    protected override void generateAssets()
    {
        var parentPrefab = new GameObject(prefabName);
        AssetUtility.GetAssetsAtPath<Mesh>(MeshGenerator.FolderPath).ForEach(m => CreateMeshGameObject(m, parentPrefab));
        AssetUtility.SavePrefabAsset(FolderPath, parentPrefab);

    }

    GameObject CreateMeshGameObject(Mesh mesh,GameObject parent)
    {
        var go = new GameObject(mesh.name);
        go.transform.parent = parent.transform;
        go.AddComponent<MeshFilter>().mesh = mesh;
        go.AddComponent<MeshRenderer>().material = material;
        return go;
    }
}
