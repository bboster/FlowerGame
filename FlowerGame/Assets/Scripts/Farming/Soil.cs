using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [SerializeField]
    GameObject flowerPrefab;

    [SerializeField]
    Transform growthPoint;

    public Growable currentCrop { get; private set; }

    private void Start()
    {
        Plant();
    }

    public void Plant()
    {
        GameObject obj = Instantiate(flowerPrefab, growthPoint);
        Growable growable = obj.GetComponent<Growable>();

        currentCrop = growable;
        growable.StartGrowth();
    }

    public void Harvest()
    {
        Destroy(currentCrop.gameObject);
    }
}
