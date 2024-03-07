using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecrementCount : MonoBehaviour
{
    [SerializeField] SpawningCustomer TotalCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CustomerBody"))
        {
            TotalCount.TotalSpawned -= 1;
            Debug.Log(TotalCount.TotalSpawned);
        }

    }
}
