using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineSceneChanger : MonoBehaviour
{
    public string sceneToLoad = "Chapter 1 - Hall";

    public SceneFader sceneFader;

    void OnEnable()
    {
        sceneFader.FadeTo(sceneToLoad);
    }
}
