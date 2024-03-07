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

    [SerializeField] float lowerBound;
    [SerializeField] float upperBound;

    public GameObject Customer;

    private int currentRequest = 0;

    bool doRandom = false;

    public int TotalSpawned;

    // Update is called once per frame
    void Start()
    {
        customerSpawning();
    }
    void customerSpawning()
    {
        if (TotalSpawned != 3)
        {
            TotalSpawned += 1;
            Debug.Log(TotalSpawned);
            GameObject newCustomer = Instantiate(Customer, transform.position, transform.rotation);
            // Keeps new spawns organized underneath the parent object / spawner.
            newCustomer.transform.parent = transform;

            int requestIdx = doRandom ? Random.Range(0, customerRequestStorage.GetCustomerRequests().Count) : currentRequest;

            newCustomer.GetComponent<Customer>().SetRequest(customerRequestStorage.GetCustomerRequests()[requestIdx]);
            currentRequest++;

            if (currentRequest >= predeterminedCap)
            {
                doRandom = true;
            }
            StartCoroutine(DelayedSpawns());
        }
        else if (TotalSpawned == 3)
        {
            StartCoroutine(FullDelay());
        }
    }

    IEnumerator DelayedSpawns()
    {
        yield return new WaitForSeconds(Random.Range(lowerBound, upperBound));
        customerSpawning();
    }

    IEnumerator FullDelay()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("I Work");
        customerSpawning();
    }

}
