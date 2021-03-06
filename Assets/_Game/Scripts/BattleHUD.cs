using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nameText;
    public Text leveltext;
    public Slider hpSlider;
    public GameObject healthBarFull;
    private Image hBaFuImg;
    public Text unitHealthText;
    public Text unitAttackText;
    public Text unitDefenseText;
    public Text unitCoinsText;

    void Start()
    {
        hBaFuImg = healthBarFull.GetComponent<Image>();
    }
    public void SetPlayerHUD(Unit unit)
    {
        nameText.text = GameObject.Find("PlayerNameInfo_NonDestructable").GetComponent<UnitName>().knightName;
        leveltext.text = "" + unit.unitLevel;// CharacterListManager.playerUnit.unitLevel;//GameObject.Find("CharacterListManager").GetComponent<CharacterListManager>().playerUnit.unitLevel;
        //hBaFuImg.fillAmount = unit.maxHP;
        //hpSlider.maxValue = unit.maxHP;
        //hpSlider.value = unit.currentHP;
        unitHealthText.text = "" + unit.currentHP;
        unitAttackText.text = "" + unit.damage;
        unitDefenseText.text = "" + unit.experience;
        unitDefenseText.text = "" + unit.defense;
        unitCoinsText.text = "" + unit.coins;
    }

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        leveltext.text = "" + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        unitHealthText.text = "" + unit.currentHP;
        unitAttackText.text = "" + unit.damage;
        unitDefenseText.text = "" + unit.experience;
        unitDefenseText.text = "" + unit.defense;
        unitCoinsText.text = "" + unit.coins;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        unitHealthText.text = "" + hp;
    }

    public void SetCoins(int coins)
    {
        UnitName.unitNameInstance.GetUnit().coins -= coins;
        unitCoinsText.text = "" + UnitName.unitNameInstance.GetUnit().coins.ToString();
    }


}