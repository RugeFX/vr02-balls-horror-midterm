using UnityEngine;

public class VasesController : MonoBehaviour
{
    public float ExplosionForce = 4f;

    GameObject[] vases;
    bool hasExploded = false;

    void Start()
    {
        vases = GameObject.FindGameObjectsWithTag("Vase");
    }

    public void ExplodeVases()
    {
        if (hasExploded) return;

        hasExploded = true;

        foreach (var vase in vases)
        {
            var vaseController = vase.GetComponent<VaseController>();
            var rb = vase.GetComponent<Rigidbody>();
            vaseController.IsFloating = false;

            if (rb == null) continue;

            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce((Random.insideUnitSphere + transform.forward) * ExplosionForce, ForceMode.Impulse);
        }
    }
}

