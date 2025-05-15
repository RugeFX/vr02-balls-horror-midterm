using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public float openedRotation = -90f;
    public float closedRotation = 0f;

    bool isOpen = false;
    Coroutine currentCoroutine;
    readonly AnimationCurve easeCurve = AnimationCurve.EaseInOut(1, 1, 0, 0);
    readonly float animationDuration = 1f;

    public void Interact()
    {
        isOpen = !isOpen;
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(AnimateDoorRotation(transform.localRotation.eulerAngles.y, isOpen ? openedRotation : closedRotation));
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
