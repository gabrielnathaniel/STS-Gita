using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject indicator;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors) 
    {
        indicator.SetActive(false);
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        actors[currentMessages[activeMessage].actorId].box.SetActive(true);

        Debug.Log("Conversation Started" + currentMessages.Length);
        DisplayMessage();
    }

    public void EndDialogue()
    {
        foreach (Actor actor in currentActors)
        {
            actor.box.SetActive(false);
        }
        isActive = false;
    }

    void DisplayMessage() 
    {
        Message messageToDisplay = currentMessages[activeMessage];
        int actorId = messageToDisplay.actorId;
        Actor actorToDisplay = currentActors[actorId];

        GameObject activeBox = actorToDisplay.box;
        foreach (Actor actor in currentActors)
        {
            actor.box.SetActive(false);
        }
        activeBox.SetActive(true);

        activeBox.transform.Find("DialogueBox/DialogueText").GetComponent<Text>().text = messageToDisplay.message;
    }

    void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            EndDialogue();
            Debug.Log("Conversation Ended");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActive)
        {
            NextMessage();
        }
        
    }
}
