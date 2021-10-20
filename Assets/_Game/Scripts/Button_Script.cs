using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    public AudioSource heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void button_touch ()
    {
        GetComponent<Animation>().Play("Button_Touch");
        AudioSource source = heart;
        source.Play();
    }
}
