using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public bool isPressed;
    public Transform button, buttonDown;
    public Vector3 buttonUp;

    public string nextFruta;
    public int nextTotal, nextEsperadas;
    public GameObject bridge, nextCesta, nextUI;
    public Transform nextPositionNPC;
    public FruitManager nextFM;

    // Start is called before the first frame update
    void Start()
    {
        buttonUp = button.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isPressed)
            {
                button.position = buttonUp;
                isPressed = false;
            }
            else
            {
                button.position = buttonDown.position;
                isPressed = true;
                QuizManager.instance.Check(nextUI, nextFruta, nextTotal, nextEsperadas, bridge, nextPositionNPC, nextCesta, nextFM);
                Debug.Log("Pronto");
            }
        }
    }
}
