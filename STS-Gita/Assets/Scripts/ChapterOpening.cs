using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterOpening : MonoBehaviour
{
    public SceneFader sceneFader;

    public string sceneToLoad = "Prolog";
    
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Completed());
    }

    IEnumerator Completed()
    {
        yield return new WaitForSeconds(2);
        sceneFader.FadeTo(sceneToLoad);
    }
}
