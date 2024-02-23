using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerController PlayerController { get; private set; }
    public PickingBehavior PlayerPicker { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        PlayerPicker = GetComponent<PickingBehavior>();
    }
}
