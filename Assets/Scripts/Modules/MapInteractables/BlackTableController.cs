using UnityEngine;

public class BlackTableController : MonoBehaviour
{
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
        rigidBody.AddForce(transform.up * 1f, ForceMode.Impulse);
        rigidBody.AddForce(transform.forward * 1f, ForceMode.Impulse);

    }
}
