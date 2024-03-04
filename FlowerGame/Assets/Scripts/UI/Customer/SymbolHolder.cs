using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolHolder : MonoBehaviour
{
    [SerializeField]
    GameObject symbolPrefab;

    [SerializeField]
    float sizeScalar = 0.1f;

    public void GenerateSymbols(List<FlowerStatContainer> flowerStatContainers)
    {
        Debug.Log("Generating Symbols");
        foreach(FlowerStatContainer container in flowerStatContainers)
        {
            Debug.Log(container.name);
            GameObject obj = Instantiate(symbolPrefab, transform);
            Image image = obj.GetComponent<Image>();

            image.sprite = container.stat.symbol;
            obj.transform.localScale *= Mathf.Clamp01(container.statAmount * sizeScalar);
        }
    }
}
