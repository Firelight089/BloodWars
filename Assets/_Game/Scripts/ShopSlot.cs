using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;
    public Equipment equipment;
    bool mPurchased = false;
    static int itemsSelected = 0;

    private void Start()
    {
        UpdateSlot(equipment);
    }

    public void UpdateSlot(Equipment equip)
    {
        if (equip!= null)
        {
            equipment = equip;
            icon.sprite = equipment.icon;
        }
    }

    public void ShopSlotButtonPressed()
    {
        if (!mPurchased)
        {
            GameObject purchaseList = GameObject.Find("PurchaseSlotholder");
            if (itemsSelected > 4)
            {
                Instantiate(Resources.Load<ShopSlot>("ShopSlot_One"), purchaseList.transform, false);
                //itemsSelected = 0;
            }
            purchaseList.transform.GetChild(itemsSelected).gameObject.SetActive(true);
            purchaseList.transform.GetChild(itemsSelected).GetComponent<ShopSlot>().UpdateSlot(equipment);
            purchaseList.transform.GetChild(itemsSelected).GetComponent<ShopSlot>().mPurchased = true;
            itemsSelected++;
        }
    }

    public void ItemsInCartCost()
    {
        GameObject itemsAdd = GameObject.Find("PurchaseSlotholder");
        int totalCost = 0;
        for (int i = 0; i < itemsAdd.transform.childCount; ++i)
        {
            if (itemsAdd.transform.GetChild(i).gameObject.activeInHierarchy == true)
            {
                totalCost += (int)itemsAdd.transform.GetChild(i).GetComponent<ShopSlot>().equipment.Cost;
                GameObject.Find("PurchaseValue").GetComponent<Text>().text = "" + totalCost; 
            }
        }
    }

}