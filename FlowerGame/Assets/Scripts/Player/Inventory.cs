using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // A list of items in the player's inventory
    [SerializeField] private List<GameObject> inventoryList;
    // Reference to player controller
    [SerializeField] private PlayerController PC;
    // Possible inventory positions, found under Main Camera
    [SerializeField] private List<Transform> inventoryPositions;
    // The item to be added to the inventory
    public GameObject itemToAdd;
    
    public void AddFlowerToInventory(GameObject gameObject)
    {
        inventoryList.Add(gameObject);
    }

    public void PickFlower()
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
                itemToAdd.transform.position = inventoryPositions[i].position;
                itemToAdd.transform.parent = inventoryPositions[i];
                AddToInventory(itemToAdd);
            }
        }
    }

    public void AddItem(GameObject newItem)
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
                itemToAdd.transform.position = inventoryPositions[i].position;
                itemToAdd.transform.parent = inventoryPositions[i];
            }
        }
    }

    private void AddToInventory(GameObject itemToAdd)
    {
        inventoryList.Add(itemToAdd);
    }

    public List<Transform> GetFlowers()
    {
        return inventoryPositions;
    }

    public void ClearFlowerPositions()
    {
        inventoryPositions.Clear();
    }

    public void ClearInventory()
    {
        foreach(Transform t in inventoryPositions)
        {
            foreach (Transform child in t)
                Destroy(child.gameObject);
        }
    }

}
