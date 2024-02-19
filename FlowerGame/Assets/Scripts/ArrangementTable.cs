using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrangementTable : MonoBehaviour
{
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

    [Header("Mouse Controls")]
    [SerializeField]
    float sensitivity;

    // Flower Selected
    GameObject selectedFlower = null;

    private void Awake()
    {
        if (playerInput == null)
            Debug.LogError("Player Input Null!");
    }

    // Player Input
    public void OnSelect()
    {
        InputAction select = playerInput.FindAction("Select");
        if (select == null)
            return;

        Vector2 mousePos = select.ReadValue<Vector2>();
        Vector3 mouseWorldPos = arrangementCam.ScreenToWorldPoint(mousePos);

        RaycastHit hit = Physics.Raycast();
    }
}
