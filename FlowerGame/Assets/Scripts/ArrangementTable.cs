using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangementTable : MonoBehaviour
{
    [Header("Bounds")]
    [SerializeField]
    float upperYBound = 5;

    [SerializeField]
    float lowerYBound = -5;

    [Space]

    [SerializeField]
    float rightXBound = 5;

    [SerializeField]
    float leftXBound = -5;

    [Header("Mouse Controls")]
    [SerializeField]
    float sensitivity;


}
