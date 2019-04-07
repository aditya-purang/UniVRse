using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class starInfo 
{
    public int hygID;
    public int hipID;
    public string ProperName;

    public Vector3 position;
    public Vector3 velocity;


    public float AppMagnitude;
    public float AbsoluteMagnitude;

    public float colourIndex;
    public Color color;



    public starInfo(string infoString)
    {
        var lines = infoString.Split(',');
       
        hygID = ParseUtility.SafeParseInt(lines[0]);
        hipID = ParseUtility.SafeParseInt(lines[1]);
        ProperName = lines[6];

        colourIndex = ParseUtility.SafeParseFloat(lines[16]);
        color = colourUtility.colourIndexToRGB(colourIndex);


        AppMagnitude = ParseUtility.SafeParseFloat(lines[13]);
        AbsoluteMagnitude = ParseUtility.SafeParseFloat(lines[14]);

        position = new Vector3(
                             ParseUtility.SafeParseFloat(lines[17]),
                             ParseUtility.SafeParseFloat(lines[18]),
                             ParseUtility.SafeParseFloat(lines[19]));

        position = Vector3.ClampMagnitude(position, 1000);

        velocity = new Vector3(
                             ParseUtility.SafeParseFloat(lines[20]),
                             ParseUtility.SafeParseFloat(lines[21]),
                             ParseUtility.SafeParseFloat(lines[22]));

    }
}
