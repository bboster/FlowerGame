using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    float followSpeed = 5;

    [SerializeField]
    float baseY = 3;

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
        newPos.y = baseY;

        rb.MovePosition(Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime));
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
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
