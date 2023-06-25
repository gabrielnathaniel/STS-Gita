using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public SceneFader sceneFader;

    public void OpenPrologue()
    {
        Debug.Log("Open Prologue");
        sceneFader.FadeTo("PrologOpening");
    }

    public void OpenChapter1()
    {
        sceneFader.FadeTo("Chapter 1 - Opening");
    }
}
