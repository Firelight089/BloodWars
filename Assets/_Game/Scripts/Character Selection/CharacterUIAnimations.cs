using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIAnimations : MonoBehaviour
{
    public Animator tutorialAnimator;
    public Animator swipeAnimDemo;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Update()
    {
        if (swipeAnimDemo.GetCurrentAnimatorStateInfo(0).IsName("SwipeDemo"))
        {
            if(!AnimatorIsPlaying())
            {
                swipeAnimDemo.enabled = false;
            }
        }
    }
    public void PlayAnim()
    {
        tutorialAnimator.SetTrigger("Clicked");
        swipeAnimDemo.SetTrigger("Clicked");
        
    }
    bool AnimatorIsPlaying()
    {
        var animStateInfo = swipeAnimDemo.GetCurrentAnimatorStateInfo(0);
        float NTime = animStateInfo.normalizedTime;
        if (NTime > 1.0f)
            return false;
        else
            return true;
    }
}
