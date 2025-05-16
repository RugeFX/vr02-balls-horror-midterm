using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public List<AudioClip> FootstepSounds;

    AudioSource audioSource;
    Coroutine audioCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float magnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if (magnitude > 0)
        {
            audioCoroutine ??= StartCoroutine(PlayFootstep());
        }
        else
        {
            if (audioCoroutine != null)
                StopCoroutine(audioCoroutine);

            audioCoroutine = null;
        }
    }

    IEnumerator PlayFootstep()
    {
        yield return new WaitForSeconds(0.5f);

        audioSource.clip = FootstepSounds[Random.Range(0, FootstepSounds.Count)];
        audioSource.Play();

        audioCoroutine = null;
    }
}
