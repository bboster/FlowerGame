using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{

    [SerializeField]
    GameObject growablePrefab;

    [SerializeField]
    Transform growthPoint;

    public Growable currentCrop { get; private set; }

    private void Start()
    {
        Plant(growablePrefab);
    }

    public void Plant(GameObject growablePrefab)
    {
        GameObject obj = Instantiate(growablePrefab, growthPoint);
        Growable growable = obj.GetComponent<Growable>();

        currentCrop = growable;

        growable.HarvestEvent.AddListener(OnHarvest);

        growable.StartGrowth();
    }

    private void OnHarvest()
    {
        Plant(growablePrefab);
    }
}
