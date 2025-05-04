using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    IInteractable currentInteractable;
    IInteractable lastInteractable;

    void Start()
    {

    }

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 5f))
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();

            if (currentInteractable != lastInteractable)
            {
                lastInteractable?.UnhoverInteract();
                currentInteractable?.HoverInteract();
                lastInteractable = currentInteractable;
            }

            if (Input.GetMouseButtonDown(0))
                currentInteractable?.ClickInteract();
        }
        else
        {
            if (lastInteractable != null)
            {
                lastInteractable.UnhoverInteract();
                lastInteractable = null;
            }
            currentInteractable = null;
        }
    }
}
