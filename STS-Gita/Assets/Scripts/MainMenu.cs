using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "LevelSelect";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(sceneToLoad);
    }

    public void Exit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
