using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableCubeWithTag : MonoBehaviour, IInteractable, IHoverable
{
    public string tagText = "A Yellow Cube";
    public string tagTextAlternate = "A White Cube";
    public Color cubeColor;
    public Color cubeColorAlternate;

    bool isAlternate = false;
    HoverTag hoverTag;
    Action hoverAction;
    Action unhoverAction;

    void Start()
    {
        var hoverOutline = gameObject.GetOrAddComponent<HoverOutline>();
        hoverTag = gameObject.GetOrAddComponent<HoverTag>();

        hoverTag.tagText = tagText;

        hoverAction += hoverOutline.Hover;
        unhoverAction += hoverOutline.Unhover;

        hoverAction += hoverTag.Hover;
        unhoverAction += hoverTag.Unhover;
    }

    public void Interact()
    {
        isAlternate = !isAlternate;

        GetComponent<Renderer>().material.color = isAlternate ? cubeColorAlternate : cubeColor;
        hoverTag.tagText = isAlternate ? tagTextAlternate : tagText;
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
