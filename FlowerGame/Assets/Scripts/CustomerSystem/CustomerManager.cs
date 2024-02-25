using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// John Paul Fairbanks - Events manager understood through Game Dev Guide tutorial

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action whenCustomerArrives;
    public void CustomerArrival()
    {
        if(whenCustomerArrives != null)
        {
            whenCustomerArrives();
        }
    }
}
