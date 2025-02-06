using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SoundGage;

    public void SetMusicVolume(float volume)
    {
        SoundGage.volume = volume; 
    }
}
