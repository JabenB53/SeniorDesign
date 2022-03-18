using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHopping : MonoBehaviour
{
    private bool touched = false;

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            try
            {
                int latest = SaveSystem.LoadProgress(); // get the player's latest level
                if (SceneManager.GetActiveScene().buildIndex > latest) // if they hadn't beat this level yet
                    SaveSystem.SaveProgress(SceneManager.GetActiveScene().buildIndex); // save their progress (mark that they've cleared this level)
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1); // load the next level
            }

            catch
            {
                Debug.Log("There is no next level! I lied!");
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            touched = true;
    }
}