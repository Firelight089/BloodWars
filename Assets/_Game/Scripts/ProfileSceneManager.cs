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
    [SerializeField]
    Sprite character_image;
    public Image unitImage;

        
    void Awake()
    {
        character_name.text = GameObject.Find("PlayerNameInfo_NonDestructable").GetComponent<UnitName>().knightName;
        character_image = CharacterListManager.playerUnit.icon;//GameObject.Find("CharacterListManager").GetComponent<CharacterListManager>().playerUnit.icon;
        GameObject.Find("PlayerNameInfo_NonDestructable").GetComponent<UnitName>().SetUnit(CharacterListManager.playerUnit);
        CharacterListManager g = GameObject.Find("CharacterListManager").GetComponent<CharacterListManager>();
        GameObject go = GameObject.Find("Player HUD");
        go.GetComponent<BattleHUD>().SetPlayerHUD(GameObject.Find("PlayerNameInfo_NonDestructable").GetComponent<UnitName>().GetUnit());//SetPlayerHUD(g.playerUnit);
        //unitImage.sprite = character_image;
    }

    IEnumerator ChangeScene(string scene)
    {
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        unitImage.sprite = character_image;       
    }

    public void SceneChanger(string scene)
    {
        StartCoroutine("ChangeScene", scene);
    }

    public void ChangeSceneNoCooldown(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
