using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoard : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with Wooden Board");
        UnityEngine.SceneManagement.SceneManager.LoadScene("InternalMap");
    }
}
