using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject NPC;

    private Vector3 respawnPosition;

    // when game starts
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;

        NPCHappy();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.theCBrain.enabled = false;

        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        HealthManager.instance.ResetHealth();

        UIManager.instance.fadeFromBlack = true;

        PlayerController.instance.transform.position = respawnPosition;

        CameraController.instance.theCBrain.enabled = true;

        PlayerController.instance.gameObject.SetActive(true);

    }

    public void SetSpawnPoint(Vector3 newSpawn)
    {
        respawnPosition = newSpawn;
    }

    public void PauseUnpause()
    { 
        if(UIManager.instance.currentPuzzle.activeInHierarchy)
        {
            Time.timeScale = 1f;
            UIManager.instance.currentPuzzle.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UIManager.instance.currentPuzzle.SetActive(true);
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void NPCHappy()
    {
        Animator anim = NPC.GetComponent<Animator>();
        anim.SetBool("happy", true);
    }
}
