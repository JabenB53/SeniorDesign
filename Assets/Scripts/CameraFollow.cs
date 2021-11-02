using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character; // the character's position
    public Vector3 offset = new Vector3(0,2,-10); // camera's offset from the character
    //private Vector3 newPosition; // camera's position relative to the character
    //public Vector3 zoomOut = new Vector3(10, 10, -20); //the zoomed out position of the camera


    // Start is called before the first frame update
    void Start()
    {
        if (character == null)
            Debug.Log("No character set for camera");
    }

    // Update is called once per frame
    void Update()
    {
        //newPosition = character.position + offset; // get the position of the character + the offset
        //transform.position = newPosition; // go to the where the character is
        //if (Input.GetKey(KeyCode.M))
            //transform.position = zoomOut;
        //else
            transform.position = character.position + offset;

        //transform.LookAt(character); // camera stays fixed on the character
    }

}