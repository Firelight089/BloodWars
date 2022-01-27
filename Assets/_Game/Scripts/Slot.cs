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
    new public Sprite icon;
    public Inventory helmetInventory;

    private void Start()
    {
        //slotIconGO = transform.GetChild(0);
        int slotsNum = helmetInventory.allSlots;
    }
    public void UpdateSlot(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        // slotIconGO.GetComponent<Image>().sprite = icon;
        item = itemObject;
        ID = itemID;
        type = itemType;
        description = itemDescription;
        icon = itemIcon;
    }

    //public void UsedItem()
    //{

    //}
}