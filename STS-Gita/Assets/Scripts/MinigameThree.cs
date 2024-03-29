using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MinigameThree : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject dialogueBox;
    public SceneFader sceneFader;

    public string sceneToLoad = "Chapter 1 - Classroom2";

    public PlayableDirector playableDirector;

    public void Button1_3()
    {
        //Benar
        this.gameObject.SetActive(false);
        // sceneFader.FadeTo(sceneToLoad);
        playableDirector.Play();
    }

    public void Button2_3()
    {
        StartCoroutine(Show());
    }

    public void Button3_3()
    {
        StartCoroutine(Show());
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    IEnumerator Show()
    {
        dialogueBox.SetActive(true);

        yield return new WaitForSeconds(2);
        dialogueBox.SetActive(false);
    }
}