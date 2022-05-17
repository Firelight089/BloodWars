using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitName : MonoBehaviour
{
    public string knightName;

    public Text inputText;
    public static UnitName unitNameInstance;
    Unit playerUnit;

    // Start is called before the first frame update
    void Awake()
    {
        if (unitNameInstance == null)
        {
            unitNameInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        if (inputText.text.Length == 0)
        {

            PlayerPrefs.SetString("name", "NoName");
            knightName = "NoName";
        }
        else
        {
            knightName = inputText.text;
            PlayerPrefs.SetString("name", knightName);
        }
    }

    public void SetUnit(Unit unit)
    {
        playerUnit = unit;
    }

    public Unit GetUnit()
    {
        return playerUnit;
    }

}
