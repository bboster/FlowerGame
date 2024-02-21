using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    FlowerDataSO flowerData;

    public List<FlowerStatContainer> GetFlowerStatsContainer()
    {
        return flowerData.stats;
    }
}
