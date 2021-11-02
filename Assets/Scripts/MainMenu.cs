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

    public Button[] levelList; // an array of Buttons

    // Start is called before the first frame update
    void Start()
    {
        levelList = levelSelectMenu.GetComponentsInChildren<Button>();
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

        // only activate levels that they've cleared
        int x = SaveSystem.LoadProgress(); // find out how many level's they've cleared
        foreach (Button item in levelList)
        {
            if (int.Parse(item.GetComponent<Text>().text) > x+1) // if the number on the button is greater than the last level they've gained access to ()
                item.interactable = false; // disable the button
        }

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
