using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundImage : MonoBehaviour
{
    public Slider volumeSlider; 
    public Image speakerImage; 
    public Sprite speakerOn; 
    public Sprite speakerOff;

    void Start()
    {
       
        volumeSlider.onValueChanged.AddListener(delegate { CheckVolume(); });

        CheckVolume();
    }

    void CheckVolume()
    {
        if (volumeSlider.value == 0)
        {
            speakerImage.sprite = speakerOff; // 음소거 아이콘
        }
        else
        {
            speakerImage.sprite = speakerOn; // 일반 아이콘
        }
    }
}
