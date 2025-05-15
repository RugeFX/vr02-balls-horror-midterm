using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoorsController : MonoBehaviour
{
    public string TagText = "Locked Doors";
    DoorController[] doors;

    void Start()
    {
        doors = gameObject.GetComponentsInChildren<DoorController>();
        foreach (var door in doors)
        {
            door.IsLocked = true;
        }

        gameObject.GetComponent<HoverTag>().TagText = TagText;
    }

    public void OpenDoors()
    {
        Debug.Log("Opening doors");

        gameObject.GetComponent<HoverTag>().TagText = "";

        foreach (var door in doors)
        {
            door.IsLocked = false;
            door.Interact();
        }
    }
}
