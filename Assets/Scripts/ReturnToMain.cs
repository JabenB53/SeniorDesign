using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0); // load the Main Menu Scene
    }    
}
