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

        TriggerObjectDrop();
    }

    private void TriggerObjectDrop()
    {
        if (dropObject.TryGetComponent<Rigidbody>(out var rigidBody))
        {
            rigidBody.AddForce(Vector3.forward * 10f + Vector3.up * 1f, ForceMode.Impulse);
            isTriggered = true;
        }
    }
}
