using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCamera : MonoBehaviour
{

    public Transform target;

    private Vector3 offset; // distance of player

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // posi��o da c�mera - posi��o do player = ofset
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
