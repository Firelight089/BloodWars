using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    public GameObject popUp;
    [SerializeField] float speed = 100.0f;
    [SerializeField] float textPosEnd = 1330.0f; //or 1500.f to move to the very top.

    RectTransform scrollingText;
    
    void Start()
    {
        scrollingText = gameObject.GetComponent<RectTransform>();
    }
    // Update is called once per frame

    void Update()
    {

        scrollingText.Translate(Vector3.up * speed * Time.deltaTime);
        if (scrollingText.localPosition.y >= textPosEnd)
        {
            popUp.SetActive(true);
        }
    }
}
