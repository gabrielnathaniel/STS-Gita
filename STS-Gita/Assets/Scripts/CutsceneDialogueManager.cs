using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutsceneDialogueManager : MonoBehaviour
{
    
    [SerializeField] Message[] messages;
    [SerializeField] Actor[] actors;
    [SerializeField] PlayableDirector timeline;
    int index = 0;
    public bool isActive = false;
    public float textSpeed = 0.05f;

    private Message activeMessage;
    private int activeActorId;
    private Actor activeActor;
    private GameObject activeBox;
    private Text textComponent;

    [SerializeField] private AudioClip sound;

    public void StartDialogue()
    {
        Debug.Log("Should start cutscene Dialog");
        isActive = true;
        timeline.Pause();
        DisplayMessage();
    }

    public void EndDialogue()
    {
        foreach (Actor actor in actors)
        {
            actor.box.SetActive(false);
        }
        isActive = false;
        timeline.Resume();
        SoundManager.instance.StopSound();
    }

    void DisplayMessage() 
    {
        activeMessage = messages[index];
        activeActorId = activeMessage.actorId;
        activeActor = actors[activeActorId];

        Debug.Log(activeMessage.message);

        activeBox = activeActor.box;
        foreach (Actor actor in actors)
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
        if (index < messages.Length)
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
