using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableCubeWithTag : MonoBehaviour, IInteractable
{
    Material material;
    bool isAlternate = false;

    void Start()
    {
        gameObject.GetOrAddComponent<OutlineOnHover>();
        gameObject.GetOrAddComponent<ShowTagOnHover>();
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
}
