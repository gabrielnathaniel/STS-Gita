using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterOpening : MonoBehaviour
{
    public SceneFader sceneFader;

    public string sceneToLoad = "Prolog";
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Completed());
    }

    IEnumerator Completed()
    {
        yield return new WaitForSeconds(3);
        sceneFader.FadeTo(sceneToLoad);
    }
}
