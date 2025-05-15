using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TelevisionController : MonoBehaviour, IHoverable, IInteractable
{
    [SerializeField] UnityEvent OnTurnOff;

    bool isTriggered = false;
    AudioSource staticAudioSource;
    Canvas staticCanvas;
    Light tvLight;
    Action hoverAction;
    Action unhoverAction;

    void Start()
    {
        staticAudioSource = GetComponent<AudioSource>();
        staticCanvas = GetComponentInChildren<Canvas>();
        tvLight = GetComponentInChildren<Light>();

        var hoverTag = gameObject.GetComponent<HoverTag>();
        hoverAction += hoverTag.Hover;
        unhoverAction += hoverTag.Unhover;

        var hoverOutline = gameObject.GetComponent<HoverOutline>();
        hoverAction += hoverOutline.Hover;
        unhoverAction += hoverOutline.Unhover;

        staticCanvas.gameObject.SetActive(false);
        tvLight.gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        if (isTriggered) return;

        isTriggered = true;

        staticAudioSource.loop = true;
        staticAudioSource.Play();

        staticCanvas.gameObject.SetActive(true);
        tvLight.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        staticAudioSource.Stop();

        staticCanvas.gameObject.SetActive(false);
        tvLight.gameObject.SetActive(false);

        OnTurnOff?.Invoke();
    }

    public void Hover()
    {
        hoverAction?.Invoke();
    }

    public void Unhover()
    {
        unhoverAction?.Invoke();
    }

    public void Interact()
    {
        TurnOff();
    }
}
