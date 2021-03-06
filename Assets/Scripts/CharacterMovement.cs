using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    private float XInput; // input for horizontal movement
    public float speed = 7.0f; // the speed at which the character can move
    public float jumpForce = 8.0f; // the force to be applied for a jump
    public int jumps = 3; // the number of times that the character can jump
    Rigidbody body; // physics component
    public bool touchingLadder = false; // set if the player is touching a ladder
    public int keys = 0;
    public bool dead = false;
    private bool counterFallingForce = true; // tracks if the player's falling force has been countered

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame (FIXED UPDATE WILL KEEP IT IN TIME WITH THE PHYSICS ENGINE)
    void Update()
    {
        XInput = Input.GetAxis("Horizontal"); // get input from the user (left or right)

        if (Input.GetKeyDown(KeyCode.Space) && !touchingLadder) // if the user presses the Space key and isn't on a ladder
        {
            if (jumps > 0) // if the player has jumps left to use
            {
                if (body.velocity.y >= 0) // if the character is moving up or staying level
                    body.AddForce((Vector3.up * jumpForce - (Vector3.up * body.velocity.y)), ForceMode.Impulse); // apply an upward force to the character (cancel the momentum from previous jumps)
                else // if the character is falling
                    body.AddForce((Vector3.up * jumpForce + (Vector3.up * -body.velocity.y)), ForceMode.Impulse); // apply jump force + equal out downward momentum
                jumps--; // reduce jumps by one
            }
        }

        if (body.velocity.y >= 0) // if the player's not falling (if their falling force has been countered)
            counterFallingForce = true;
        if (Input.GetKey(KeyCode.W) && touchingLadder) // if the player holds 'W' AND is touching a ladder
        {
            body.useGravity = false; // disable gravity while climbing
            if (body.velocity.y < 0 && counterFallingForce) // if the Player is falling and their falling force hasn't been countered
            {
                body.AddForce(Vector3.up * -body.velocity.y, ForceMode.VelocityChange); // counteract that force
                counterFallingForce = false;
            }
            transform.Translate(Vector3.up * Time.deltaTime * speed); // move them up
        }

        if (!touchingLadder || !(Input.GetKey(KeyCode.W))) // if the player is not touching a ladder OR they're not holding up
            body.useGravity = true;

        if ((body.velocity.y < 0) && !touchingLadder) // while the player is falling and not touching a ladder
            body.velocity += Vector3.up * -10 * Time.deltaTime; // makes it fall faster

        if (dead) // once the player dies
        {
            if (Input.anyKeyDown) // wait for a key to be pressed
                restart();    //restart the level
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * XInput); // move the character left or right
        // maybe try out: body.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed * XInput); // move the character left or right
    }

    void OnTriggerEnter(Collider other) // checks if the Player is touching certain objects
    {
        if (other.tag == "Ladder")
        {
            touchingLadder = true; // note that the Player is touching a ladder
        }
        if (other.tag == "MovingPlatform")
            transform.parent = other.transform; // make the platform the parent of the Player
        if (other.tag == "Key")
        {
            keys++; // add the key to the player's collection
            Destroy(other.gameObject); // destroy the key object
        }
        if (other.tag == "Hazard")
        {
            dead = true;
            Time.timeScale = 0; //pause the game
        }
    }

    void OnTriggerExit(Collider other) // checks if the Player stops touching certain objects
    {
        if (other.tag == "Ladder")
        {
            touchingLadder = false;
        }
        if (other.tag == "MovingPlatform")
            transform.parent = null; // make the platform the parent of the Player
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the level
        Time.timeScale = 1;
    }
}