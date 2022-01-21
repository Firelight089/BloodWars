using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    new public bool pickedUp;
    public bool equipped;

    public void Update()
    {
        if (equipped)
        {
            //perform weapon act here
        }
    }
    public void ItemUsage()
    {
    //weapon
    if (type == "Weapon")
        {
        equipped = true;
        }

    //health

    //Accesories

    //Healment

    //Vest

    //Boots

    //Gauntlets
    }
}
