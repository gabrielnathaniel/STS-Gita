using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject indicator;
    public float textSpeed = 0.05f;
    Message[] currentMessages;
    Actor[] currentActors;
    int index = 0;
    public bool isActive = false;

    private Message activeMessage;
    private int activeActorId;
    private Actor activeActor;
    private GameObject activeBox;
    private Text textComponent;

    public bool isMinigame = false;

    public Canvas minigame1;

    [SerializeField] private AudioClip sound;

    public void OpenDialogue(Message[] messages, Actor[] actors) 
    {
        indicator.SetActive(false);
        currentMessages = messages;
        currentActors = actors;
        index = 0;
        isActive = true;
        actors[currentMessages[index].actorId].box.SetActive(true);

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
        SoundManager.instance.StopSound();

        if(isMinigame == true)
        {
            minigame1.gameObject.SetActive(true);
        }
    }

    void DisplayMessage() 
    {
        activeMessage = currentMessages[index];
        activeActorId = activeMessage.actorId;
        activeActor = currentActors[activeActorId];

        activeBox = activeActor.box;
        foreach (Actor actor in currentActors)
        {
            actor.box.SetActive(false);
        }
        activeBox.SetActive(true);

        textComponent = activeBox.transform.Find("DialogueBox/DialogueText").GetComponent<Text>();
        textComponent.text = string.Empty;
        SoundManager.instance.PlaySound(sound);
        StartCoroutine(TypeLine(activeMessage, textComponent));
    }

    void NextMessage()
    {
        index++;
        if (index < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            EndDialogue();
            Debug.Log("Conversation Ended");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isActive)
        {
            if (textComponent.text == activeMessage.message)
            {
                NextMessage();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = activeMessage.message;
                SoundManager.instance.StopSound();
            }
        }
        
    }

    IEnumerator TypeLine(Message message, Text text)
    {
        foreach(char c in message.message.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        SoundManager.instance.StopSound();
    }
}
