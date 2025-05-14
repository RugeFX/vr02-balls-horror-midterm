using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoverTag : MonoBehaviour, IHoverable
{
    Canvas tagCanvas;

    void Start()
    {
        tagCanvas = gameObject.GetComponentInChildren<Canvas>();
        Debug.Log(tagCanvas.name);
        tagCanvas.enabled = false;
    }

    public void Hover()
    {
        tagCanvas.enabled = true;
    }

    public void Unhover()
    {
        tagCanvas.enabled = false;
    }
}
