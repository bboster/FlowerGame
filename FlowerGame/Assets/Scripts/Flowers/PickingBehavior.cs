using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PickingBehavior : MonoBehaviour
{


    public PlayerInput PlayerInputInstance;
    public InputAction PickUp;

    public PlayerController PC;

    public List<Vector3> inventory;
    public GameObject itemToAdd;
    public GameObject thing;
    public Vector3 whereToPut;
    public GameObject Player;
    public Transform where;

    private void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();
        PlayerInputInstance.currentActionMap.Enable();

        PickUp = PlayerInputInstance.currentActionMap.FindAction("PickUp");

        PickUp.started += PickUp_started;
        PickUp.canceled -= Pickup_cancelled;

        inventory.Add(new Vector3(0.8255777f, 0.4400001f, 1.63f));
    }
    private void Update()
    {
        whereToPut = thing.transform.position;
    }

    private void Pickup_cancelled(InputAction.CallbackContext context)
    {
        print("cancelled");
    }

    private void PickUp_started(InputAction.CallbackContext context)
    {
        PickItem();
    }

    private void PickItem()
    {
        int size = PC.flowers.Count;
        for (int i = 0; i < size; i++)
        {
            if (PC.flowers[i] != null)
            {
                itemToAdd = PC.flowers[i];
            }
        }
        for (int i = 0; i < inventory.Count; i++)
        {
            itemToAdd.transform.position = whereToPut;
            itemToAdd.transform.parent = where;
        }
    }

    private void OnDestroy()
    {
        PickUp.started -= PickUp_started;
        PickUp.canceled += Pickup_cancelled;
    }
}
