using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public GameObject popUp;
    public GameObject activeInventory;

    
    public GameObject slotHolder;
    public GameObject inventorySlotPrefab;
    private List<GameObject> spawnedObjects;

    public EquipmentType equipmentFilter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        spawnedObjects = new List<GameObject>();
        Debug.Log("Initalize inventory");
        List<Equipment> equipments = InventoryManager.Instance.inventory;
        for (int i = 0; i < equipments.Count; i++)
        {
            if (equipments[i].type == equipmentFilter)
            {
                GameObject g = Instantiate(inventorySlotPrefab, slotHolder.transform);
                InventorySlot slotScript = g.GetComponent<InventorySlot>();
                slotScript.UpdateSlot(equipments[i]);
                spawnedObjects.Add(g);
            }

        }
    }

    private void OnDisable()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
        }

        spawnedObjects.Clear();
    }


}
