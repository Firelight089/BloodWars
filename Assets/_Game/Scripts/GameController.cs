using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject healtBarFull;
    public GameObject popup;
    public float damage = 0.1f;


    private Image hBaFuImg;

    // Start is called before the first frame update
    void Start()
    {
        hBaFuImg = healtBarFull.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void Attack()
    {
        hBaFuImg.fillAmount -= damage;

        if (hBaFuImg.fillAmount <= 0.1f)
        {
            popup.SetActive(true);
        }
            }
    public void Replay (string scene)
    {
        if (true)
        {
            SceneManager.LoadScene(scene);
        }
    }
    public void Train(string scene)
    {
        if (true)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
