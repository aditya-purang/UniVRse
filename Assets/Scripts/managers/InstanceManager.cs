using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{[HideInInspector]
[SerializeField]
    GameObject Starsinstance;

    [HideInInspector]
    [SerializeField]
    GameObject Constellationsinstance;

    [HideInInspector]
    [SerializeField]
    GameObject constellationOverlayInstance;


    public DatabaseLoader dl;
    public MeshGenerator mg;
    
    public constellationDBLoader cdbl;
    public constellationMeshGenerator cmg;

    public MeshPrefabGenerator Starsmpg;
    public MeshPrefabGenerator Constellationsmpg;

    public MeshConstellationOverlayPrefabGenerator MeshConstellationOverlayPrefabGenerator;

    public void GenerateAndInstatiatePrefab()
    {
        dl.LoadDatabase();
        cdbl.LoadDatabase();

        mg.generate();
        cmg.generate();

        Starsmpg.generate();
        Constellationsmpg.generate();

        MeshConstellationOverlayPrefabGenerator.generate();

        instatiatePrefab();
    }

    public void instatiatePrefab()
    {   if(Starsinstance != null)
        {
            GameObject.DestroyImmediate(Starsinstance);
        }

        if (Constellationsinstance != null)
        {
            GameObject.DestroyImmediate(Constellationsinstance);
        }

        if (constellationOverlayInstance != null)
        {
            GameObject.DestroyImmediate(constellationOverlayInstance);
        }
        var starprefab = AssetUtility.GetAssetsAtPath<GameObject>(Starsmpg.FolderPath)[0];
        Starsinstance = GameObject.Instantiate(starprefab, Vector3.zero, Quaternion.identity, transform);

        var constellationprefab = AssetUtility.GetAssetsAtPath<GameObject>(Constellationsmpg.FolderPath)[0];
        Constellationsinstance = GameObject.Instantiate(constellationprefab, Vector3.zero, Quaternion.identity, transform);

        var constellationOverlayPrefab = AssetUtility.GetAssetsAtPath<GameObject>(MeshConstellationOverlayPrefabGenerator.FolderPath)[0];
        constellationOverlayInstance = GameObject.Instantiate(constellationOverlayPrefab, Vector3.zero, Quaternion.identity, transform);
    }
}
