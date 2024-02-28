using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FlowerStatSO : ScriptableObject
{
    public string displayName;

    public FlowerStat stat;

    public Sprite symbol;

    public List<string> adjectives = new();

    public List<string> nouns = new();

    public List<string> verbs = new();
}
