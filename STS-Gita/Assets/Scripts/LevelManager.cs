using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public SceneFader sceneFader;
    int levelsUnlocked;
    [SerializeField] Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CompleteLevel(int index)
    {
        int unlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        if (index > unlocked)
        {
            PlayerPrefs.SetInt("levelsUnlocked", index);
        } 
    }
}
