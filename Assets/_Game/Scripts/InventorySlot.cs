using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image image;
    public Equipment equipment;

    private void Start()
    {
        
    }


    public void UpdateSlot(Equipment equip)
    {
        equipment = equip;
        image.sprite = equipment.icon;
    }

    //public void UsedItem()
    //{

    //}
}