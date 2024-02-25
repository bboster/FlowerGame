using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - spawning understood through tutorials by Kory Code & Unity Ace

public class SpawningCustomer : MonoBehaviour
{
    public GameObject Customer;

    // Update is called once per frame
    void Update()
    {
        customerSpawning();
    }
    void customerSpawning()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject newCustomer = Instantiate(Customer, transform.position, Quaternion.identity);
            // Keeps new spawns organized underneath the parent object / spawner.
            newCustomer.transform.parent = transform;
            Debug.Log("Count");
        }
    }
}
