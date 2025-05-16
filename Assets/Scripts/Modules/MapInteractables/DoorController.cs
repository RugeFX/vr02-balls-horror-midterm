using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public float OpenedRotation = -90f;
    public float ClosedRotation = 0f;
    public bool IsLocked = false;
    public AudioClip OpenSound;
    public AudioClip CloseSound;

    AudioSource audioSource;
    bool isOpen = false;
    Coroutine currentCoroutine;
    readonly AnimationCurve easeCurve = AnimationCurve.EaseInOut(1, 1, 0, 0);
    readonly float animationDuration = 1f;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(0, ClosedRotation, 0);
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (IsLocked) return;

        isOpen = !isOpen;
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        audioSource.PlayOneShot(isOpen ? OpenSound : CloseSound);
        currentCoroutine = StartCoroutine(AnimateDoorRotation(transform.localRotation.eulerAngles.y, isOpen ? OpenedRotation : ClosedRotation));
    }

    IEnumerator AnimateDoorRotation(float from, float to)
    {
        float time = 0;
        Quaternion startRotation = Quaternion.Euler(0, from, 0);
        Quaternion endRotation = Quaternion.Euler(0, to, 0);

        while (time < animationDuration)
        {
            float normalizedTime = time / animationDuration;
            float easedTime = easeCurve.Evaluate(normalizedTime);
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, easedTime);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation;
    }
}
