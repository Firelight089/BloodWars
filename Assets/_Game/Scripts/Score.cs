using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int counter;
    public Text scoreText;

    public GameObject Reward1;
    private Animation r1Anim;
    public GameObject Reward2;
    private Animation r2Anim;
    public GameObject Reward3;
    private Animation r3Anim;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        r1Anim = Reward1.GetComponent<Animation>();
        r2Anim = Reward2.GetComponent<Animation>();
        r3Anim = Reward3.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = counter.ToString();
    }

    public void AddScore()
    {
        counter++;
        if (counter == 5)
        {
            r1Anim.Play("Reward1Animation");
        }
        else if (counter == 10)
        {
            r2Anim.Play("Reward2Animation");
        }
        else if (counter == 15)
        {
            r3Anim.Play("Reward3Animation");
        }
        else if (counter == 20)
        {
            popup.SetActive(true);
        }
    }
}
