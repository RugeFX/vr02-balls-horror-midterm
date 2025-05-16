using UnityEngine;

public class TriggersManager : MonoBehaviour
{
    void Start()
    {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (var renderer in renderers)
            renderer.enabled = false;

    }
}
