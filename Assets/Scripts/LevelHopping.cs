using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHopping : MonoBehaviour
{
    private bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            try
            {
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
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
