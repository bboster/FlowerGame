using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PickingBehavior : MonoBehaviour
{
    // Get's the input system from Player
    public PlayerInput PlayerInputInstance;
    public InputAction PickUp;

    // Instance of the player controller
    public PlayerController PC;

    // This list contains all the places you can place a flower. Found under the main camera.
    public List<Transform> flowers;

    // The item to be added to the bouquet, get's updated dynamically
    public GameObject itemToAdd;

    // These are transforms that can be found under the main camera. Must be dragged into inspector.
    public Transform where;
    public Transform where2;
    public Transform where3;
    public Transform where4;
    public Transform where5;
    public Transform where6;
    public Transform where7;
    public Transform where8;
    public Transform where9;
    public Transform where10;
    public Transform where11;
    public Transform where12;
    public Transform where13;
    public Transform where14;
    public Transform where15;

    [Space]
    [Header("Bouqet")]
    [SerializeField]
    Transform bouqetStorage;

    Bouqet bouqet;
    

    private void Start()
    {
        // Get's the player input and enables the current action map.
        PlayerInputInstance = GetComponent<PlayerInput>();
        PlayerInputInstance.currentActionMap.Enable();

        // Finds the PickUp action.
        PickUp = PlayerInputInstance.currentActionMap.FindAction("PickUp");

        // Functions that happen when the pickup button is picked up.
        PickUp.started += PickUp_started;
        PickUp.canceled -= Pickup_cancelled;

        // Adds all of the transforms that are found under the main camera.
        flowers.Add(where);
        flowers.Add(where2);
        flowers.Add(where3);
        flowers.Add(where4);
        flowers.Add(where5);
        flowers.Add(where6);
        flowers.Add(where7);
        flowers.Add(where8);
        flowers.Add(where9);
        flowers.Add(where10);
        flowers.Add(where11);
        flowers.Add(where12);
        flowers.Add(where13);
        flowers.Add(where14);
        flowers.Add(where15);
    }

    private void Pickup_cancelled(InputAction.CallbackContext context)
    {
        print("cancelled");
    }

    private void PickUp_started(InputAction.CallbackContext context)
    {
        PickItem();
    }

    // Picks up flowers.
    private void PickItem()
    {
        int size = PC.flowers.Count;
        for (int i = 0; i < size; i++)
        {
            // If the flowers from PlayerController ISNT EMPTY
            if (PC.flowers[i] != null)
            {
                Growable growable = PC.flowers[i].GetComponent<Growable>();
                if (growable != null)
                    growable.Harvest();

                // Set the item to add, transform it's position to the transform position of the values under main camera, and set the value under the main camera as the flower's parent. 
                itemToAdd = PC.flowers[i];
                itemToAdd.transform.position = flowers[i].position;
                itemToAdd.transform.parent = flowers[i];
            }
        }
    }

    public void AddItem(GameObject newItem)
    {
        int size = PC.flowers.Count;
        for (int i = 0; i < size; i++)
        {
            // If the flowers from PlayerController ISNT EMPTY
            if (PC.flowers[i] != null)
            {
                // Set the item to add, transform it's position to the transform position of the values under main camera, and set the value under the main camera as the flower's parent. 
                itemToAdd = newItem;
                itemToAdd.transform.position = flowers[i].position;
                itemToAdd.transform.parent = flowers[i];
            }
        }
    }

    public List<Transform> GetFlowers()
    {
        return flowers;
    }

    public void ClearFlowers()
    {
        flowers.Clear();
    }

    public void SetBouqet(Bouqet bouqet)
    {
        this.bouqet = bouqet;

        bouqet.GetComponentInParent<Dragable>().SetDraggingEnabled(false);

        bouqet.transform.parent.position = bouqetStorage.position;
        bouqet.transform.parent.parent = bouqetStorage;
    }

    public Bouqet GetBouqet()
    {
        return bouqet;
    }

    // Must have this do not delete, isn't important what it does.
    private void OnDestroy()
    {
        PickUp.started -= PickUp_started;
        PickUp.canceled += Pickup_cancelled;
    }
}
