using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCoins : MonoBehaviour
{
    [SerializeField]
    private int numberOfCoins;

    [SerializeField]
    private GameObject coinPrefab;

    private List<GameObject> coins;

    [SerializeField]
    private GameObject gameOverGroup, finalScoreText;

    UiManager uiManager;

    void Start()
    {
        coins = new List<GameObject>();
        for (int coinIndex = 0; coinIndex < this.numberOfCoins; coinIndex++)
        {
            GameObject coin = Instantiate(coinPrefab, this.gameObject.transform);
            coins.Add(coin);
        }

    }
    public void LooseCoin()
    {
        this.numberOfCoins -= 1;
        GameObject coinClone = this.coins[this.coins.Count - 1];
        this.coins.RemoveAt(this.coins.Count - 1);
        Destroy(coinClone);
        Debug.Log("Coin deducted");

        if (this.numberOfCoins == 0)
        {
            this.gameOverGroup.SetActive(true);
            //this.finalScoreText.GetComponent<Text>().text = "Your score was " + this.scoreText.GetComponent<ShowScore>().getScore();
            uiManager = GameObject.Find("Game Over Group").GetComponent<UiManager>();
            uiManager.PauseRockPaperScissors();
            GameObject pause = GameObject.Find("PauseButton");
            pause.SetActive(false);
        }
    }
    public void WinCoin()
    {
        this.numberOfCoins += 1;
        GameObject coin = Instantiate(coinPrefab, gameObject.transform);
        coins.Add(coin);
        Debug.Log("Coin added");

        if (this.numberOfCoins >= 5)
        {
            this.gameOverGroup.SetActive(true);
            //this.finalScoreText.GetComponent<Text>().text = "Your score was " + this.scoreText.GetComponent<ShowScore>().getScore();
            uiManager = GameObject.Find("Game Over Group").GetComponent<UiManager>();
            uiManager.PauseRockPaperScissors();
            GameObject pause = GameObject.Find("PauseButton");
            pause.SetActive(false);
        }
    }
}
