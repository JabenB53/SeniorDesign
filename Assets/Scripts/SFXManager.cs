using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private CharacterMovement playerInfo;
    public AudioSource jump1;
    public AudioSource jump2;
    public AudioSource jump3;
    private bool slurpReady = true;
    public AudioSource slurp1;
    public AudioSource slurp2;
    public AudioSource slurp3;
    public AudioSource slurp4;
    private bool keyReady = true;
    public AudioSource keyNoise;
    private bool doorReady = false;
    public AudioSource doorNoise;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = this.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playerInfo.touchingLadder) // if the user presses the Space key and isn't on a ladder
        {
            if (playerInfo.jumps > 0) // if the player has jumps left to use
            {
                int num = Random.Range(1, 3); // pick a number between 1 and 3
                switch (num) // play one of the four jump SFX
                {
                    case 1:
                        jump1.Play();
                        break;
                    case 2:
                        jump2.Play();
                        break;
                    case 3:
                        jump3.Play();
                        break;
                    default:
                        break;
                }
            }
        }
        if (playerInfo.keys > 0)
            doorReady = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "buff" && slurpReady) // when the player touches a slimeball 
        {
            slurpReady = false;
            int num = Random.Range(1, 4); // pick a number between 1 and 4
            switch (num) // play one of the four slurp SFX
            {
                case 1:
                    slurp1.Play();
                    break;
                case 2:
                    slurp2.Play();
                    break;
                case 3:
                    slurp3.Play();
                    break;
                case 4:
                    slurp4.Play();
                    break;
                default:
                    break;
            }
            slurpReady = true;
        }

        if (other.tag == "Key" && keyReady) // when the player touches a key
        {
            keyReady = false;
            keyNoise.Play(); // play the key noise
        }

        if (other.tag == "door" && doorReady) // when the player touches a door and has a key
        {
            doorReady = false;
            doorNoise.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "buff")
        {
            slurpReady = true;
        }
        if (other.tag == "Key")
        {
            keyReady = true;
        }
    }
}