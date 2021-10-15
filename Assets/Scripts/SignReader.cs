using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignReader : MonoBehaviour
{
    public string message; // the text that the sign should display

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // make the message appear on the screen
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // delete the message
        }
    }
}
