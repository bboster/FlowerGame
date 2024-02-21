using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrangementTable : MonoBehaviour
{
    public static ArrangementTable Instance;

    [Header("Assignments")]
    [SerializeField]
    InputActionAsset playerInput;

    [SerializeField]
    Camera arrangementCam;

    [Header("Mouse Controls")]
    [SerializeField]
    float sensitivity;

    // Flower Selected
    Dragable selectedObject = null;

    private void Awake()
    {
        Instance = this;

        if (playerInput == null)
        {
            Debug.LogError("Player Input Null!");
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(arrangementCam.transform.position, GetMousePosition());

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(GetMousePosition(), 0.3f);
    }

    public void RotateSelectedObject(InputAction.CallbackContext context)
    {
        if (selectedObject == null)
            return;

        Vector3 rotation = context.ReadValue<Vector3>();
        selectedObject.Rotate(rotation);
    }

    // Getters
    public Camera GetArrangementCamera()
    {
        return arrangementCam;
    }

    public Vector3 GetMousePosition()
    {
        Ray ray = arrangementCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
            return new(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);

        return Vector3.one;
    }

    public Dragable GetSelectedObject()
    {
        return selectedObject;
    }

    // Setters
    public void SetSelectedObject(Dragable dragable)
    {
        selectedObject = dragable;
    }

}
