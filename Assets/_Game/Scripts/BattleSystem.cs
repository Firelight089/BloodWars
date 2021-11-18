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
        StartCoroutine(SetupBattle());
    }

    public void ChallengeDeclined(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerStation);
        player.transform.localPosition = Vector3.zero;
        playerUnit = player.GetComponent<Unit>();

        GameObject enemy = Instantiate(enemyPrefab, enemyStation);
        enemy.transform.localPosition = Vector3.zero;
        enemyUnit = enemy.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(0f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //Damage Enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Success!";

        yield return new WaitForSeconds(1f);

        //Check if enemy is dead
        if (isDead)
        {
            //end battle
            state = BattleState.WON;
            EndBattle(); }
        else
        {
            //enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose your movement:";
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + "attacks!";

        yield return new WaitForSeconds(1f);

        playerUnit.TakeDamage(enemyUnit.damage);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            //end battle
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            //enemy turn
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Health restored!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Enemy defeated!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

}