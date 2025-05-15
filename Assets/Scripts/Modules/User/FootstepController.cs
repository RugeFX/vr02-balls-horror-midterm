using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public List<AudioClip> footstepSounds;

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
            Debug.Log("PlayFootstep");
            audioCoroutine ??= StartCoroutine(PlayFootstep());
        }
        else
        {
            Debug.Log("StopFootstep");
            if (audioCoroutine != null)
                StopCoroutine(audioCoroutine);

            audioCoroutine = null;
        }
    }

    IEnumerator PlayFootstep()
    {
        yield return new WaitForSeconds(0.5f);

        audioSource.clip = footstepSounds[Random.Range(0, footstepSounds.Count)];
        audioSource.Play();

        audioCoroutine = null;
    }
}
