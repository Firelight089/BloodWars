using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HeartClicker : MonoBehaviour
{
    //public GameObject heartClicker;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        //anim = heartClicker.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
        anim.Play("HeartClickerAnimation");
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
