using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrangementTable : MonoBehaviour
{
    public static ArrangementTable Instance;

    [SerializeField]
    InputActionAsset playerInput;

    [SerializeField]
    Camera arrangementCam;

    [Header("Bounds")]
    [SerializeField]
    float upperYBound = 5;

    [SerializeField]
    float lowerYBound = -5;

    [Space]

    [SerializeField]
    float rightXBound = 5;

    [SerializeField]
    float leftXBound = -5;

    [SerializeField]
    float maxRaycastDistance = 30;

    [Header("Mouse Controls")]
    [SerializeField]
    float sensitivity;

    [SerializeField]
    float followSpeed = 5;

    // Flower Selected
    GameObject selectedFlower = null;

    // Mouse Movement
    Vector3 mousePosition;

    private void Awake()
    {
        Instance = this;

        if (playerInput == null)
        {
            Debug.LogError("Player Input Null!");
            return;
        }

        playerInput.FindAction("Select").canceled += OnSelectCancelled;
    }

    private void FixedUpdate()
    {
        MoveSelectedFlower();
    }

    private void MoveSelectedFlower()
    {
        if (selectedFlower == null)
            return;

        selectedFlower.transform.position = Vector3.Lerp(selectedFlower.transform.position, arrangementCam.ScreenToWorldPoint(mousePosition), followSpeed * Time.fixedDeltaTime);
    }

    // Player Input
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        mousePosition = arrangementCam.ScreenToWorldPoint(mousePosition);

        if(!Physics.Raycast(arrangementCam.transform.position, arrangementCam.transform.position - mousePosition, out RaycastHit hit)){
            Debug.Log("No Object Hit");
            return;
        }

        if (!hit.collider.CompareTag("Flower"))
            return;

        selectedFlower = hit.collider.gameObject;
    }

    private void OnSelectCancelled(InputAction.CallbackContext context)
    {
        selectedFlower = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(arrangementCam.transform.position, GetMousePosition());

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(GetMousePosition(), 0.5f);
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
}
