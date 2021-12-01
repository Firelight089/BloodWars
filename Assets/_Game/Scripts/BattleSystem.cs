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
    public GameObject rematch;
    public Text rematchText;

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

        yield return new WaitForSeconds(2f);

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
        dialogueText.text = enemyUnit.unitName + " attacks!";
        BattleBoost();

        yield return new WaitForSeconds(2f);

        playerUnit.TakeDamage(enemyUnit.damage);

        bool isDead = false;

        if (playerUnit.currentHP <= 0)
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead == true)
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
            dialogueText.text = "Enemy defeated! ";
            fightingArena.SetActive(false);
            rematch.SetActive(true);
            rematchText.text = dialogueText.text + " Fight again?";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated. ";
            fightingArena.SetActive(false);
            rematch.SetActive(true);
            rematchText.text = dialogueText.text + " Fight again?";
        }
    }
    public void Rematch()
    {
        fightingArena.SetActive(true);
        rematch.SetActive(false);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    void BattleBoost()
    {
       
        string enemyType;
        enemyType = enemyUnit.type;
        // Water enemy
                if (enemyUnit.type == "Water" && playerUnit.type == "Water")
                {
                    dialogueText.text = "No element advantage";
                }
                if (enemyUnit.type == "Water" && playerUnit.type == "Fire")
                {
                    dialogueText.text = enemyUnit.unitName + " has Water advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Water" && playerUnit.type == "Magic")
                {
                    dialogueText.text = enemyUnit.unitName + " has Water advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Water" && playerUnit.type == "Earth")
                {
                    dialogueText.text = playerUnit.unitName + " has Earth advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
                if (enemyUnit.type == "Water" && playerUnit.type == "Wind")
                {
                    dialogueText.text = playerUnit.unitName + " has Wind advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
        // Fire enemy

                if (enemyUnit.type == "Fire" && playerUnit.type == "Fire")
                {
                    dialogueText.text = "No element advantage";
                }
                if (enemyUnit.type == "Fire" && playerUnit.type == "Magic")
                {
                    dialogueText.text = enemyUnit.unitName + " has Fire advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                    Debug.Log(enemyUnit.damage);
                }
                if (enemyUnit.type == "Fire" && playerUnit.type == "Earth")
                {
                    dialogueText.text = enemyUnit.unitName + " has Fire advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Fire" && playerUnit.type == "Wind")
                {
                    dialogueText.text = playerUnit.unitName + " has Wind advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
                if (enemyUnit.type == "Fire" && playerUnit.type == "Water")
                {
                    dialogueText.text = playerUnit.unitName + " has Water advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
        // Magic enemy
                if (enemyUnit.type == "Magic" && playerUnit.type == "Magic")
                {
                    dialogueText.text = "No element advantage";
                }
                if (enemyUnit.type == "Magic" && playerUnit.type == "Earth")
                {
                    dialogueText.text = enemyUnit.unitName + " has Magic advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Magic" && playerUnit.type == "Wind")
                {
                    dialogueText.text = enemyUnit.unitName + " has Magic advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Magic" && playerUnit.type == "Water")
                {
                dialogueText.text = playerUnit.unitName + " has Water advange";
                playerUnit.damage = (playerUnit.damage + 50);
                }
                if (enemyUnit.type == "Magic" && playerUnit.type == "Fire")
                {
                dialogueText.text = playerUnit.unitName + " has Fire advange";
                playerUnit.damage = (playerUnit.damage + 50);
                }
        // Earth enemy

                if (enemyUnit.type == "Earth" && playerUnit.type == "Earth")
                {
                dialogueText.text = "No element advantage";
                }
                if (enemyUnit.type == "Earth" && playerUnit.type == "Wind")
                {
                    dialogueText.text = enemyUnit.unitName + " has Earth advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Earth" && playerUnit.type == "Water")
                {
                dialogueText.text = enemyUnit.unitName + " has Earth advange";
                enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Earth" && playerUnit.type == "Fire")
                {
                    dialogueText.text = playerUnit.unitName + " has Fire advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
                if (enemyUnit.type == "Earth" && playerUnit.type == "Magic")
                {
                    dialogueText.text = playerUnit.unitName + " has Magic advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
        // Wind enemy

                if (enemyUnit.type == "Wind" && playerUnit.type == "Wind")
                {
                    dialogueText.text = "No element advantage";
                }
                if (enemyUnit.type == "Wind" && playerUnit.type == "Water")
                {
                    dialogueText.text = enemyUnit.unitName + " has Wind advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Wind" && playerUnit.type == "Fire")
                {
                    dialogueText.text = enemyUnit.unitName + " has Wind advange";
                    enemyUnit.damage = (enemyUnit.damage + 50);
                }
                if (enemyUnit.type == "Wind" && playerUnit.type == "Magic")
                {
                    dialogueText.text = playerUnit.unitName + " has Magic advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
                if (enemyUnit.type == "Wind" && playerUnit.type == "Earth")
                {
                    dialogueText.text = playerUnit.unitName + " has Earth advange";
                    playerUnit.damage = (playerUnit.damage + 50);
                }
    }
}