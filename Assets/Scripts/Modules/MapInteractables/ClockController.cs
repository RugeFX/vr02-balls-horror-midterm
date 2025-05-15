using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public AudioSource dingDongAudioSource;

    bool isTriggered = false;

    public void PlayDingDong()
    {
        if (isTriggered) return;

        Debug.Log("PlayDingDong");
        isTriggered = true;
        dingDongAudioSource.Play();
    }
}
