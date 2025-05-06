using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    public GameObject dropObject;
    bool isTriggered = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isTriggered) return;

        Debug.Log("Collider triggered");
        
        if (dropObject.TryGetComponent<Rigidbody>(out var rigidBody))
        {
            Debug.Log($"Got rigidbody of {dropObject.name}");
            // add force to drop the object
            rigidBody.AddForce(Vector3.forward * 10, ForceMode.Impulse);

            isTriggered = true;
        }
    }
}
