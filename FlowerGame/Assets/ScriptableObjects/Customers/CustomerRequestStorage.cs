using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomerRequestStorage : ScriptableObject
{
    [SerializeField]
    List<CustomerRequest> requests;
}

[System.Serializable]
public class CustomerRequest
{
    [SerializeField]
    List<FlowerStatContainer> desiredStatsContainer;
}
