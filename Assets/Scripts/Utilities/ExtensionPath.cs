using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
 
public static class ExtensionPath  
{
    public static void ForEach<T>(this IEnumerable<T> source,System.Action<T> action)
    {
        foreach(var element in source)
        {
            action(element);
        }
    }

    public static IEnumerable<T> SubArray<T>(this IEnumerable<T> source ,int startIndex,int count)
    {
        return source.Skip(startIndex).Take(count);
    }
}
