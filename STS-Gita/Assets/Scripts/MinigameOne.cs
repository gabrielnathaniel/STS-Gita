using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameOne : MonoBehaviour
{
    public Canvas minigame2;
    public GameObject dialogueBox;
    public AudioSource audioSource;

    public void Button1()
    {
        StartCoroutine(Show());
    }

    public void Button2()
    {
        //Benar
        Debug.Log("Benar");
        this.gameObject.SetActive(false);
        minigame2.gameObject.SetActive(true);
    }

    public void Button3()
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
