using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

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
        if (type == "Helmet")
        {

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (type == "Helmet" && pickedUp == false)
        {
            pickedUp = true;
            Item itemPickedUp = gameObject.GetComponent<Item>();
            //Item item = itemPickedUp.GetComponent<Item>();
            inventory.AddItem(gameObject, itemPickedUp.ID, itemPickedUp.type, itemPickedUp.description, itemPickedUp.icon);
            Destroy(gameObject);
        }
    }
}
