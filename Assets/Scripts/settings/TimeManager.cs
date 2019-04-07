using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TimeManager : MonoBehaviour
{
    [Range(-1000000,1000000)]
    public float currentYear=2018;

    public float yearsPerSecond = 10000;

    public bool autoUpdate;

    private void OnValidate()
    {
        SetJ2000Offset(currentYear);
    }



    public void resetTime()
    {
        currentYear = 2018;
        autoUpdate = false;
        SetJ2000Offset(currentYear);
    }




    public void changeTime(float changer)
    {
        currentYear += changer * yearsPerSecond * Time.deltaTime;
        SetJ2000Offset(currentYear);
    }



    public void toggleAutoUpdate()
    {
        autoUpdate = !autoUpdate;
    }



    private void Update()
    {
        if (autoUpdate)
        {
            currentYear += yearsPerSecond * Time.deltaTime;
            SetJ2000Offset(currentYear);
        }
    }

    void SetJ2000Offset(float year)
    {
        Shader.SetGlobalFloat("J2000Offset", year - 2000);
    }
}
