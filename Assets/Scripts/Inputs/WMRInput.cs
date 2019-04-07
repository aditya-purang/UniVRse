using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WMRInput : MonoBehaviour
{
    public TimeManager timeManager;
    public ScaleManager scaleManager;

    public GameObject starchartInstance;

    public SteamVR_Action_Boolean triggerClick;
    public SteamVR_Action_Boolean gripClick;
    public SteamVR_Action_Boolean touchpadclick;  //not mapped yet

    public SteamVR_Action_Vector2 thumbstickPos;

    public bool b = true;


    /*
     * NOTE 
     * 
     * RIGHT HAND IS FOR SCALE 
     * LEFT HAND IS FOR TIME
     * 
     * */

   

    // Update is called once per frame
    void Update()
    {

        setScale();

        setTime();

        toggleConstellations();

    }


    

    void setTime()
    {
        //reset time
        if (gripClick.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            timeManager.resetTime();
        }

        float thumbstickX = thumbstickPos.GetAxis(SteamVR_Input_Sources.LeftHand).x;
        //change time
        if (Mathf.Abs(thumbstickX)>=0.1f)
        {
            timeManager.changeTime(thumbstickX);
        }


        //toggle auto update
        if (triggerClick.GetStateDown(SteamVR_Input_Sources.LeftHand)){
            timeManager.toggleAutoUpdate();
        }
    }

    void setScale()
    {

        //reset scale
        if (gripClick.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            scaleManager.resetScale();
        }

        float thumbstickX = thumbstickPos.GetAxis(SteamVR_Input_Sources.RightHand).x;
        //change scale
        if (Mathf.Abs(thumbstickX) >= 0.1f)
        {
            scaleManager.changeScale(thumbstickX);
        }
    }

    void toggleConstellations()
    {
        if (touchpadclick.GetStateDown(SteamVR_Input_Sources.Any))
        {
            b = !b;
            starchartInstance.transform.Find("mesh prefab(Clone)").gameObject.SetActive(b);
            starchartInstance.transform.Find("Constellation Overlay Canvas(Clone)(Clone)").gameObject.SetActive(b);
        }
    }
    
}
