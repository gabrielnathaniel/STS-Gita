using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] boxes;
    public GameObject indicator;

    Message[] currentMessages;
    int activeMessage = 0;
    public bool isActive = false;

    private void Awake()
    {
        indicator.SetActive(false);
        foreach (GameObject box in boxes)
        {
            box.SetActive(false);
        }
    }

    public void OpenDialogue(Message[] messages) 
    {
        indicator.SetActive(false);
        currentMessages = messages;
        activeMessage = 0;
        isActive = true;
        boxes[currentMessages[activeMessage].actorId].SetActive(true);

        Debug.Log("Conversation Started" + currentMessages.Length);
        DisplayMessage();
    }

    public void EndDialogue()
    {
        foreach (GameObject box in boxes)
        {
            box.SetActive(false);
        }
        isActive = false;
    }

    void DisplayMessage() 
    {
        Message messageToDisplay = currentMessages[activeMessage];
        int actorId = messageToDisplay.actorId;
        GameObject activeBox = boxes[actorId];
        foreach (GameObject box in boxes)
        {
            box.SetActive(false);
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
