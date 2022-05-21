using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSGameController : MonoBehaviour
{
    public PlayerInputManager playerInput;

    private int playerScore = 0;
    private int aiScore = 0;
    private AIOptions aiChoice;

    ShowCoins showCoins;
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

    private void Start()
    {
        showCoins = GameObject.Find("PlayerCoins").GetComponent<ShowCoins>();
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
                showCoins.WinCoin();
            }
            else if (aiOption == AIOptions.AiScissors)
            {
                aiScore++;
                showCoins.LooseCoin();
            }
        }

        if (type == Options.Rock)
        {
            if (aiOption == AIOptions.AiScissors)
            {
                playerScore++;
                showCoins.WinCoin();
            }
            else if (aiOption == AIOptions.AiPaper)
            {
                aiScore++;
                showCoins.LooseCoin();
            }
        }

        if (type == Options.Scissors)
        {
            if (aiOption == AIOptions.AiPaper)
            {
                playerScore++;
                showCoins.WinCoin();
            }
            else if (aiOption == AIOptions.AiRock)
            {
                aiScore++;
                showCoins.LooseCoin();
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
}
