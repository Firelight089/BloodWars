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
    public Text unitHealthText;

    public void SetHUD (Unit unit)
    {
        nameText.text = unit.unitName;
        leveltext.text = " " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        unitHealthText.text = "" + unit.currentHP;
    }

    public void SetHP (int hp)
    {
       hpSlider.value = hp;
        unitHealthText.text = "" + hp;
    }
}