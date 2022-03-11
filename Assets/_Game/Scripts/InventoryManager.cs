using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //inventory = new List<Equipment>();
        }

        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItemToInventory(Equipment item)
    {
        inventory.Add(item);
    }
}
