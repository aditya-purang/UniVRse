using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

[System.Serializable]
public class constellationInfo
{
    public starInfo[] stars;
    public string id;
    public string name;

    public Vector3 NamePosition;



    public constellationInfo(string whiteSpaceText,StarDBLoader starDB)
    {
        var lines = Regex.Split(whiteSpaceText.Trim(), @"\s+").ToArray();
        id = lines[0];



       stars = lines.Skip(2).Select(idStr => int.Parse(idStr)).Select(idint => starDB.getStarsByHipID(idint)).ToArray();



        NamePosition = stars.Select(s => s.position).Aggregate((p, total) => total + p) / stars.Length;
    }


    public override string ToString()
    {
        return string.Format("id: {0}\tname: {1}\tnumber of lines{2}", id, name, stars.Length / 2);
    }


}
