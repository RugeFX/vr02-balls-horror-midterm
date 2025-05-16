using System.Collections;
using TMPro;
using UnityEngine;

public class HoverTag : MonoBehaviour, IHoverable
{
    public string TagText = "Text";
    CanvasGroup tagCanvasGroup;
    Coroutine currentCoroutine;

    void Start()
    {
        tagCanvasGroup = gameObject.GetComponentInChildren<CanvasGroup>();
        tagCanvasGroup.alpha = 0f;
    }

    void Update()
    {
        tagCanvasGroup.GetComponentInChildren<TextMeshProUGUI>().text = TagText;
    }

    void LateUpdate()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;

        tagCanvasGroup.transform.LookAt(transform.position + cameraRotation * Vector3.back,
            cameraRotation * Vector3.up);
    }

    public void Hover()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(AnimateTagOpacity(0f, 1f));
    }

    public void Unhover()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(AnimateTagOpacity(1f, 0f));
    }

    IEnumerator AnimateTagOpacity(float from, float to)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 0.2f)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / 0.2f);
            tagCanvasGroup.alpha = Mathf.Lerp(from, to, normalizedTime);
            yield return null;
        }

        tagCanvasGroup.alpha = to;
    }
}
