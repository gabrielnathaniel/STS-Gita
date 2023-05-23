using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCutscene : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Message[] messages;
    public Actor[] actors;

    private void Update()
    {
        dialogueManager.OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Messages
{
    public string messages;
    public int actorsId;
}

[System.Serializable]
public class Actors
{
    public GameObject box;
}