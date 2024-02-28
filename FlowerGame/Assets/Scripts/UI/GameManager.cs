using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Get's the input system from Player
    public PlayerInput PlayerInputInstance;
    public InputAction PullUpJournal;

    // Reference to the journal canvas.
    [SerializeField] private GameObject JournalCanvas;


    // Start is called before the first frame update
    void Start()
    {
        // Get's the player input and enables the current action map.
        PlayerInputInstance = GetComponent<PlayerInput>();
        PlayerInputInstance.currentActionMap.Enable();

        // Finds the PickUp action.
        PullUpJournal = PlayerInputInstance.currentActionMap.FindAction("PullUpJournal");

        PullUpJournal.started += PullUpJournal_started;
        PullUpJournal.canceled += PullUpJournal_canceled;
    }

    private void PullUpJournal_canceled(InputAction.CallbackContext obj)
    {
        print("No pull up");
    }

    private void PullUpJournal_started(InputAction.CallbackContext obj)
    {
        Time.timeScale = 0.0f;
        JournalCanvas.SetActive(true);
    }

    public void BackToGame()
    {
        Time.timeScale = 1.0f;
        JournalCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
