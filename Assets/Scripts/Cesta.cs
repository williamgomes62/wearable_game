using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cesta : MonoBehaviour
{
    public HashSet<string> objetos;

    // Start is called before the first frame update
    void Start()
    {
        objetos = new HashSet<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickable" && other.name.Contains(QuizManager.instance.frutaAvaliada) && !objetos.Contains(other.name))
        {
            Debug.Log("Fruta " + other.name + "inserida na cesta.");
            objetos.Add(other.name);
        }
    }
}
