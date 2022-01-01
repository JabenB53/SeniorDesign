using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character; // the character's position
    public Vector3 offset = new Vector3(0,2,-10); // camera's offset from the character

    // Start is called before the first frame update
    void Start()
    {
        if (character == null)
            Debug.Log("No character set for camera");
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = character.position + offset;
    }

}
