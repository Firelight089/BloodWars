using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeupComponent : MonoBehaviour
{
    public GameObject profileManager;

    void Awake()
    {
        profileManager.SetActive(true);

        profileManager.GetComponent<ProfileSceneManager>().enabled = true;
    }
}
