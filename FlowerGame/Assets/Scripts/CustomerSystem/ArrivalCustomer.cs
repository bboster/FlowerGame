using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - Event method understood through Game Dev Guide

public class ArrivalCustomer : MonoBehaviour
{
    // Values for customer timer / patience
    float timeLeft;
    [SerializeField] float customerTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        CustomerManager.current.whenCustomerArrives += TimerStarts;

        timeLeft = customerTime;
    }

    // Countdown method understood through Single Sapling Games tutorial.
    // Trigger for this can be found within PathwayMovement script.
    private void TimerStarts()
    {
        while(timeLeft > 0f)
        {
            timeLeft -= 1 * Time.deltaTime;

            if(timeLeft < 0f)
            {
                timeLeft = 0;
            }
            Debug.Log(timeLeft);
        }
    }
}
