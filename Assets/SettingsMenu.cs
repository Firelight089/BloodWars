using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    private bool isMusicMuted = false;
    private bool isSoundsMuted = false;
    private void Start()
    {
        //isMuted = PlayerPrefs.GetInt("Muted") == 1;
        //AudioListener.pause = isMuted;
        //mixerGroup = musicMixer.FindMatchingGroups("usic");
        //Debug.Log(mixerGroup[0].name);
    }

    public void SetSoundsVolume(float volume)
    {
        //musicMixer.ou);
    }
    public void MuteMusic()
    {
        
        if (!isMusicMuted)
        {
            isMusicMuted = true;
            musicMixer.SetFloat("VolumeMusic", -80.0f);
        }
        else
        {
            isMusicMuted = false;
            musicMixer.SetFloat("VolumeMusic", -10.0f);
        }
    }
    public void MuteSounds()
    {
        if (!isSoundsMuted)
        {
            isSoundsMuted = true;
            musicMixer.SetFloat("VolumeSounds", -80.0f);
        }
        else
        {
            isSoundsMuted = false;
            musicMixer.SetFloat("VolumeSounds", -10.0f);
        }
    }
}
