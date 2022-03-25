using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSLevelEntry : MonoBehaviour
{

    public string levelName, levelToCheck;

    private bool canLoadLevel, levelLoading;

    // Start is called before the first frame update
    void Start()
    {
        levelLoading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && canLoadLevel && !levelLoading)
        {
            StartCoroutine(LevelLoadCo());
            levelLoading = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canLoadLevel = false;
        }
    }

    public IEnumerator LevelLoadCo()
    {
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(levelName);

        levelLoading = false;
    }
}
