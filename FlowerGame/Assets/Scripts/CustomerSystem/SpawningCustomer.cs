using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - spawning understood through tutorials by Kory Code & Unity Ace

public class SpawningCustomer : MonoBehaviour
{
    [SerializeField]
    CustomerRequestStorage customerRequestStorage;

    public GameObject Customer;

    private int currentRequest = 0;

    // Update is called once per frame
    void Update()
    {
        customerSpawning();
    }
    void customerSpawning()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject newCustomer = Instantiate(Customer, transform.position, transform.rotation);
            // Keeps new spawns organized underneath the parent object / spawner.
            newCustomer.transform.parent = transform;

            newCustomer.GetComponent<Customer>().SetRequest(customerRequestStorage.GetCustomerRequests()[currentRequest]);
            currentRequest++;

            Debug.Log("Count");
        }
    }
}
