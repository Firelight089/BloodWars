using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleItemDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    public GameObject armorsWindow;
    public GameObject weaponsWindow;
    public GameObject accessoriesWindow;
    public GameObject shieldsWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropdownChoiceSelected()
    {
        Debug.Log(dropdown.value);
        if(dropdown.value == 0)
        {
            armorsWindow.SetActive(true);
            weaponsWindow.SetActive(false);
            accessoriesWindow.SetActive(false);
            shieldsWindow.SetActive(false);
        }
        else if(dropdown.value == 1)
        {
            armorsWindow.SetActive(false);
            weaponsWindow.SetActive(false);
            accessoriesWindow.SetActive(false);
            shieldsWindow.SetActive(true);
        }
        else if (dropdown.value == 2)
        {
            armorsWindow.SetActive(false);
            weaponsWindow.SetActive(true);
            accessoriesWindow.SetActive(false);
            shieldsWindow.SetActive(false);
        }
        else if (dropdown.value == 3)
        {
            armorsWindow.SetActive(false);
            weaponsWindow.SetActive(false);
            accessoriesWindow.SetActive(true);
            shieldsWindow.SetActive(false);
        }
    }
}
