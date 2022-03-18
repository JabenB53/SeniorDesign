using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private bool direction = true; // tracks which way the platform should go
    public Vector3 pointA; // the platform's starting spot
    public Vector3 pointB; // the platform's ending spot
    public float speed = 1.0f; // the speed at which the platform should move
    public bool waitForPlayer = false; // should the platform wait for the player?
    public bool firstContact = false; // has the platform touched the player?
    public bool pauses = false; // should the platform pause when it reaches it's end points?
    public float startUpDelay = 1; // how long after the firstContact the platform should start moving
    public float pauseDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (waitForPlayer == false) // if the platform shouldn't wait for the player
            firstContact = true; // start it immediately
    }

    // Update is called once per frame
    void Update()
    {
        if (firstContact == true) // once the platform is started
        {
            if (transform.position == pointA) // if the platform is at pointA
            {
                if (pauses)
                    StartCoroutine(Pause()); // wait a second
                direction = true; // set movement toward pointB
            }

            if (transform.position == pointB) // if the platform is at pointB
            {
                if (pauses)
                    StartCoroutine(Pause());
                direction = false; // set movement toward pointA
            }

            if (direction)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB, (speed * Time.deltaTime)); // move toward point B
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA, (speed * Time.deltaTime)); // move toward point A
            }
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        if (waitForPlayer == true && other.tag == "Player" && firstContact == false ) // once the Player touches the platform
        {
            StartCoroutine(Delay()); // call the delay
        }
            
    }
    IEnumerator Delay() // the delay for when the platform starts
    {
        yield return new WaitForSeconds(startUpDelay); // wait a certain number of seconds
        firstContact = true; // let the platform start
    }

    IEnumerator Pause() // the delay for when the platform starts
    {
        firstContact = false;
        yield return new WaitForSeconds(pauseDelay); // wait a certain number of seconds
        firstContact = true; // let the platform start
    }
}