using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameTwo : MonoBehaviour
{
    public Canvas minigame3;
    public GameObject dialogueBox;
    public AudioSource audioSource;

    public void Button1_2()
    {
        StartCoroutine(Show());
    }

    public void Button2_2()
    {
        StartCoroutine(Show());
    }

    public void Button3_2()
    {
        //Benar
        this.gameObject.SetActive(false);
        minigame3.gameObject.SetActive(true);
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