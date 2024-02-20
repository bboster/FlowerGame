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

    private Vector3 offset = Vector3.zero;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(IsForcedKinematic && !IsBeingDragged && transform.parent != null)
            transform.position = transform.parent.position - offset;
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

        if(transform.parent != null)
            offset = transform.parent.position - transform.position;

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

    public void SetParent(Transform parent)
    {
        transform.parent = parent;

        if(transform.parent == null)
        {
            IsForcedKinematic = false;

            return;
        }

        IsForcedKinematic = true;
    }
}
