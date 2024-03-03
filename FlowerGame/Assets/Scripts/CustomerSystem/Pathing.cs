using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    // Stores reference to pathing system for our customers
    [SerializeField] public CustomerPathiing2 pathing;

    [SerializeField] private float customSpeed = 5f;

    [SerializeField] private float distanceToNext = 0.1f;

    // Helps in tracking the current position our customer will move to.
    private Transform currentPosition;

    // Timer for customer patience
    int timeLeft;
    [SerializeField] int customerTime = 100;

    // Usage for showing customer mood through change of material color.
    [SerializeField] private Renderer customerVisual;

    [SerializeField]
    Customer customer;

    bool stayOrGo = false;

    // Start is called before the first frame update
    void Start()
    {
        // Starts our customer at first waypoint (helpful in terms of spawning)
        // Prevents future issues with multiple customers on path.
        currentPosition = pathing.GetNextPosition(currentPosition);
        transform.position = currentPosition.position;

        // Setting of next position for customer
        currentPosition = pathing.GetNextPosition(currentPosition);

        // Note: Edit the value for customerTime within INSPECTOR, not code
        timeLeft = customerTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPosition.position, customSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPosition.position) < distanceToNext)
        {
            currentPosition = pathing.GetNextPosition(currentPosition);
            transform.LookAt(currentPosition);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        // This will trigger the countdown of the customer.
        // customerTime for total countdown can be found within Inspector of Customer Gameobject.
        if (other.gameObject.CompareTag("CustomerArrive"))
        {
            if(!stayOrGo)
            {
                customSpeed = 0f;
                Debug.Log("Arrive");
                CustomerManager.Instance.SetCustomer(GetComponent<Customer>());

                //Customer only tells order when they arrive
                gameObject.GetComponent<Customer>().DisplayOrder();
                StartCoroutine(SecondDelay());
                stayOrGo = true;
            }    
            else
            {
                customSpeed = 5f;
            }


        }

        if(other.gameObject.CompareTag("CustomerBack"))
        {
            customSpeed = 0f;
        }

        if(other.gameObject.CompareTag("CustomerGone"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("CustomerBack"))
        {
            customSpeed = 5f;
        }
    }

    public void SubmitBouqet(Bouqet bouqet)
    {
        float score = customer.CompareBouqetToDesired(bouqet);
        //Debug.Log("Score: " + score);
        CustomerManager.Instance.SetCustomer(null);
        StartCoroutine(DelayedLeave());
    }

    IEnumerator DelayedLeave()
    {
        yield return new WaitForSeconds(1f);
        Leave();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void Leave()
    {
        customSpeed = 5;
    }

    // Timer method for customer.
    // Tutorial by SpeedTutor helped in understanding of IEnumerator
    IEnumerator SecondDelay()
    {
        while (timeLeft != 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft -= 1;
            //Debug.Log(timeLeft);

            // Two moods of customer.
            if (timeLeft == customerTime / 2 && timeLeft > customerTime / 4)
            {
                customerVisual.material.color = Color.yellow;
                Debug.Log("Grrr");
            }

            if (timeLeft == customerTime / 4)
            {
                customerVisual.material.color = Color.red;
                Debug.Log("OUT!");
            }
        }
        customSpeed = 5f;

    }
}
