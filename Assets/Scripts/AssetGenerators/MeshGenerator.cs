using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "starchart/Asset Generator/Star Mesh")]
public class MeshGenerator : AssetGenerator
{
    public StarDBLoader database;
    [Range(0,30000)]
    public int starsPerMesh = 10000;

    protected override void generateAssets()
    {
        for(int i = 0; i < database.stars.Length; i += starsPerMesh)
        {
            string name = "stars " + (i / starsPerMesh);
            starInfo[] Substars = database.stars.SubArray(i, starsPerMesh).ToArray();
            var mesh = createMesh(Substars,name);
            AssetUtility.saveMeshAssets(FolderPath, mesh);
        }

        
    }

    Mesh createMesh(starInfo[] stars,string name)
    {
        var mesh = new Mesh();
        mesh.name = name;

        mesh.vertices = stars.Select(s => s.position).ToArray();

        int[] indices = stars.Select((s, i) => i).ToArray();

        //In meshes vector3 : normal,   vector2 : uv , vector4 : tangents
        

        mesh.normals = stars.Select(s => s.velocity).ToArray();

        mesh.tangents = stars.Select(s => new Vector4(s.color.r, s.color.b, s.color.b, s.color.a)).ToArray();

        mesh.uv = stars.Select(s => new Vector2(s.AppMagnitude, s.AbsoluteMagnitude)).ToArray();

        mesh.SetIndices(indices, MeshTopology.Points, 0);

        return mesh;

    }

    
}
