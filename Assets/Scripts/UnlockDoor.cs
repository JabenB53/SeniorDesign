using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private GameObject player; // reference to the player object
    private CharacterMovement playerInfo; // reference to the CharacterMovement Script
    //public float distance = 1.5f;
    private Rigidbody door;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // get the player object
        playerInfo = player.GetComponent<CharacterMovement>();
        door = this.GetComponent<Rigidbody>();
        door.constraints = RigidbodyConstraints.FreezeAll; // make sure the door doesn't move
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && playerInfo.keys > 0)
        {
            playerInfo.keys--; // take one key from the Player
            door.constraints = RigidbodyConstraints.None; // allow the door to move
            this.transform.Rotate(Vector3.forward, -80); //maybe?
            //Destroy(gameObject);
        }
    }
}
