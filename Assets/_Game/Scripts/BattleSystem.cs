using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerStation;
    public Transform enemyStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public GameObject fightingArena;
    public GameObject challenge;

    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChallengeAccepted()
    {
        fightingArena.SetActive(true);
        challenge.SetActive(false);
        state = BattleState.START;
        SetupBattle();
    }

    public void ChallengeDeclined(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerStation);
        player.transform.localPosition = Vector3.zero;
        playerUnit = player.GetComponent<Unit>();

        GameObject enemy = Instantiate(enemyPrefab, enemyStation);
        enemy.transform.localPosition = Vector3.zero;
        enemyUnit = enemy.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose your movement:";
    }
}