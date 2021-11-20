using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignReader : MonoBehaviour
{
    public string message = ""; // the text that the sign should display
    private GameObject sign; // the sign's display
    public GameObject canvas; // the canvas object

    // Start is called before the first frame update
    void Start()
    {
        sign = GameObject.Find("SignDisplay"); // find the SignDisplay Object (it's in the canvas)
        if (sign != null)
        {
            sign.SetActive(false); // hide the message to start
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && sign != null)
        {
            sign.GetComponentInChildren<TextMeshProUGUI>().text = message; // set the message of the sign to the variable "message"
            sign.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && sign != null)
        {
            sign.SetActive(false);
        }
    }
}
