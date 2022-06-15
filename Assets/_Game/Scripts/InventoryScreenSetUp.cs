using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenSetUp : MonoBehaviour
{
    public Image characterImage;


    void Start()
    {
        characterImage.sprite = CharacterListManager.playerUnit.icon;
        GameObject go = GameObject.Find("Player HUD");
        go.GetComponent<BattleHUD>().SetPlayerHUD(CharacterListManager.playerUnit);
    }
}
