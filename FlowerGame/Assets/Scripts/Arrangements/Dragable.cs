using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    [SerializeField]
    DragableDataSO dragableData;

    [HideInInspector]
    public bool IsForcedKinematic = false;

    public bool IsBeingDragged { get; private set; } = false;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        IsBeingDragged = true;
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
        IsBeingDragged = false;
        EnablePhysics();
    }

    public void DisablePhysics()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void EnablePhysics()
    {
        if (!dragableData.doReturnGravOnRelease || IsForcedKinematic)
            return;

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
