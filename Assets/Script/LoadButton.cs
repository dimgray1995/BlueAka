using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadButton : MonoBehaviour
{
    public Button loadButton;

    void Start()
    {
        OnOffLoadButton();
    }

    void OnOffLoadButton()
    {

        if (PlayerPrefs.HasKey("SaveData"))
        {
            loadButton.interactable = true;

        }

        else
        {

            loadButton.interactable = false;
        }
    }
}
