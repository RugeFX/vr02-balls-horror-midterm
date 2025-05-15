using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoverOutline : MonoBehaviour, IHoverable
{
    Outline outline;
    Coroutine currentCoroutine;

    void Start()
    {
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.white.WithAlpha(0.5f);
        outline.OutlineWidth = 0f;
    }

    public void Hover()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(AnimateOutlineWidth(0f, 5f));
    }

    public void Unhover()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(AnimateOutlineWidth(outline.OutlineWidth, 0f));
    }

    IEnumerator AnimateOutlineWidth(float from, float to)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.2f)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / 0.2f);
            outline.OutlineWidth = Mathf.Lerp(from, to, normalizedTime);
            yield return null;
        }

        outline.OutlineWidth = to;
    }
}
