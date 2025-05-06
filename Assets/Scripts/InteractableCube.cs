using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableCube : MonoBehaviour, IInteractable
{
    Material material;
    bool isAlternate = false;

    void Start()
    {
        gameObject.GetOrAddComponent<OutlineOnHover>();
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
