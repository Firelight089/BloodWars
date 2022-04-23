using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSlot : MonoBehaviour
{
    public Image icon;
    public Unit unit;
    private void Start()
    {
        UpdateSlot(unit);
    }

    public void UpdateSlot(Unit character)
    {
        unit = character;
        icon.sprite = unit.icon;
    }

    public void ShopSlotButtonPressed()
    {

    }
}





