using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - spawning understood through tutorials by Kory Code & Unity Ace

public class SpawningCustomer : MonoBehaviour
{
    [SerializeField]
    CustomerRequestStorage customerRequestStorage;

    [SerializeField]
    int predeterminedCap = 9;

    public GameObject Customer;

    private int currentRequest = 0;

    bool doRandom = false;

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

            int requestIdx = doRandom ? Random.Range(0, customerRequestStorage.GetCustomerRequests().Count) : currentRequest;

            newCustomer.GetComponent<Customer>().SetRequest(customerRequestStorage.GetCustomerRequests()[requestIdx]);
            currentRequest++;

            if (currentRequest >= predeterminedCap)
                doRandom = true;
        }
    }
}
