using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FlowerDataSO : ScriptableObject
{
    public List<FlowerStatContainer> stats;
}

[System.Serializable]
public class FlowerStatContainer
{
    public string name;

    [Space]

    public FlowerStatSO stat;

    public float statAmount;
}

public enum FlowerStat
{
    LOVE,
    HEALTH,
    GREETING,
    FORTUNE,
    REMEMBRANCE,
    SORROW,
    FILLER
}
