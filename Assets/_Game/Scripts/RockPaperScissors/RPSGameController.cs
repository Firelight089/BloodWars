using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSGameController : MonoBehaviour
{
    public PlayerInputManager playerInput;

    private int playerScore = 0;
    private int aiScore = 0;
    private AIOptions aiChoice;
    [SerializeField]
    private GameObject scoreText, gameOverGroup, finalScoreText;
    UiManager uiManager;

    public enum Options
    {
        Rock,
        Paper,
        Scissors
    }

    public enum AIOptions
    {
        AiRock,
        AiPaper,
        AiScissors
    }

    public void TryScore(Options type)
    {

        playerInput.DisplayPlayerOptionImage(type);

        var aiOption = ChooseNewAIOptionType();

        if (type == Options.Paper)
        {
            if (aiOption == AIOptions.AiRock)
            {
                playerScore++;
            }
            else if (aiOption == AIOptions.AiScissors)
            {
                aiScore++;
            }
        }

        if (type == Options.Rock)
        {
            if (aiOption == AIOptions.AiScissors)
            {
                playerScore++;
            }
            else if (aiOption == AIOptions.AiPaper)
            {
                aiScore++;
            }
        }

        if (type == Options.Scissors)
        {
            if (aiOption == AIOptions.AiPaper)
            {
                playerScore++;
            }
            else if (aiOption == AIOptions.AiRock)
            {
                aiScore++;
            }
        }

        playerInput.UpdateScore(playerScore, aiScore);
    }

    public AIOptions ChooseNewAIOptionType()
    {
        int randomValue = Random.Range(0, 3);

        switch (randomValue)
        {
            case 0:
                aiChoice = AIOptions.AiRock;
                break;
            case 1:
                aiChoice = AIOptions.AiPaper;
                break;
            case 2:
                aiChoice = AIOptions.AiScissors;
                break;
        }

        playerInput.DisplayAIOptionImage(aiChoice);
        return aiChoice;
    }
    public void FinishTraining()
    {
        if (playerScore == 5 || aiScore == 5)
        {
            this.scoreText.SetActive(false);
            this.gameOverGroup.SetActive(true);
            this.finalScoreText.GetComponent<Text>().text = "Your score was " + this.scoreText.GetComponent<ShowScore>().getScore();
            uiManager = GameObject.Find("GameOverGroup").GetComponent<UiManager>();
            uiManager.PauseGameFromDeath();
            GameObject pause = GameObject.Find("PauseButton");
            pause.SetActive(false);
        }
    }
}
