using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName ="starchart/databases/star")]
public class StarDBLoader : DatabaseLoader
{
    public string databasePath;
    [HideInInspector] 
    public starInfo[] stars;

    public override void LoadDatabase()
    {
        string[] lines = IOUtility.OpenLines(databasePath);
        stars = lines.Skip(1).Select(l => new starInfo(l)).ToArray();
    }


    public starInfo getStarsByHipID(int hipID)
    {
        var starInfo = stars.FirstOrDefault(s => s.hipID == hipID);
        if (starInfo == null)
        {
            Debug.LogWarning("no star with id " + hipID + " found");
        }
        return starInfo;
    }
    
}
