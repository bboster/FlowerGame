using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField]
    Player player;

    private void Awake()
    {
        Instance = this;
    }

    public Player GetPlayer()
    {
        return player;
    }
}
