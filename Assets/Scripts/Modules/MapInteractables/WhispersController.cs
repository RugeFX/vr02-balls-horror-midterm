using UnityEngine;

public class WhispersController : MonoBehaviour
{
    bool isTriggered = false;

    public void Trigger()
    {
        if (isTriggered) return;

        isTriggered = true;
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
