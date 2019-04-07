using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public TimeManager tm;
    public ScaleManager sm;

    public Canvas canvas;
    public Text scale;
    public Text time;
    public Text scaleUnit;
    public Text timeUnit;


    private void Update()
    {
        scale.text = "Scale: " + sm.scale;
        time.text = "Current Year: " + tm.currentYear;
        timeUnit.text = "1 sec. : " + tm.yearsPerSecond +" years";
        scaleUnit.text = "1 mt. : " + 1 / sm.scale + " parsecs";
    }

}
