using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileSceneManager : MonoBehaviour
{
    [SerializeField]
    Text character_name;

    void Awake()
    {
        character_name.text = GameObject.Find("PlayerNameInfo_NonDestructable").GetComponent<UnitName>().knightName;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
