using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouqet : MonoBehaviour
{
    [SerializeField]
    LayerMask flowers;

    [SerializeField]
    LayerMask nothing;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Flower"))
            return;

        other.attachedRigidbody.includeLayers = nothing;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Flower"))
            return;

        other.attachedRigidbody.includeLayers = flowers;
    }
}
