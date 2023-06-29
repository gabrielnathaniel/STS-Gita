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

    public void OpenChapter2()
    {
        sceneFader.FadeTo("Chapter 2 - Opening");
    }

    public void OpenChapter3()
    {
        sceneFader.FadeTo("Chapter 3 - Opening");
    }

    public void OpenChapter4()
    {
        sceneFader.FadeTo("Chapter 4 - Hall");
    }

    public void OpenChapter5()
    {
        sceneFader.FadeTo("Chapter 5 - Opening");
    }
}
