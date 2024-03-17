using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// John Paul Fairbanks - Events manager understood through Game Dev Guide tutorial

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;

    [SerializeField] 
    TMP_Text registerText;

    float currentMoney = 0;

    public Customer currentCustomer;

    public AudioClip Pop;
    private AudioSource source;

    private void Awake()
    {
        Instance = this;

        source = GetComponent<AudioSource>();
    }

    public event Action whenCustomerArrives;

    public void CustomerArrival(Customer customer)
    {
        if(whenCustomerArrives != null)
        {
            whenCustomerArrives();
            source.PlayOneShot(Pop);
        }
    }

    public void SetCustomer(Customer customer)
    {
        string customerName = customer == null ? "null" : customer.name;
        Debug.Log("Setting customer: " + customerName);
        currentCustomer = customer;
    }

    public void AddToRegister(float amt)
    {
        float newMoneyAmt = currentMoney + amt;
        if (newMoneyAmt < 0)
            newMoneyAmt = 0;

        currentMoney = newMoneyAmt;
        var scoreVar = Math.Round(currentMoney, 3);

        registerText.text = "$";
        registerText.text += scoreVar.ToString("F2");
    }
}
