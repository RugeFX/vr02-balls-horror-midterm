using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    public GameObject dropObject;
    bool isTriggered = false;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
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
        Transform dropObjectTransform = dropObject.transform;

        if (dropObject.TryGetComponent<Rigidbody>(out var rigidBody))
        {
            rigidBody.AddForceAtPosition((Vector3.forward + Vector3.down) * 50f, dropObjectTransform.position + Vector3.up * dropObjectTransform.localScale.y / 2, ForceMode.Impulse);
            isTriggered = true;
        }
    }
}
