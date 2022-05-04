using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public GameObject activeInventory;
    public GameObject slotHolder;
    public GameObject unitSlotPrefab;
    private List<GameObject> spawnedObjects;

    public UnitGender characterGenderFilter;
    public Element characterElementFilter;

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
        //Debug.Log("Initalize character inventory");
        List<Unit> units = CharacterListManager.Instance.characterList;
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].unitElement == characterElementFilter)
            {
                GameObject g = Instantiate(unitSlotPrefab, slotHolder.transform);
                UnitSlot slotScript = g.GetComponent<UnitSlot>();
                slotScript.UpdateCharacterSlot(units[i]);
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
