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
            if(!AnimatorIsPlaying(swipeAnimDemo))
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
    bool AnimatorIsPlaying(Animator anim)
    {
        var animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float NTime = animStateInfo.normalizedTime;
        if (NTime > 1.0f)
            return false;
        else
            return true;
    }
    public void PlayGenderAnim()
    {
        tutorialAnimator.SetTrigger("Done");
    }
}
