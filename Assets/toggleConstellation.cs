using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleConstellation : MonoBehaviour
{
    public bool b = false;
    public GameObject starchartInstance;

    // Update is called once per frame
    void Update()
    {
        starchartInstance.transform.Find("mesh prefab(Clone)").gameObject.SetActive(b);
        starchartInstance.transform.Find("Constellation Overlay Canvas(Clone)(Clone)").gameObject.SetActive(b);
    }

    
}
