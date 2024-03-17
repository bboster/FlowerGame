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
    public Inventory inventory;


    // The item to be added to the bouquet, get's updated dynamically
    public GameObject itemToAdd;

    public AudioClip Pick;
    [SerializeField] private AudioSource source;

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
    }

    private void Pickup_cancelled(InputAction.CallbackContext context)
    {
        print("cancelled");
    }

    private void PickUp_started(InputAction.CallbackContext context)
    {
        if (PC.currentState == PlayerState.ARRANGING)
            return;

        // Picks up flowers
        inventory.PickFlower();
        source.PlayOneShot(Pick);
    }
  

    /*public void AddItem(GameObject newItem)
    {
        PC.flowers.Add(newItem);
        int size = PC.flowers.Count;
        for (int i = 0; i < size; i++)
        {
            // If the flowers from PlayerController ISNT EMPTY
            if (PC.flowers[i] != null)
            {
                // Set the item to add, transform it's position to the transform position of the values under main camera, and set the value under the main camera as the flower's parent. 
                itemToAdd = newItem;
                itemToAdd.transform.position = flowerLocations[i].position;
                itemToAdd.transform.parent = flowerLocations[i];
            }
        }
    }*/

    /*public List<Transform> GetFlowers()
    {
        return flowerLocations;
    }

    public void ClearFlowers()
    {
        flowerLocations.Clear();
    }*/

    public void SetBouqet(Bouqet bouqet)
    {
        this.bouqet = bouqet;

        if (bouqet == null)
            return;

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
