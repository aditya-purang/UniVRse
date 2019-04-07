using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[ExecuteInEditMode]
public class constellationOverlayText : MonoBehaviour
{
    public Text text;
    public constellationInfo constellationInfo;

    public void setConstellation(constellationInfo _info)
    {
        constellationInfo = _info;
        text.text = constellationInfo.name;
    }

    void Update()
    {
        if (constellationInfo != null)
        {
            UpdateTextPosition();
        }
    }

    void UpdateTextPosition()
    {
        var canvasSize = text.canvas.GetComponent<RectTransform>().sizeDelta;
        Vector3 viewPortPos = Camera.main.WorldToViewportPoint(constellationInfo.NamePosition);
        Vector2 screenPos = viewPortPos * canvasSize;
        text.rectTransform.anchoredPosition = screenPos;
        text.gameObject.SetActive(viewPortPos.z > 0);
    }
}
