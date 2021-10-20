using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrinOurName ()
    {
        print("Richard");
        print("Elena");
        print("Cole");
    }

    public void ChangeScene (string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
