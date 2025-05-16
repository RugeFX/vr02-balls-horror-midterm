using UnityEngine;

public class PaintingController : MonoBehaviour
{
    public AudioSource dropAudioSource;

    Rigidbody rigidBody;
    bool isTriggered = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
    }

    public void Drop()
    {
        if (isTriggered) return;

        isTriggered = true;
        rigidBody.isKinematic = false;

        rigidBody.AddForce(transform.up * -5f, ForceMode.Impulse);

        dropAudioSource.Play();
    }
}
