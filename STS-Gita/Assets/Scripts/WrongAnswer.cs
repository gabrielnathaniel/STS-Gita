using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public static Animator animator;
    public static void Transition()
    {
        animator.SetTrigger("Wrong");
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
