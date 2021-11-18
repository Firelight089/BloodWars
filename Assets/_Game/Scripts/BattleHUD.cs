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

    public void SetHUD (Unit unit)
    {
        nameText.text = unit.unitName;
        leveltext.text = " " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP (int hp)
    {
        hpSlider.value = hp;
    }
}