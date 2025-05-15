using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfController : MonoBehaviour
{
    public AudioSource dropAudioSource;

    bool isTriggered = false;

    public void Drop()
    {
        if (isTriggered) return;

        isTriggered = true;
        dropAudioSource.Play();
    }
}
