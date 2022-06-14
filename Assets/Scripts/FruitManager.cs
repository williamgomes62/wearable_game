using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{

    private Vector3[] children;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] c = this.GetComponentsInChildren<Transform>();
        children = new Vector3[c.Length];

        for (int i = 0; i < c.Length; i++)
        {
            children[i] = c[i].position;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetChildren()
    {
        Transform[] actual = this.GetComponentsInChildren<Transform>();
        for(int i = 0; i < children.Length; i++)
        {
            Debug.Log(actual[i].gameObject.transform.position + ":" + children[i]);
            actual[i].gameObject.transform.position = children[i];
            actual[i].gameObject.SetActive(true);

        }
    }
}
