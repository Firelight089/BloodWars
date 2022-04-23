using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Element { FIRE, WATER, WIND, EARTH, MAGIC }

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public Sprite icon;

    public bool Female;
    public int damage;
    public int defense;
    public int equipment;
    public int experience;
    public int coins;

    public int maxHP;
    public int currentHP;
    public string type;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;

    }
    public enum UnitType
    {
        Magic,
        Fire,
        Earth,
        Water,
        Wind
    }
    public enum UnitGender
    {
        Male,   
        Female
    }


}
