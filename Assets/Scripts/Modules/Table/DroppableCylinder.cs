using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableCylinder : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rigidBody;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (rigidBody.velocity.magnitude > 1f)
        {
            audioSource.Play();
            rigidBody.AddExplosionForce(10f, transform.position, 0f);
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
