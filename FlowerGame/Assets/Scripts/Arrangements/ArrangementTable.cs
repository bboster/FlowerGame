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

    Vector3 rotationOffset = Vector3.zero;

    private void Awake()
    {
        Instance = this;

        if (playerInput == null)
        {
            Debug.LogError("Player Input Null!");
            return;
        }
    }

    private void FixedUpdate()
    {
        ObjectRotation();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(arrangementCam.transform.position, GetMousePosition());

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(GetMousePosition(), 0.2f);
    }

    // Selected Object Functions
    public void RotateSelectedObject(InputAction.CallbackContext context)
    {
        if (selectedObject == null)
            return;

        rotationOffset = context.ReadValue<Vector3>();
    }

    public void ResetRotationSelectedObject()
    {
        if (selectedObject == null)
            return;

        selectedObject.transform.rotation = Quaternion.Euler(selectedObject.GetStartRotation());
    }

    private void ObjectRotation()
    {
        if (selectedObject == null || rotationOffset == Vector3.zero)
            return;

        //Debug.Log("Rotation Vector: " + rotationOffset);
        if (rotationOffset != Vector3.zero)
        {
            float rotateSpeed = selectedObject.GetDragableData().rotationSpeed;

            selectedObject.transform.RotateAround(selectedObject.transform.position, Vector3.up, rotationOffset.x * rotateSpeed);
            selectedObject.transform.RotateAround(selectedObject.transform.position, Vector3.forward, rotationOffset.y * rotateSpeed);
            selectedObject.transform.RotateAround(selectedObject.transform.position, Vector3.right, rotationOffset.z * rotateSpeed);

            /*selectedObject.transform.rotation = Quaternion.Lerp(selectedObject.transform.rotation,
                Quaternion.Euler(transform.rotation.eulerAngles + (selectedObject.GetDragableData().rotationSpeed * rotationOffset)), Time.fixedDeltaTime);*/
        }
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
