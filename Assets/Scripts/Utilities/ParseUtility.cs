using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParseUtility 
{
    public static int SafeParseInt(string str)
    {
        return str == "" ? 0 : int.Parse(str);
    }

    public static float SafeParseFloat(string str)
    {
        return str == "" ? 0.0f : float.Parse(str);
    }
}
