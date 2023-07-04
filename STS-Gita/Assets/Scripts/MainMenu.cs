using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "PrologOpening";

    public SceneFader sceneFader;

    [SerializeField] private GameObject controlsMenu;

    public void Play()
    {
        sceneFader.FadeTo(sceneToLoad);
    }

    public void Load()
    {
        sceneFader.FadeTo("LevelSelect");
    }

    public void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
