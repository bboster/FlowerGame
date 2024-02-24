
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    // These can be changed in inspector. The player speed, jump height, and their gravity. (9.81 is NORMAL GRAVITY IN THE REAL WORLD)
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [HideInInspector]
    public PlayerState currentState = PlayerState.MOVING;

    // Get's the input mamager.
    private InputManager inputManager;
    // The transform of the camera.
    private Transform cameraTransform;

    // This collects the gameobject that the player wants to pick up.
    public List<GameObject> flowers;

    // E to pick text
    [SerializeField] private TMP_Text toPick;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;

        // Locks the mouse
        Cursor.lockState = CursorLockMode.Locked;
        toPick.gameObject.SetActive(false);
    }

    void Update()
    {
        if (currentState != PlayerState.MOVING)
            return;

        // Basic player movement with the new input system. This can be found under character controller in the Unity API.
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // If the player collides with a pickable flower, which is a tag on the flower prefab, it adds it to the flower list.
    // Starts a coroutine to show E to pick for 10 seconds.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickableFlower")
        {
            flowers.Add(other.gameObject);
            StartCoroutine(PickingTimer());
        }
    }

    // Coroutine to display the E to pick for 10 seconds. Called in OnTriggerEnter.
    IEnumerator PickingTimer()
    {
        toPick.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        toPick.gameObject.SetActive(false);
    }
}

public enum PlayerState
{
    MOVING,
    ARRANGING
}
