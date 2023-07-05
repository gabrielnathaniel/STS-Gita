using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineSceneChanger : MonoBehaviour
{
    public string sceneToLoad = "Chapter 1 - Hall";

    public SceneFader sceneFader;

    [SerializeField] private int unlockChapter;

    void OnEnable()
    {
        LevelManager.UnlockLevel(unlockChapter);
        sceneFader.FadeTo(sceneToLoad);
    }
}
