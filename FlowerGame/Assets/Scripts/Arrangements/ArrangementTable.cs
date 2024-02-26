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
    GameObject bouqetPrefab;

    [SerializeField]
    Transform bouqetSpawnPosition;

    [SerializeField]
    Transform flowerSpawnPosition;

    [Space]

    [SerializeField]
    Camera arrangementCam;

    [SerializeField]
    List<CinemachineVirtualCamera> virtualCameras = new();

    [Space]

    [SerializeField]
    ArrangementCanvas arrangementCanvas;

    [SerializeField]
    TMP_Text bodyText;

    [Header("Mouse Controls")]
    [SerializeField]
    float sensitivity;

    Bouqet bouqet;

    List<Dragable> currentFlowers = new();

    // Flower Selected
    Dragable selectedObject = null;

    Vector3 rotationOffset = Vector3.zero;

    int currentCam = 0;

    bool isBeingArranged = false;

    bool isOnCooldown = false;

    private void Awake()
    {
        Instance = this;

        if (playerInput == null)
        {
            Debug.LogError("Player Input Null!");
            return;
        }

        arrangementCanvas.SetStatsText("");

        arrangementCanvas.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        ObjectRotation();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (arrangementCam == null)
            return;
        Gizmos.DrawLine(arrangementCam.transform.position, GetMousePosition());

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(GetMousePosition(), 0.2f);
    }

    public void ToggleArrangementView()
    {
        TransitionCamera();
        if(bouqet == null)
        {
            GameObject temp = Instantiate(bouqetPrefab, bouqetSpawnPosition.position, Quaternion.identity);
            bouqet = temp.GetComponentInChildren<Bouqet>();

            bouqet.SetBodyText(bodyText);
            bouqet.BouqetStatChangeEvent += UpdateUI;
        }
        else
        {
            
        }

        if (isBeingArranged)
            EmptyPlayerInventory();
        else
        {
            PlayerManager.Instance.GetPlayer().PlayerPicker.SetBouqet(GetBouqet());

            ResetBouqet();

            FillPlayerInventory();
        }    

        StartCoroutine(ResetCooldown());
    }

    // Camera Functions
    public void TransitionCamera()
    {
        if (isOnCooldown)
            return;

        currentCam = 1 - currentCam;
        isBeingArranged = !isBeingArranged;

        for(int i = 0; i < virtualCameras.Count; i++)
        {
            if (i == currentCam)
                virtualCameras[i].enabled = true;
            else
                virtualCameras[i].enabled = false;
        }

        CursorLockMode cursorMode = isBeingArranged ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isBeingArranged;

        Cursor.lockState = cursorMode;
        arrangementCanvas.gameObject.SetActive(isBeingArranged);

        PlayerState playerState = isBeingArranged ? PlayerState.ARRANGING : PlayerState.MOVING;
        PlayerManager.Instance.GetPlayer().PlayerController.currentState = playerState;

        
    }

    private IEnumerator ResetCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(0.2f);
        isOnCooldown = false;
    }

    private void FillPlayerInventory()
    {
        PickingBehavior picker = PlayerManager.Instance.GetPlayer().PlayerPicker;

        foreach (Dragable d in currentFlowers)
        {
            GameObject obj = Instantiate(d.GetComponent<Flower>().GetGrowablePrefab());

            picker.AddItem(obj);

            Destroy(d.gameObject);
        }

        currentFlowers.Clear();
    }

    private void EmptyPlayerInventory()
    {
        PickingBehavior picker = PlayerManager.Instance.GetPlayer().PlayerPicker;
        PlayerController playerController = PlayerManager.Instance.GetPlayer().PlayerController;

        foreach (Transform t in picker.GetFlowers())
        {
            if (t.childCount <= 0)
                continue;

            Transform tChild = t.GetChild(0);

            Growable growable = tChild.GetComponent<Growable>();

            GameObject obj = Instantiate(growable.GetDraggablePrefab(), flowerSpawnPosition.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

            currentFlowers.Add(obj.GetComponent<Dragable>());

            Destroy(tChild.gameObject);
        }

        playerController.flowers.Clear();
    }

    // Selected Object Functions
    public void RotateSelectedObject(InputAction.CallbackContext context)
    {
        if (selectedObject == null || !selectedObject.IsDraggingEnabled())
            return;

        rotationOffset = context.ReadValue<Vector3>();
    }

    public void ResetRotationSelectedObject()
    {
        if (selectedObject == null || !selectedObject.IsDraggingEnabled())
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

        arrangementCanvas.SetStatsText(outputString);
    }

    public void LockBouqet()
    {
        bouqet.LockFlowers();
    }

    public void UnlockBouqet()
    {
        bouqet.UnlockFlowers();
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

    public Bouqet GetBouqet()
    {
        return bouqet;
    }

    public void ResetBouqet()
    {
        if (bouqet == null)
            return;

        foreach(Flower flower in bouqet.GetFlowers())
        {
            Dragable dragable = flower.Dragable;

            if (currentFlowers.Contains(dragable))
                currentFlowers.Remove(dragable);
        }

        bouqet.BouqetStatChangeEvent -= UpdateUI;
        bouqet = null;
    }

    enum VirtualCamera
    {
        PLAYER_CAM,
        TABLE_CAM
    }

}


