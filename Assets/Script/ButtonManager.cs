using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    void Start()
    {
       
    }


    public void GameStartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GameLoad()
    {
        SceneManager.LoadScene("InGame");
    }

    public void TestScenes()
    {
        SceneManager.LoadScene("TestScenes");
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
