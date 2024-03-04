using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomerRequestStorage : ScriptableObject
{
    [SerializeField]
    List<CustomerRequest> requests;

    public List<CustomerRequest> GetCustomerRequests()
    {
        return requests;
    }
}

[System.Serializable]
public class CustomerRequest
{
    [SerializeField]
    List<FlowerStatContainer> desiredStatsContainer;

    public List<FlowerStatContainer> GetFlowerStatContainers()
    {
        return desiredStatsContainer;
    }
}
