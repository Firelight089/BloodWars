using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Equipment", order = 1)]
public class Equipment : ScriptableObject
{
    public string equipmentName;
    public EquipmentType type;
    public Element element;
    public string description;
    public Sprite icon;
    public int AttackPoints;
    public int DefensePoints;
    public int ExperiencePoints;
    public int HealthPoints;
    public float Cost;

}

public enum EquipmentType
{
    Armor,
    Shield,
    Accessory,
    Weapon
}
