using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCube : MonoBehaviour
{

    private BoxCollider2D boxcollider2d;
    private Rigidbody2D rb;

    public GameObject msCylinder;
    private CapsuleCollider2D msCylCapsulCollider;

       // Start is called before the first frame update
    void Start()
    {
        boxcollider2d = GetComponent<BoxCollider2D>();
        boxcollider2d.isTrigger = true;

        rb = GetComponent<Rigidbody2D>();
        rb.mass = 5f;

        msCylCapsulCollider = msCylinder.GetComponent<CapsuleCollider2D>();
        msCylCapsulCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
