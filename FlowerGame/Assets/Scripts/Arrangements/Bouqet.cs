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

        Dragable flowerDragable = other.GetComponent<Dragable>();
        flowerDragable.IsForcedKinematic = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Flower"))
            return;

        other.attachedRigidbody.includeLayers = flowers;

        Dragable flowerDragable = other.GetComponent<Dragable>();
        flowerDragable.IsForcedKinematic = false;
        if(!flowerDragable.IsBeingDragged)
            flowerDragable.EnablePhysics();
    }
}
