using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    [SerializeField]
    Image playerImage;
    public GameObject enemyPrefab;

    public GameObject playerStation;
    public Transform playerStationSpawn;
    public Transform enemyStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public GameObject fightingArena;
    public GameObject challenge;
    public GameObject rematch;
    public GameObject goHeal;

    public Text rematchText;
    public Text healText;

    public Text dialogueText;

    public GameObject[] buttons;


    // Start is called before the first frame update
    void Start()
    {
        //playerPrefab = CharacterListManager.playerUnit.gameObject;
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
        if(CharacterListManager.Instance == null)
        {
            GameObject player = Instantiate(playerPrefab, playerStationSpawn);
            player.transform.localPosition = Vector3.zero;
            playerUnit = player.GetComponent<Unit>();
        }
        else
        {
            playerUnit = CharacterListManager.playerUnit;
            playerStation.gameObject.transform.Find("PlayerImage").gameObject.GetComponentInChildren<Image>().enabled = true;
            playerStation.gameObject.transform.Find("PlayerImage").gameObject.GetComponentInChildren<Image>().sprite = playerUnit.icon;
        }


        GameObject enemy = Instantiate(enemyPrefab, enemyStation);
        enemy.transform.localPosition = Vector3.zero;
        enemyUnit = enemy.GetComponent<Unit>();

        playerHUD.SetPlayerHUD(playerUnit);
        
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(0f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(int id)
    {
        if (id == 0)
        {
            enemyUnit.TakeDamage(-5);
            int damage = playerUnit.GetDamage();
            int totalDamage = damage + 5;
            dialogueText.text = totalDamage + " Damage to enemy!";
        }
        if (id == 1)
        {
            enemyUnit.TakeDamage(-10);
            int damage = playerUnit.GetDamage();
            int totalDamage = damage + 10;
            dialogueText.text = totalDamage + " Damage to enemy!";
        }
        if (id == 2)
        {
            enemyUnit.TakeDamage(-15);
            int damage = playerUnit.GetDamage();
            int totalDamage = damage + 15;
            dialogueText.text = totalDamage + " Damage to enemy!";
        }
        if (id == 3)
        {
            enemyUnit.TakeDamage(-20);
            int damage = playerUnit.GetDamage();
            int totalDamage = damage + 20;
            dialogueText.text = totalDamage + " Damage to enemy!";
        }

        //Damage Enemy
        BattleBoost();
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        //dialogueText.text = "Success!";

        yield return new WaitForSeconds(2f);

        //Check if enemy is dead
        if (isDead)
        {
            //end battle
            state = BattleState.WON;
            EndBattle();
        }
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

    public void OnAttackButton(int id)
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack(id));
    }

    IEnumerator PlayerHeal(int id)
    {
        if (id == 0)
        {
            playerUnit.Heal(5);
            dialogueText.text = "5 Health restored!";
        }
        if (id == 1)
        {
            playerUnit.Heal(25);
            playerHUD.SetCoins(50);
            dialogueText.text = "25 Health restored!";
        }
        if (id == 2)
        {
            playerUnit.Heal(50);
            playerHUD.SetCoins(100);
            dialogueText.text = "50 Health restored!";
        }
        if (id == 3)
        {
            playerUnit.Heal(100);
            playerHUD.SetCoins(200);
            dialogueText.text = "100 Health restored!";
        }

        playerHUD.SetHP(playerUnit.currentHP);
        

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void OnHealButton(int id)
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal(id));
    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Enemy defeated! ";
            fightingArena.SetActive(false);
            if (playerUnit.currentHP <= 0)
            {
                goHeal.SetActive(true);
                healText.text = dialogueText.text + " You were badly hurt, Take some time to heal and try again";
            }
            else
                rematch.SetActive(true);
                rematchText.text = dialogueText.text + " Fight again?";
        }
        else if (state == BattleState.LOST)
        {
            fightingArena.SetActive(false);
            if (playerUnit.currentHP <= 0)
            {
                goHeal.SetActive(true);
                healText.text = dialogueText.text + " You were badly hurt, Take some time to heal and try again";
            }
            else
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

        Element enemyType;
        enemyType = enemyUnit.unitElement;
        enemyUnit.damage = enemyPrefab.GetComponent<Unit>().damage;
        playerUnit.damage = playerPrefab.GetComponent<Unit>().damage;
        // Water enemy
        if (enemyUnit.unitElement == Element.WATER && playerUnit.unitElement == Element.WATER)
        {
            dialogueText.text = "No element advantage";
        }
        if (enemyUnit.unitElement == Element.WATER && playerUnit.unitElement == Element.FIRE)
        {
            dialogueText.text = enemyUnit.unitName + " has Water advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.WATER && playerUnit.unitElement == Element.MAGIC)
        {
            dialogueText.text = enemyUnit.unitName + " has Water advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.WATER && playerUnit.unitElement == Element.EARTH)
        {
            dialogueText.text = playerUnit.unitName + " has Earth advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.WATER && playerUnit.unitElement == Element.WIND)
        {
            dialogueText.text = playerUnit.unitName + " has Wind advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        // Fire enemy

        if (enemyUnit.unitElement == Element.FIRE && playerUnit.unitElement == Element.FIRE)
        {
            dialogueText.text = "No element advantage";
        }
        if (enemyUnit.unitElement == Element.FIRE && playerUnit.unitElement == Element.MAGIC)
        {
            dialogueText.text = enemyUnit.unitName + " has Fire advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
            Debug.Log(enemyUnit.damage);
        }
        if (enemyUnit.unitElement == Element.FIRE && playerUnit.unitElement == Element.EARTH)
        {
            dialogueText.text = enemyUnit.unitName + " has Fire advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.FIRE && playerUnit.unitElement == Element.WIND)
        {
            dialogueText.text = playerUnit.unitName + " has Wind advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.FIRE && playerUnit.unitElement == Element.WATER)
        {
            dialogueText.text = playerUnit.unitName + " has Water advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        // Magic enemy
        if (enemyUnit.unitElement == Element.MAGIC && playerUnit.unitElement == Element.MAGIC)
        {
            dialogueText.text = "No element advantage";
        }
        if (enemyUnit.unitElement == Element.MAGIC && playerUnit.unitElement == Element.EARTH)
        {
            dialogueText.text = enemyUnit.unitName + " has Magic advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.MAGIC && playerUnit.unitElement == Element.WIND)
        {
            dialogueText.text = enemyUnit.unitName + " has Magic advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.MAGIC && playerUnit.unitElement == Element.WATER)
        {
            dialogueText.text = playerUnit.unitName + " has Water advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.MAGIC && playerUnit.unitElement == Element.FIRE)
        {
            dialogueText.text = playerUnit.unitName + " has Fire advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        // Earth enemy

        if (enemyUnit.unitElement == Element.EARTH && playerUnit.unitElement == Element.EARTH)
        {
            dialogueText.text = "No element advantage";
        }
        if (enemyUnit.unitElement == Element.EARTH && playerUnit.unitElement == Element.WIND)
        {
            dialogueText.text = enemyUnit.unitName + " has Earth advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.EARTH && playerUnit.unitElement == Element.WATER)
        {
            dialogueText.text = enemyUnit.unitName + " has Earth advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.EARTH && playerUnit.unitElement == Element.FIRE)
        {
            dialogueText.text = playerUnit.unitName + " has Fire advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.EARTH && playerUnit.unitElement == Element.MAGIC)
        {
            dialogueText.text = playerUnit.unitName + " has Magic advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        // Wind enemy

        if (enemyUnit.unitElement == Element.WIND && playerUnit.unitElement == Element.WIND)
        {
            dialogueText.text = "No element advantage";
        }
        if (enemyUnit.unitElement == Element.WIND && playerUnit.unitElement == Element.WATER)
        {
            dialogueText.text = enemyUnit.unitName + " has Wind advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.WIND && playerUnit.unitElement == Element.FIRE)
        {
            dialogueText.text = enemyUnit.unitName + " has Wind advange";
            enemyUnit.damage = (enemyUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.WIND && playerUnit.unitElement == Element.MAGIC)
        {
            dialogueText.text = playerUnit.unitName + " has Magic advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
        if (enemyUnit.unitElement == Element.WIND && playerUnit.unitElement == Element.EARTH)
        {
            dialogueText.text = playerUnit.unitName + " has Earth advange";
            playerUnit.damage = (playerUnit.damage + 50);
        }
    }
}