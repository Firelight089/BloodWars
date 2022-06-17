using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageController : MonoBehaviour
{
    public GameObject healthBarFull;
    private Image hBaFuImg;

    // Start is called before the first frame update
    void Start()
    {
        healthBarFull.transform.Find("HealthBarFull");
        hBaFuImg = healthBarFull.GetComponent<Image>();
        hBaFuImg.fillAmount = (float)UnitName.unitNameInstance.GetUnit().currentHP / (float)UnitName.unitNameInstance.GetUnit().maxHP;
    }

    // Update is called once per frame

    void Update()
    {
      
      
    }
}
