using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject popup;
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
    public void SetActive()
    {
        popup.SetActive(true);
    }
    public void Hide()
    {
        popup.SetActive(false);
    }
}

