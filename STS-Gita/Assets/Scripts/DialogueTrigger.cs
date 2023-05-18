using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Message[] messages;
    public Actor[] actors;

    public void ShowDialogueIndicator()
    {
        // indicator.SetActive(true);
       dialogueManager.indicator.SetActive(true);
    }

    public void HideDialogueIndicator()
    {
        // indicator.SetActive(false);
        dialogueManager.indicator.SetActive(false);
    }

    //While detected if we interact start the dialogue
    private void Update()
    {
        if(dialogueManager.indicator.activeInHierarchy && Input.GetKeyDown(KeyCode.F) && !dialogueManager.isActive)
        {
            dialogueManager.OpenDialogue(messages, actors);
        }
    }
}

[System.Serializable]
public class Message 
{
    public string message;
    public int actorId;
}

[System.Serializable]
public class Actor 
{
    public GameObject box;
}