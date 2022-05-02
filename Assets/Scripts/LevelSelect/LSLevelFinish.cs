using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSLevelFinish : MonoBehaviour
{
    public string levelName;

    private bool levelLoading;

    // Start is called before the first frame update
    void Start()
    {
        levelLoading = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !levelLoading)
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            GameManager.instance.PauseUnpause();
            StartCoroutine(LevelLoadCo());
            levelLoading = true;
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
