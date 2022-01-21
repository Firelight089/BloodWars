using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUp;
    //public GameObject helmets;
    //public GameObject accessories;
    //public GameObject vests;
    //public GameObject shields;
    //public GameObject gauntlets;
    //public GameObject weapons;
    //public GameObject boots;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene (string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ActivatePopUp ()
    {
        popUp.SetActive(true);
    }
    public void HidePopUp()
    {
        popUp.SetActive(false);
    }
}

