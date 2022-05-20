using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static bool gameIsPaused = false;

    // Start is called before the first frame update
    public GameObject popUp;
    
    void Start()
    {
        if (gameIsPaused == true)
        {
            PauseGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ActivatePopUp()
    {
        popUp.SetActive(true);
    }
    public void HidePopUp()
    {
        popUp.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (!gameIsPaused)
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
            ActivatePopUp();
            GameObject spawn = GameObject.Find("Spawn Objects");
            spawn.GetComponent<SpawnObjects>().enabled = false;

        }
        else if (gameIsPaused)
        {
            Time.timeScale = 1;
            gameIsPaused = false;
            HidePopUp();
            GameObject spawn = GameObject.Find("Spawn Objects");
            spawn.GetComponent<SpawnObjects>().enabled = true;
            
        }
    }
    public void PauseGameFromDeath()
    {
        Time.timeScale = 0.0f;
    }

}

