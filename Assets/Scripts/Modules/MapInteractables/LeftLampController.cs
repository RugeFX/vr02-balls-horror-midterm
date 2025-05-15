using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLampController : MonoBehaviour
{
    public AudioSource dropAudioSource;

    Rigidbody rigidBody;
    Light lampLight;
    bool isTriggered = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        lampLight = GetComponentInChildren<Light>();
        rigidBody.isKinematic = false;
    }

    public void Drop()
    {
        if (isTriggered) return;

        rigidBody.AddForce(transform.forward, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(rigidBody.velocity.magnitude);

        if (rigidBody.velocity.magnitude > 3f && !isTriggered)
        {
            dropAudioSource.Play();
            lampLight.enabled = false;
            rigidBody.AddExplosionForce(5f, transform.position, 0f);
            isTriggered = true;
        }
    }
}
