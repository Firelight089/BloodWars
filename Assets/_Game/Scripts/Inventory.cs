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

    //Add item to inventory
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        
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
            //slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().ID = itemID;
            //slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().type = itemType;
            //slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().description = itemDescription;
            //slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().icon = itemIcon;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().pickedUp = true;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Item>().inventory = this;
            slotHolder.transform.GetChild(inventoryIndex).GetComponent<Image>().sprite = itemIcon;
        }
        inventoryIndex++;

    }

    
}
