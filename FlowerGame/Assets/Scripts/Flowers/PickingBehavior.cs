using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickingBehavior : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;
    public InputAction PickUp;
    public InputAction PutDown;

    [SerializeField] private Transform slot;
    [SerializeField] private Camera characterCamera;

    private PickableItem pickedItem;

    private void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();
        PlayerInputInstance.currentActionMap.Enable();

        PickUp = PlayerInputInstance.currentActionMap.FindAction("PickUp");

        PickUp.started += PickUp_started;
        PickUp.canceled += PickUp_canceled;
    }


    private void PickUp_canceled(InputAction.CallbackContext obj)
    {
        print("cancelled");
    }

    private void PickUp_started(InputAction.CallbackContext obj)
    {
        if(pickedItem)
        {
            DropItem(pickedItem);
        }
        else
        {
            var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1.5f))
            {
                var pickable = hit.transform.GetComponent<PickableItem>();
                if (pickable)
                {
                    PickItem(pickable);
                }
            }
        }
    }
    
    private void PickItem(PickableItem item)
    {
        pickedItem = item;
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        item.transform.SetParent(slot);

        item.transform.position = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    private void DropItem(PickableItem item)
    {
        pickedItem = null;

        item.transform.SetParent(null);

        item.Rb.isKinematic = false;

        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
    private void OnDestroy()
    {
        PickUp.started -= PickUp_started;
        PickUp.canceled -= PickUp_canceled;
    }
}
