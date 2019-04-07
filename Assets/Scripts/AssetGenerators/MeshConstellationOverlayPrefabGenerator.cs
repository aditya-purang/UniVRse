using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="starchart/Asset Generator/Constellation Overlay")]
public class MeshConstellationOverlayPrefabGenerator : AssetGenerator
{
    public GameObject canvasPrefab;

    public GameObject overlayPrefab;

    public constellationDBLoader databaseLoader;

    protected override void generateAssets()
    {
        var canvasInstance = GameObject.Instantiate(canvasPrefab);

        databaseLoader.constellations.ForEach(c => createOverlayInstance(c, canvasInstance.transform));
        AssetUtility.SavePrefabAsset(FolderPath, canvasInstance);

    }

    GameObject createOverlayInstance(constellationInfo constellation,Transform parent)
    {
        var instance = GameObject.Instantiate(overlayPrefab);
        instance.transform.SetParent(parent,false);
        instance.GetComponent<constellationOverlayText>().setConstellation(constellation);
        instance.name = constellation.name;
        return instance;
    }
}
