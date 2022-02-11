using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public Equipment equipment;

    new public bool pickedUp;
    public bool equipped;

    public Inventory inventory;

    public void Update()
    {
        //if (equipped)
        //{
        //    //perform weapon act here
        //}

    }

    public void EquipItem()
    {
        if (equipment.type == EquipmentType.Armor)
        {

        }
    }

    public void ItemButtonClicked()
    {

        if (/*equipment.type == EquipmentType.Armor &&*/ pickedUp == false)
        {
            pickedUp = true;
            Item itemPickedUp = gameObject.GetComponent<Item>();
            //Item item = itemPickedUp.GetComponent<Item>();
            //inventory.AddItem(gameObject, itemPickedUp.ID, itemPickedUp.type, itemPickedUp.description, itemPickedUp.icon);

            InventoryManager.Instance.AddItemToInventory(equipment);

            Destroy(gameObject);
        }
    }

}
