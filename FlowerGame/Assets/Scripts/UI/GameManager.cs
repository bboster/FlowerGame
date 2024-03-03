using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // There is A LOT of methods here that can be used in multiple scenes.

    // All of the canvases
    [SerializeField] private GameObject HowToPlayCanvas;
    [SerializeField] private GameObject CreditsCanvas;
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject MainMenuCanvas;

    // Strings to allow the name of which scene to load change if we make new scenes. FOUND IN GAMEMANAGER GAMEOBJECT IN THE HIERARCHY
    [SerializeField] private string GameScene;
    [SerializeField] private string MainMenuScene;

    // Loads the how to play scene
   public void LoadHowToPlay()
    {
        // If the credits canvas is active, set it to false.
        if(CreditsCanvas.activeSelf)
        {
            CreditsCanvas.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == GameScene) // If you are in the game scene, set pause canvas to false
        {
            PauseCanvas.SetActive(false);
        }
        // Set how to play to true
        HowToPlayCanvas.SetActive(true);
    }

    // Loads the credits canvas. Does it the same was as HowToPlay()
    public void LoadCreditsCanvas()
    {
        if (HowToPlayCanvas.activeSelf)
        {
            HowToPlayCanvas.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == GameScene)
        {
            PauseCanvas.SetActive(false);
        }
        CreditsCanvas.SetActive(true);
    }

    // Goes back to the previous canvas.
    public void Back()
    {
        // If how to play or credits is active AND you are in the main menu scene, set play and credits to false and main menu to true.
        if((HowToPlayCanvas.activeSelf || CreditsCanvas.activeSelf) && SceneManager.GetActiveScene().name == MainMenuScene)
        {
            HowToPlayCanvas.SetActive(false);
            CreditsCanvas.SetActive(false);
            MainMenuCanvas.SetActive(true);
        }
        else if((HowToPlayCanvas.activeSelf || CreditsCanvas.activeSelf) && SceneManager.GetActiveScene().name == GameScene) // How to play or credits true AND in game scene, set pause canvas to true
        {
            HowToPlayCanvas.SetActive(false);
            CreditsCanvas.SetActive(false);
            PauseCanvas.SetActive(true);
        }
        else if (PauseCanvas.activeSelf) // If the pause canvas is active, go back to the game.
        {
            PauseCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1.0f;
        }
    }

    // Loads the main game scene.
    public void PlayGame()
    {
        SceneManager.LoadScene(GameScene);
    }
}
