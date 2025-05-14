using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableCubeWithTag : MonoBehaviour, IInteractable, IHoverable
{
    Material material;
    bool isAlternate = false;
    Action hoverAction;
    Action unhoverAction;

    void Start()
    {
        hoverAction += gameObject.GetOrAddComponent<HoverOutline>().Hover;
        unhoverAction += gameObject.GetOrAddComponent<HoverOutline>().Unhover;

        hoverAction += gameObject.GetOrAddComponent<HoverTag>().Hover;
        unhoverAction += gameObject.GetOrAddComponent<HoverTag>().Unhover;

        material = GetComponent<Renderer>().material;
    }

    void Update()
    {

    }

    public void Interact()
    {
        isAlternate = !isAlternate;
        material.color = isAlternate ? Color.white : Color.yellow;
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
