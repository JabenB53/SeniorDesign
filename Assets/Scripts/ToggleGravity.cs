using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGravity : MonoBehaviour
{
    Rigidbody thisObject; // the rigidbody of this object 

    // Start is called before the first frame update
    void Start()
    {
        thisObject = this.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MovingPlatform") // once it touches a platform
        {
            transform.parent = other.transform;
            thisObject.useGravity = true; // turn gravity on
        } 
    }
}