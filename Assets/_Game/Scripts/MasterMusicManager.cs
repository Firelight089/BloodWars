using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMusicManager : MonoBehaviour
{
    static public GameObject instance = null;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = gameObject;
        }
    }
}
