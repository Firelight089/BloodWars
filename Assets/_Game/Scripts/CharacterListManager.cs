using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterListManager : MonoBehaviour
{
    public static CharacterListManager Instance;
    public List<Unit> characterList;
    public Toggle maleToggle;
    public Toggle femaleToggle;
    public Toggle fireToggle;
    public Toggle waterToggle;
    public Toggle windToggle;
    public Toggle magicToggle;
    public Toggle earthToggle;

    public Unit playerUnit;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //inventory = new List<Equipment>();
            playerUnit = new Unit();
            DontDestroyOnLoad(this.gameObject);
        }

        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].gameObject.SetActive(false);

        }

        UnitGender genderFilter = UnitGender.MALE;
        if (femaleToggle.isOn)
            genderFilter = UnitGender.FEMALE;

        Element elementFilter = Element.FIRE;
        if (waterToggle.isOn) elementFilter = Element.WATER;
        else if (windToggle.isOn) elementFilter = Element.WIND;
        else if (magicToggle.isOn) elementFilter = Element.MAGIC;
        else if (earthToggle.isOn) elementFilter = Element.EARTH;

        List<Unit> filterList = characterList.FindAll(e => e.unitGender == genderFilter && e.unitElement == elementFilter);

        for (int i = 0; i < filterList.Count; i++)
        {
            filterList[i].gameObject.SetActive(true);
        }

        //Debug.Log(filterList.Count);
    }

    public void SavePlayerInfo(Unit character)
    {
        //Unit unit = new Unit();

        this.playerUnit = character;
        

        DontDestroyOnLoad(character.gameObject);


        //this.playerUnit.coins = character.coins;
        //this.playerUnit.unitName = character.unitName;
        //this.playerUnit.unitLevel = character.unitLevel;
        //this.playerUnit.icon = character.icon;
        //this.playerUnit.damage = character.damage;
        //this.playerUnit.defense = character.defense;
        //this.playerUnit.equipment = character.equipment;
        //this.playerUnit.experience = character.experience;
        //this.playerUnit.maxHP = character.maxHP;
        //this.playerUnit.currentHP = character.currentHP;
        //this.playerUnit.unitElement = character.unitElement;
        //this.playerUnit.unitGender = character.unitGender;

        //character = character.GetComponent<Unit>();
        Debug.Log("The selected Knight is" + this.playerUnit.unitName);
    }
}
