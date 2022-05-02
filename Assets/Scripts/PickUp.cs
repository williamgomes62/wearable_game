using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public bool isPickedUp;
    public GameObject follow;

    private Rigidbody myRigidbody;

    // Use this for initialization
    void Start()
    {
        //this caches the rigidbody so it doesn't have to look it up constantly
        myRigidbody = GetComponent<Rigidbody>();
        isPickedUp = false;
    }

    //Since this is a physics movement, do it in the fixed update
    void Update()
    {
        if (isPickedUp == true)
        {
            transform.position = follow.transform.position;
            transform.rotation = Quaternion.identity;
        }
    }
}
