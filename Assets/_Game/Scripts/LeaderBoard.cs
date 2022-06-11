using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    static public GameObject instance = null;

    public Text highscoreText;

    public int highScore = 0;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = gameObject;
        }
    }

    public void UpdateHighscore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highscoreText.text = "Highscore: " + highScore;
        }
    }

    public void ShowHighScore()
    {
        highscoreText.gameObject.SetActive(true);
    }

    public void HideHighScore()
    {
        highscoreText.gameObject.SetActive(false);
    }
}
