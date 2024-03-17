using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DragableDataSO : ScriptableObject
{
    public float dragSpeed = 11;

    public float rotationSpeed = 10;

    public float baseY = 3;

    public bool doReturnGravOnRelease = true;

    public AudioClip Pick, Place;
}
