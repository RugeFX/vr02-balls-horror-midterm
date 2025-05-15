using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableCubeWithTag : MonoBehaviour, IInteractable, IHoverable
{
    public string TagText = "A Yellow Cube";
    public string TagTextAlternate = "A White Cube";
    public Color CubeColor;
    public Color CubeColorAlternate;

    bool isAlternate = false;
    HoverTag hoverTag;
    Action hoverAction;
    Action unhoverAction;

    void Start()
    {
        var hoverOutline = gameObject.GetOrAddComponent<HoverOutline>();
        hoverTag = gameObject.GetOrAddComponent<HoverTag>();

        hoverTag.TagText = TagText;

        hoverAction += hoverOutline.Hover;
        unhoverAction += hoverOutline.Unhover;

        hoverAction += hoverTag.Hover;
        unhoverAction += hoverTag.Unhover;
    }

    public void Interact()
    {
        isAlternate = !isAlternate;

        GetComponent<Renderer>().material.color = isAlternate ? CubeColorAlternate : CubeColor;
        hoverTag.TagText = isAlternate ? TagTextAlternate : TagText;
    }

    public void Hover()
    {
        hoverAction?.Invoke();
    }

    public void Unhover()
    {
        unhoverAction?.Invoke();
    }
}
