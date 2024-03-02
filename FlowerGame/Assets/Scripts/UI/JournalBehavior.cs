using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JournalBehavior : MonoBehaviour
{
    // Get's the input system from Player
    public PlayerInput PlayerInputInstance;
    public InputAction PullUpJournal;

    // Reference to the journal canvas.
    [SerializeField] private GameObject JournalCanvas;

    // All of the pages
    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;
    [SerializeField] private GameObject page3;
    [SerializeField] private GameObject page4;
    [SerializeField] private GameObject page5;
    [SerializeField] private GameObject page6;
    [SerializeField] private GameObject page7;

    // Dictonary to contain pages and page numbers.
    Dictionary<int, GameObject> journalDictionary = new Dictionary<int, GameObject>();

    private GameObject page;


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

        journalDictionary.Add(1, page1);
        journalDictionary.Add(2, page2);
        journalDictionary.Add(3, page3);    
        journalDictionary.Add(4, page4);
        journalDictionary.Add(5, page5);
        journalDictionary.Add(6, page6);
        journalDictionary.Add(7, page7);
    }

    private void PullUpJournal_canceled(InputAction.CallbackContext obj)
    {
        print("No pull up");
    }

    private void PullUpJournal_started(InputAction.CallbackContext obj)
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        JournalCanvas.SetActive(true);
    }

    // Update is called once per frame
    public void FlipForward()
    {

        if(page1.activeSelf)
        {
            page1.SetActive(false);
            page2.SetActive(true);
        }
        else if (page2.activeSelf)
        {
            page2.SetActive(false);
            page3.SetActive(true);
        }
        else if (page3.activeSelf)
        {
            page3.SetActive(false);
            page4.SetActive(true);
        }
        else if (page4.activeSelf)
        {
            page4.SetActive(false);
            page5.SetActive(true);
        }
        else if (page5.activeSelf)
        {
            page5.SetActive(false);
            page6.SetActive(true);
        }
        else if (page6.activeSelf)
        {
            page6.SetActive(false);
            page7.SetActive(true);
        }
        else if (page7.activeSelf)
        {
            page7.SetActive(true);
        }
    }

    public void FlipBackward()
    {
        if (page1.activeSelf)
        {
            page1.SetActive(true);
        }
        else if (page2.activeSelf)
        {
            page2.SetActive(false);
            page1.SetActive(true);
        }
        else if (page3.activeSelf)
        {
            page3.SetActive(false);
            page2.SetActive(true);
        }
        else if (page4.activeSelf)
        {
            page4.SetActive(false);
            page3.SetActive(true);
        }
        else if (page5.activeSelf)
        {
            page5.SetActive(false);
            page4.SetActive(true);
        }
        else if (page6.activeSelf)
        {
            page6.SetActive(false);
            page5.SetActive(true);
        }
        else if (page7.activeSelf)
        {
            page7.SetActive(false);
            page6.SetActive(true);
        }
    }

    public void BackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        JournalCanvas.SetActive(false);
    }
}
