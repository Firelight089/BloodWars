using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ProfileSceneManager : MonoBehaviour
{
    [SerializeField]
    Text character_name;
    public Sprite character_image;

        
    void Awake()
    {
        character_name.text = GameObject.Find("PlayerNameInfo_NonDestructable").GetComponent<UnitName>().knightName;
        character_image = GameObject.Find("Square").GetComponent<CharacterListManager>().playerUnit.icon;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
