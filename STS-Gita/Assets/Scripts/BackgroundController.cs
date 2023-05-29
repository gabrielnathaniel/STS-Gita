using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image background1;
    public Image background2;
    public Animator animator;

    int index = 1;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SwitchImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            background2.sprite = sprite;
            animator.SetTrigger("Switch" + index.ToString());
            index++;
        }
        else
        {
            background1.sprite = sprite;
            animator.SetTrigger("Switch" + index.ToString());
            index++;
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            background1.sprite = sprite;
        }
        else
        {
            background2.sprite = sprite;
        }
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
