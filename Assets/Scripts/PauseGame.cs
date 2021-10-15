using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool GamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            }
            else // if the game is not paused
            {
                Time.timeScale = 0; // pause the game
                GamePaused = true;
            }
        }
    }
}
