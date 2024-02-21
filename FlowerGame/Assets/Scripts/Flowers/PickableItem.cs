/*
 * Script written by: Brooke Boster
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableItem : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
}
