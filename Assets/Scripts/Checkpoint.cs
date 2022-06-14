using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject cpOn, cpOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.SetSpawnPoint(transform.position);

            // FIND ALL OTHER CHECKPOINTS
            Checkpoint[] allCp = FindObjectsOfType<Checkpoint>();
            for(int i = 0; i < allCp.Length; i++)
            {
                allCp[i].cpOn.SetActive(false);
                allCp[i].cpOff.SetActive(true);
            }

            cpOff.SetActive(false);
            cpOn.SetActive(true);
        }
    }
}
