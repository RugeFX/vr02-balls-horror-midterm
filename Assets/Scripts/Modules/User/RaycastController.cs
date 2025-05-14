using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public float rayDistance = 5f;
    IInteractable interactable;
    IHoverable currentHoverable;
    IHoverable lastHoverable;

    void Start()
    {

    }

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, rayDistance))
        {
            interactable = hit.collider.GetComponent<IInteractable>();
            currentHoverable = hit.collider.GetComponent<IHoverable>();

            if (currentHoverable != lastHoverable)
            {
                lastHoverable?.Unhover();
                currentHoverable?.Hover();

                lastHoverable = currentHoverable;
            }

            if (Input.GetMouseButtonDown(0))
                interactable?.Interact();
        }
        else
        {
            if (lastHoverable != null)
            {
                lastHoverable.Unhover();
                lastHoverable = null;
            }

            currentHoverable = null;
        }
    }
}
