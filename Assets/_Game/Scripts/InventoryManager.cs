using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Equipment> inventory;

        // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //inventory = new List<Equipment>();
        }

        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("CoinsValue") != null)
        {
            GameObject.Find("CoinsValue").GetComponent<Text>().text = ": " + UnitName.unitNameInstance.GetUnit().coins.ToString();
        }
    }

    public void AddItemToInventory(Equipment item)
    {
        inventory.Add(item);
    }

    public void EmptyCart()
    {
        InventoryManager.Instance.inventory.Clear();
        GameObject purchaseList = GameObject.Find("PurchaseSlotholder");
        GameObject.Find("PurchaseValue").GetComponent<Text>().text = "0,000";
        for (int i = 0; i < purchaseList.transform.childCount; ++i)
        {
            purchaseList.transform.GetChild(i).gameObject.SetActive(false);
            purchaseList.transform.GetChild(i).GetComponent<ShopSlot>().UpdateSlot(null);
            purchaseList.transform.GetChild(i).GetComponent<ShopSlot>().icon = null; // might be causing conflict
        }
    }

    public void PurchaseItems()
    {

        GameObject itemsAdd = GameObject.Find("PurchaseSlotholder");
        int totalCost = 0;
        for(int i = 0; i < itemsAdd.transform.childCount; ++i)
        {
            if (itemsAdd.transform.GetChild(i).gameObject.activeInHierarchy == true)
            {
                totalCost += (int)itemsAdd.transform.GetChild(i).GetComponent<ShopSlot>().equipment.Cost;
            }
        }
        GameObject go = GameObject.Find("PlayerNameInfo_NonDestructable");
        if (go.GetComponent<UnitName>().GetUnit().coins >= totalCost)
        {
            for (int i = 0; i < itemsAdd.transform.childCount; ++i)
            {
            InventoryManager.Instance.AddItemToInventory(itemsAdd.transform.GetChild(i).GetComponent<ShopSlot>().equipment);
            }
            go.GetComponent<UnitName>().GetUnit().coins -= totalCost;
            GameObject.Find("CoinsValue").GetComponent<Text>().text = ": " +go.GetComponent<UnitName>().GetUnit().coins.ToString();
            EmptyCart();
        }
    }
}
