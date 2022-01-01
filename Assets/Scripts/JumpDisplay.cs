using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpDisplay : MonoBehaviour
{
    private GameObject player; // reference to the player object
    public TMP_Text jumpText; // reference to the jump text
    private CharacterMovement playerInfo; // reference to the CharacterMovement Script

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // get the player object
        playerInfo = player.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpText.text = "Jumps: " + playerInfo.jumps.ToString();
    }
}
