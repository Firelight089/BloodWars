using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputManager : MonoBehaviour
{
    public Text scoreText;
    public Image aiSprite;
    public Image playerSprite;
    public RPSGameController gameManager;

    public void UpdateScore(int playerScore, int aiScore)
    {
        scoreText.text = $"{playerScore} - {aiScore}";
    }

    internal void DisplayAIOptionImage(RPSGameController.AIOptions aiChoice)
    {
        aiSprite.sprite = Resources.Load<Sprite>(aiChoice.ToString());
    }

    internal void DisplayPlayerOptionImage(RPSGameController.Options playerChoice)
    {
        playerSprite.sprite = Resources.Load<Sprite>(playerChoice.ToString());
    }

    public void RockButton()
    {
        gameManager.TryScore(RPSGameController.Options.Rock);
    }

    public void PaperButton()
    {
        gameManager.TryScore(RPSGameController.Options.Paper);
    }

    public void ScissorsButton()
    {
        gameManager.TryScore(RPSGameController.Options.Scissors);
    }
}
