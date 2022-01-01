using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private GameObject player; // reference to the player object
    private CharacterMovement playerInfo; // reference to the CharacterMovement Script
    public float distance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // get the player object
        playerInfo = player.GetComponent<CharacterMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && playerInfo.keys > 0)
        {
            playerInfo.keys--; // take one key from the Player
            //transform.Translate(Vector3.forward * distance); // open the door
            Destroy(gameObject);
        }
    }
}
