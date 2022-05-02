using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public GameObject cesta;

    public FruitManager fm;
    public string frutaAvaliada;
    public float frutasEsperadas;
    public int totalFrutas;

    public GameObject success, failure;


    public static QuizManager instance;

    // when game starts
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check(GameObject nextUIScreen, string nextFruta, int nextTotal, int nextEsperadas, GameObject bridge,
                Transform nextPositionNPC, GameObject nextCesta, FruitManager nextFM)
    {
        // verificar se o n�mero de frutas na cesta bate com a fra��o esperada
        Cesta cestaAvaliada = this.cesta.GetComponent<Cesta>();
        Debug.Log(frutasEsperadas);
        if (cestaAvaliada.objetos.Count == 0)
        {            
            //abre a ponte e mostra msg
            bridge.SetActive(true);
            StartCoroutine(RemoveAfterSeconds(3, success));

            //move o NPC
            GameManager.instance.NPC.transform.position = nextPositionNPC.position;


            // muda interface
            UIManager.instance.currentPuzzle = nextUIScreen;

            // reseta p o proximo quiz
            frutasEsperadas = 0;
            frutaAvaliada = nextFruta;
            totalFrutas = nextTotal;
            cesta = nextCesta;
            fm = nextFM;
        }
        else
        {
            HealthManager.instance.Hurt();
            StartCoroutine(RemoveAfterSeconds(3, failure));
            fm.ResetChildren();
            Debug.Log("Errou");

        }
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

}
