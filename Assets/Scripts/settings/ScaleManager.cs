using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    const float minScale = 0.0001f;
    const float maxScale = 10;

    [Range(minScale, maxScale)]
    public float scale;

     float scalingUnit;

    private void OnValidate()
    {
        Setscale(scale);
    }

  

    public void resetScale()
    {
        scale = 1;
        Setscale(scale);
    }

    public void changeScale(float scaler)
    {
        scalingUnit = scale / 10;
        float deltascale = scaler * scalingUnit;
        if(scale+deltascale>minScale && scale + deltascale < maxScale)
        {
            scale += deltascale*Time.deltaTime;
        }

        Setscale(scale);
    }

    void Setscale(float Lscale)
    {
        Shader.SetGlobalFloat("scaleOffset", Lscale);
    }
}
