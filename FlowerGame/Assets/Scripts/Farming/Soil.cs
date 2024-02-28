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

    Coroutine timeToPlant = null;

    private void Start()
    {
        Plant(growablePrefab);
    }

    public void Plant(GameObject growablePrefab)
    {
        if (currentCrop != null)
            return;

        GameObject obj = Instantiate(growablePrefab, growthPoint);
        Growable growable = obj.GetComponent<Growable>();

        currentCrop = growable;

        growable.HarvestEvent.AddListener(OnHarvest);
        growable.transform.localScale = Vector3.zero;
        growable.StartGrowth();
    }

    private void OnHarvest()
    {
        //Debug.Log(name + " Harvest");
        currentCrop.HarvestEvent.RemoveAllListeners();

        currentCrop = null;
        if (timeToPlant == null)
            timeToPlant = StartCoroutine(DelayedPlant());
    }

    IEnumerator DelayedPlant()
    {
        yield return new WaitForSeconds(1f);
        Plant(growablePrefab);
        timeToPlant = null;
    }
}
