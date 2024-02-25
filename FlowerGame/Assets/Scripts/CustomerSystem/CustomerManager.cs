using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - Events manager understood through Game Dev Guide tutorial

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    public Customer currentCustomer { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public event Action whenCustomerArrives;

    public void CustomerArrival(Customer customer)
    {
        if(whenCustomerArrives != null)
        {
            whenCustomerArrives();
        }
    }

    public void SetCustomer(Customer customer)
    {
        currentCustomer = customer;
    }
}
