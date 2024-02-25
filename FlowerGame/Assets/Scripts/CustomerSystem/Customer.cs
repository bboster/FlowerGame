using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    List<FlowerStatContainer> desiredStats;

    Dictionary<FlowerStat, float> desiredStatsDict = new();

    private void Awake()
    {
        foreach(FlowerStatContainer statContainer in desiredStats)
        {
            desiredStatsDict[statContainer.stat] = statContainer.statAmount;
        }
    }

    public float CompareBouqetToDesired(Bouqet bouqet)
    {
        float score = 0;

        Dictionary<FlowerStat, float> bouqetStats = bouqet.GetBouqetStats();
        foreach (FlowerStat stat in desiredStatsDict.Keys)
        {
            if (!bouqetStats.ContainsKey(stat))
            {
                score -= 1;
                continue;
            }

            score += Mathf.Clamp01(bouqetStats[stat] / desiredStatsDict[stat]);
        }

        return score;
    }
}
