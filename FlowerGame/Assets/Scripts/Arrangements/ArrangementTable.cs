using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrangementTable : MonoBehaviour
{
    public static ArrangementTable Instance;

    [Header("Assignments")]
    [SerializeField]
    InputActionAsset playerInput;

    [Space]

    [SerializeField]
    Bouqet bouqet;

    [Space]

    [SerializeField]
    Camera arrangementCam;

    [SerializeField]
    List<CinemachineVirtualCamera> virtualCameras = new();

    [Space]

    [SerializeField]
    TMP_Text tmpText;

    [Header("Mouse Controls")]
    [SerializeField]
    float sensitivity;

    // Flower Selected
    Dragable selectedObject = null;

    Vector3 rotationOffset = Vector3.zero;

    int currentCam = 0;

    private void Awake()
    {
        Instance = this;

        if (playerInput == null)
        {
            Debug.LogError("Player Input Null!");
            return;
        }

        bouqet.BouqetStatChangeEvent += UpdateUI;

        tmpText.text = "";
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

    // Camera Functions
    public void TransitionCamera()
    {
        currentCam = 1 - currentCam;

        for(int i = 0; i < virtualCameras.Count; i++)
        {
            if (i == currentCam)
                virtualCameras[i].enabled = true;
            else
                virtualCameras[i].enabled = false;
        }
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

    // UI
    private void UpdateUI(object sender, EventArgs e)
    {
        if (tmpText == null)
            return;

        string outputString = "";
        List<FlowerStat> statsToChange = new();

        Dictionary<FlowerStat, float> bouqetStats = bouqet.GetBouqetStats();

        foreach (FlowerStat flowerStat in bouqetStats.Keys)
        {
            if (bouqetStats[flowerStat] == 0)
                continue;
            else if (bouqetStats[flowerStat] < 0)
            {
                statsToChange.Add(flowerStat);
                continue;
            }

            outputString += "" + flowerStat + ": " + bouqetStats[flowerStat] + "\n";
        }

        foreach (FlowerStat stat in statsToChange)
            bouqetStats[stat] = 0;

        tmpText.text = outputString;
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

        rotationOffset = Vector3.zero;
    }

    enum VirtualCamera
    {
        PLAYER_CAM,
        TABLE_CAM
    }

}


