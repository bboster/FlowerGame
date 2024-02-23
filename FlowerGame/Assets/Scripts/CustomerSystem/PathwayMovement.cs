using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - Pathway / Waypoint system understood through tutorial by MetalStrom Games

public class PathwayMovement : MonoBehaviour
{
    // Stores reference to pathing system for our customers
    [SerializeField] private CustomerPathing pathing;

    [SerializeField] private float customSpeed = 5f;

    [SerializeField] private float distanceToNext = 0.1f;

    // Helps in tracking the current position our customer will move to.
    private Transform currentPosition;


    // Start is called before the first frame update
    void Start()
    {
        // Starts our customer at first waypoint (helpful in terms of spawning)
        // Prevents future issues with multiple customers on path.
        currentPosition = pathing.GetNextPosition(currentPosition);
        transform.position = currentPosition.position;

        // Setting of next position for customer
        currentPosition = pathing.GetNextPosition(currentPosition);

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
        if(other.gameObject.CompareTag("CustomerArrive"))
        {
            customSpeed = 0f;
            Debug.Log("Arrive");
        }
    }
}
