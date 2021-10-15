using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    private GameObject player; // reference to the player object
    private CharacterMovement playerInfo; // reference to the CharacterMovement Script
    private bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // get the player object
        playerInfo = player.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) // wait until the Player touches the slimeball
    {
        if (other.tag == "Player" && !collided) //when it collides with the Player for the first time
        {
            collided = true;
            playerInfo.jumps++;
            Destroy(gameObject);
        }
    }
}
