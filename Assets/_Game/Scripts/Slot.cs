using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;

    public int ID;
    public string type;
    public string description; 
    public bool empty;

    public Transform slotIconGO;
    public Image icon;
    public Inventory helmetInventory;

    public Equipment equipment;

    private void Start()
    {
        //slotIconGO = transform.GetChild(0);
        //int slotsNum = helmetInventory.allSlots;

        UpdateSlot(equipment);
    }
    public void UpdateSlot(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        // slotIconGO.GetComponent<Image>().sprite = icon;
        item = itemObject;
        ID = itemID;
        type = itemType;
        description = itemDescription;
        icon.sprite = itemIcon;
    }

    public void UpdateSlot(Equipment equip)
    {
        equipment = equip;
        icon.sprite = equipment.icon;
    }

    //public void UsedItem()
    //{

    //}
}