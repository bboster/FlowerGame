using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolHolder : MonoBehaviour
{
    [SerializeField]
    GameObject symbolPrefab;

    [SerializeField]
    float sizeScalar = 0.01f;

    [SerializeField]
    List<FlowerStatSO> flowerstatSOs;

    private Dictionary<FlowerStatContainer, GameObject> currentObjects = new();

    public void GenerateSymbols(List<FlowerStatContainer> flowerStatContainers)
    {
        ClearSymbols();

        foreach(FlowerStatContainer container in flowerStatContainers)
        {
            InstantiateSymbol(container);
        }
    }

    public void AddSymbol(FlowerStatContainer container)
    {
        List<FlowerStatContainer> valueList = new(currentObjects.Keys);
        FlowerStatContainer found = valueList.Find(i => i.stat == container.stat);
        if (found != null)
        {
            found.statAmount += container.statAmount;
            currentObjects[found].transform.localScale = Vector3.one * Mathf.Clamp01((container.statAmount * sizeScalar));

            return;
        }

        InstantiateSymbol(container);
    }

    public void AddSymbol(FlowerStat stat, float statAmount)
    {
        List<FlowerStatContainer> valueList = new(currentObjects.Keys);
        FlowerStatContainer found = valueList.Find(i => i.stat.stat == stat);
        if (found != null)
        {
            found.statAmount += statAmount;
            currentObjects[found].transform.localScale = Vector3.one * Mathf.Clamp01((statAmount * sizeScalar));

            return;
        }
        FlowerStatContainer container = GetContainer(stat, statAmount);
        InstantiateSymbol(container);
    }

    public void ClearSymbols()
    {
        foreach (GameObject obj in currentObjects.Values)
            Destroy(obj);

        currentObjects.Clear();
    }

    private void InstantiateSymbol(FlowerStatContainer container)
    {
        GameObject obj = Instantiate(symbolPrefab, transform);
        Image image = obj.GetComponent<Image>();

        image.sprite = container.stat.symbol;
        obj.transform.localScale *= Mathf.Clamp01((container.statAmount * sizeScalar));

        currentObjects.Add(container, obj);
    }

    private FlowerStatContainer GetContainer(FlowerStat stat, float statAmt)
    {
        FlowerStatContainer container = new();

        foreach(FlowerStatSO so in flowerstatSOs)
        {
            if(so.stat == stat)
            {
                container.stat = so;
            }
        }

        container.statAmount = statAmt;

        return container;
    }
}
