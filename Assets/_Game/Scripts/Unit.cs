using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Element { FIRE, WATER, WIND, EARTH, MAGIC }
public enum UnitGender { FEMALE, MALE }

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
    
    public Element unitElement;
    public UnitGender unitGender;

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
}
