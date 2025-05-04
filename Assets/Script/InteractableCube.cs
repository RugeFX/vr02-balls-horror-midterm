using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCube : MonoBehaviour, IInteractable
{
    Outline outline;
    Material material;
    bool isAlternate = false;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 0f;
    }

    void Update()
    {

    }

    public void HoverInteract()
    {
        outline.OutlineWidth = 5f;
    }

    public void UnhoverInteract()
    {
        outline.OutlineWidth = 0f;
    }

    public void ClickInteract()
    {
        isAlternate = !isAlternate;
        material.color = isAlternate ? Color.white : Color.yellow;
    }
}
