using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    FlowerDataSO flowerData;

    public Dragable Dragable { get; private set; }

    private void Awake()
    {
        Dragable = GetComponent<Dragable>();
    }

    public List<FlowerStatContainer> GetFlowerStatsContainer()
    {
        return flowerData.stats;
    }
}
