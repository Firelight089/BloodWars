using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Inventory PopUp objs and variable
    public bool inventoryEnabled;
    public GameObject popUp;
    public GameObject activeInventory;

    //Inventory slots #

    public int allSlots;
    private int enabledSlots;
    public GameObject[] slot;

    public GameObject slotHolder;
    int inventoryIndex = 0;
    private void Awake()
    {
        allSlots = 5;
        slot = new GameObject[allSlots];
        //for (int i = 0; i < allSlots; i++)
        //{
        //    //slot[i] = slotHolder.transform.GetChild(i).gameObject;
        //    if (slot[i].GetComponent<Slot>().item = null); //check slots to see if they are empty
        //    {
        //        slot[i].GetComponent<Slot>().empty = true;
        //    }
        //}
    }


    //Inventory PopUp acitvation and deactivation
    public void ActivateInventory()
    {
        if (popUp.activeSelf)
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled == true)
        {
            activeInventory.SetActive(true);
        }
    }
    public void DeactivateInventory()
    {
        activeInventory.SetActive(false);
    }

    //Pickup Item  * for physical contact, needs to be changed to menu based
    private void ItemCollected (Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }
    

    //Add item to inventory
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        //for (int i = 0; i < allSlots; i++)
        //{
        //    if(slot [i].GetComponent<Slot>().empty)
        //    {
        //        //add item to slot
        //        itemObject.GetComponent<Item>().pickedUp = true;

        //        slot[i].GetComponent<Slot>().item = itemObject;
        //        slot[i].GetComponent<Slot>().icon = itemIcon;
        //        slot[i].GetComponent<Slot>().type = itemType;
        //        slot[i].GetComponent<Slot>().ID = itemID;
        //        slot[i].GetComponent<Slot>().description = itemDescription;

        //        itemObject.transform.parent = slot[i].transform; //move the GO to the slot
        //        itemObject.SetActive(false); //disable until used.

        //        slot[i].GetComponent<Slot>().UpdateSlot();
        //        slot[i].GetComponent<Slot>().empty = false;
        //    }
        //    return;
        //}
        
        if (inventoryIndex >= slot.Length)
        {
            GameObject[] temp = slot;
            slot = new GameObject[inventoryIndex + 1];
            for (int i = 0; i < temp.Length; ++i)
            {
                slot[i] = temp[i];
            }
            
        }

        if (slot[inventoryIndex] == null)
        {
            slot[inventoryIndex] = itemObject;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().ID = itemID;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().type = itemType;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().description = itemDescription;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().icon = itemIcon;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().pickedUp = true;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().inventory = this;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Image>().sprite = itemIcon;
        }
        inventoryIndex++;

    }

    
}
