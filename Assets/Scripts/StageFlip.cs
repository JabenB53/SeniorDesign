using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlip : MonoBehaviour
{
    public GameObject stage;
    private bool pressed = false;
    private bool done = false;

    // Update is called once per frame
    void Update()
    {
        if (pressed && !done)
        {
            stage.transform.Rotate(Vector3.right, 180);
            done = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            pressed = true;
    }
}
