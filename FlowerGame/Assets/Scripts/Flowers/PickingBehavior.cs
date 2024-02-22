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
    public List<GameObject> flowers;
    public GameObject itemToAdd;

    // The position in game where to put the object;
    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flower4;
    public GameObject flower5;
    public GameObject flower6;
    public GameObject flower7;
    public GameObject flower8;
    public GameObject flower9;
    public GameObject flower10;
    public GameObject flower11;
    public GameObject flower12;
    public GameObject flower13;
    public GameObject flower14;
    public GameObject flower15;

    // Coordinates of where to put the flowers;
    public Vector3 whereToPut1;
    public Vector3 whereToPut2;
    public Vector3 whereToPut3;
    public Vector3 whereToPut4;
    public Vector3 whereToPut5;
    public Vector3 whereToPut6;
    public Vector3 whereToPut7;
    public Vector3 whereToPut8;
    public Vector3 whereToPut9;
    public Vector3 whereToPut10;
    public Vector3 whereToPut11;
    public Vector3 whereToPut12;
    public Vector3 whereToPut13;
    public Vector3 whereToPut14;
    public Vector3 whereToPut15;

    public GameObject Player;

    public Transform where;

    private void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();
        PlayerInputInstance.currentActionMap.Enable();

        PickUp = PlayerInputInstance.currentActionMap.FindAction("PickUp");

        PickUp.started += PickUp_started;
        PickUp.canceled -= Pickup_cancelled;

        inventory.Add(whereToPut1);
        inventory.Add(whereToPut2);
        inventory.Add(whereToPut3);
        inventory.Add(whereToPut4);
        inventory.Add(whereToPut5);
        inventory.Add(whereToPut6);
        inventory.Add(whereToPut7);
        inventory.Add(whereToPut8);
        inventory.Add(whereToPut9);
        inventory.Add(whereToPut10);
        inventory.Add(whereToPut11);
        inventory.Add(whereToPut12);
        inventory.Add(whereToPut13);
        inventory.Add(whereToPut14);
        inventory.Add(whereToPut15);

       
    }
    private void Update()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i] = flowers[i].transform.position;
        }
        whereToPut1 = flower1.transform.position;
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
            itemToAdd.transform.position = inventory[i];
            itemToAdd.transform.parent = where;
        }
    }

    private void OnDestroy()
    {
        PickUp.started -= PickUp_started;
        PickUp.canceled += Pickup_cancelled;
    }
}
