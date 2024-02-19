using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    [SerializeField]
    DragableDataSO dragableData;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        DisablePhysics();
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = ArrangementTable.Instance.GetMousePosition();
        newPos.y = dragableData.baseY;

        rb.MovePosition(Vector3.Lerp(transform.position, newPos, dragableData.dragSpeed * Time.deltaTime));
    }

    private void OnMouseUp()
    {
        EnablePhysics();
    }

    private void DisablePhysics()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void EnablePhysics()
    {
        if (!dragableData.doReturnGravOnRelease)
            return;

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
