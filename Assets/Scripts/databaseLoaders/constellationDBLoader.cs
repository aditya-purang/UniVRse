using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;


[CreateAssetMenu(menuName = "starchart/databases/constellations")]
public class constellationDBLoader : DatabaseLoader
{
    public string folderPath;

    public StarDBLoader starDBL;
    public constellationInfo[] constellations;

    public override void LoadDatabase()
    {

       
        //ForEach(kvp => Debug.Log("id:"+kvp.Key+"\tname:"+kvp.Value));

        var constellationsPath = folderPath + "/constellationship.fab";
        constellations = IOUtility.OpenLines(constellationsPath).Select(l => new constellationInfo(l, starDBL)).ToArray();
        var names = GetNames();
        AssignConstellatioNames(names);

    }

    Dictionary<string, string> GetNames()
    {
        string namesPath = folderPath + "/constellation_names.eng.fab";
        return IOUtility.OpenLines(namesPath).Select(l =>
        {

            string key = Regex.Match(l, @"\w+").ToString();
            string valueDirty = Regex.Match(l, "_[(]\".*?\"[)]").ToString();
            string value = Regex.Replace(valueDirty, "[_\"()]", string.Empty);
            return new KeyValuePair<string, string>(key, value);
        }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    }


    void AssignConstellatioNames(Dictionary<string,string> names)
    {
       
        constellations.ForEach(c =>
        {
            string name;
            names.TryGetValue(c.id, out name);
            c.name = name == null ? "unknown" : name;

        });
    }
}
