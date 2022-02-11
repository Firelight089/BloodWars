using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;
    public Equipment equipment;

    private void Start()
    {
        UpdateSlot(equipment);
    }

    public void UpdateSlot(Equipment equip)
    {
        equipment = equip;
        icon.sprite = equipment.icon;
    }

    public void ShopSlotButtonPressed()
    {
        InventoryManager.Instance.AddItemToInventory(equipment);
    }


}