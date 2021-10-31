using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public Button startGameButton;
    public Button levelSelectButton;
    public Button quitGameButton;

    public GameObject levelSelectMenu;
    public Button returnToMainButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true); // make sure the main menu is visible
        levelSelectMenu.SetActive(false); // hide the level select menu

        startGameButton.GetComponent<Button>().onClick.AddListener(StartTheGame); // when the "Start Game" button is pressed
        levelSelectButton.GetComponent<Button>().onClick.AddListener(GoToLevelSelect); // when the "Level Select" button is pressed
        quitGameButton.GetComponent<Button>().onClick.AddListener(QuitTheGame); // when the "Start Game" button is pressed

        returnToMainButton.GetComponent<Button>().onClick.AddListener(ReturnToMain); // when the "Return" button is pressed
    }


    void StartTheGame()
    {
        SceneManager.LoadScene(1); // Load the first level
    }

    void GoToLevelSelect()
    {
        mainMenu.SetActive(false); // deactivate and hide the main menu
        levelSelectMenu.SetActive(true); // activate and show the level select menu
    }

    void QuitTheGame()
    {
        Application.Quit(); // Quit the Game
    }

    public void LevelSelect(string levelName) // this is added to each button as an OnClickEvent
    {
        SceneManager.LoadScene(levelName); // load a different level depending on which button is pressed
    }

    void ReturnToMain()
    {
        mainMenu.SetActive(true); // activate the main menu again
        levelSelectMenu.SetActive(false); // deactivate and hide the level select menu
    }

}
