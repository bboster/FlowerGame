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

    public int UniversalCustomerSpawn;

    // Update is called once per frame
    void Start()
    {
        customerSpawning();
    }
    public void customerSpawning()
    {
        Debug.Log(UniversalCustomerSpawn);
        if (UniversalCustomerSpawn != 3)
        {
            GameObject newCustomer = Instantiate(Customer, transform.position, transform.rotation);
            // Keeps new spawns organized underneath the parent object / spawner.
            newCustomer.transform.parent = transform;

            newCustomer.GetComponent<Customer>().SetRequest(customerRequestStorage.GetCustomerRequests()[currentRequest]);
            currentRequest++;

            UniversalCustomerSpawn += 1;
            Debug.Log(UniversalCustomerSpawn);

            StartCoroutine(SecondDelay());
        }
        else if (UniversalCustomerSpawn == 3)
        {
            Debug.Log("I work");
            StartCoroutine(FilledDelay());
        }
    }

    public void CustomerDecrement()
    {
        UniversalCustomerSpawn -= 1;
    }

    // Timer method for customer.
    // Tutorial by SpeedTutor helped in understanding of IEnumerator
    IEnumerator SecondDelay()
    {
        yield return new WaitForSeconds(Random.Range(10f, 11f));
        customerSpawning();
    }

    IEnumerator FilledDelay()
    {
        yield return new WaitForSeconds(10f);
        customerSpawning();
    }

}
