/*
 * Script Written By:
 * Brooke Boster
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Create PlayerInput and it's actions.
    public PlayerInput PlayerInputInstance;
    public InputAction Movement;

    // Rigidbody and physics
    [SerializeField] private Rigidbody rb;

    // Related to movement
    [SerializeField] private bool isMoving;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerInputInstance = GetComponent<PlayerInput>();

        Movement = PlayerInputInstance.currentActionMap.FindAction("Movement");

        Movement.started += Movement_started;
        Movement.canceled += Movement_canceled;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection * playerSpeed, 0.0f, moveDirection * playerSpeed);
        Vector2 direction = Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(direction.x, 0f, direction.y);
    }

    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        isMoving = false;
    }

    private void Movement_started(InputAction.CallbackContext context)
    {
        isMoving = true;
    }


    private void OnDestroy()
    {
        Movement.started -= Movement_started;
        Movement.canceled -= Movement_canceled;
    }
}
