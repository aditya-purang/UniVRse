using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

    [CreateAssetMenu(menuName ="starchart/Asset Generator/Constellation Mesh")]
public class constellationMeshGenerator : AssetGenerator
{
    public constellationDBLoader database;


    protected override void generateAssets()
    {
        
            database.constellations.Select(c => createMesh(c.stars, c.name)).ForEach(cm => AssetUtility.saveMeshAssets(FolderPath, cm));
       

    }

    Mesh createMesh(starInfo[] stars, string name)
    {
        var mesh = new Mesh();
        mesh.name = name;

        mesh.vertices = stars.Select(s => s.position).ToArray();

        int[] indices = stars.Select((s, i) => i).ToArray();

        mesh.normals = stars.Select(s => s.velocity).ToArray();

        mesh.SetIndices(indices, MeshTopology.Lines, 0);

        return mesh;

    }


}
