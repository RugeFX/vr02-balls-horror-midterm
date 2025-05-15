using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseController : MonoBehaviour
{
    public float FloatHeight = 0.1f;
    public float FloatSpeed = 1f;
    public bool IsFloating = true;

    public AudioSource throwAudioSource;

    Vector3 startPosition;
    Rigidbody rigidBody;
    bool hasThrown = false;

    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (IsFloating)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * FloatSpeed) * FloatHeight;

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rigidBody.velocity.magnitude > 3f && !hasThrown)
        {
            hasThrown = true;
            throwAudioSource.pitch = Random.Range(0.5f, 1.5f);
            throwAudioSource.Play();
        }
    }
}
