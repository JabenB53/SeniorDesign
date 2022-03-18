using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseGame : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) // when the user hits the Tab key
        {
            if(GamePaused) // if the game is paused
            {
                Time.timeScale = 1; // unpause the game
                GamePaused = false;
                pauseMenu.SetActive(false); // hide the pause menu
            }
            else // if the game is not paused
            {
                Time.timeScale = 0; // pause the game
                GamePaused = true;
                pauseMenu.SetActive(true); // display the pause menu
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1; // unpause the game
        GamePaused = false;
        pauseMenu.SetActive(false); // hide the pause menu
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the current level
        Time.timeScale = 1; // unpause the game
        GamePaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // load the Main Menu Scene
        Time.timeScale = 1; // unpause the game
        GamePaused = false;
    }

    public void Quit()
    {
        Application.Quit(); // close the application
    }
}