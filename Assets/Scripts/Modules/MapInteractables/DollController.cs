using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DollController : MonoBehaviour
{
    public AudioSource throwAudioSource;

    Rigidbody rigidBody;
    bool isTriggered = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
    }

    public void Throw()
    {
        if (isTriggered) return;

        isTriggered = true;
        rigidBody.isKinematic = false;

        rigidBody.AddForce(transform.forward * 5f, ForceMode.Impulse);
        rigidBody.AddTorque(transform.right * 10, ForceMode.Impulse);

        throwAudioSource.Play();
    }
}
