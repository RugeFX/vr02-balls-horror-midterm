using UnityEngine;

public class KeyController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with Key");
    }
}
