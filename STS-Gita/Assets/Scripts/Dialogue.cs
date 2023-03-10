using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //Fields
    public DialogueTrigger trigger;
    //Box
    public GameObject box;
    //Indicator
    public GameObject indicator;
    //Text component
    public Text dialogueText;
    //Dialogues list
    public List<string> dialogues;
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleBox(false);
        ToggleIndicator(false);
    }

    private void ToggleBox(bool show)
    {
        box.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }


    //Start Dialogue
    public void StartDialogue()
    {
        Debug.Log("start");
        if(started)
            return;

        //Boolean to indicate that we have started
        started = true;
        //Show the window
        ToggleBox(true);
        //Hide the indicator
        ToggleIndicator(false);
        //Start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        Debug.Log("get" + index);
        //Start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //Clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writing
        StartCoroutine(Typing());
    }

    //End Dialogue
    public void EndDialogue()
    {
        Debug.Log("end");
        //Started is disabled
        started = false;
        //Disable wait for next
        waitForNext = false;
        //Stop all ienumerators
        StopAllCoroutines();
        //Hide the window
        ToggleBox(false);
    }

    //Typing Logic
    IEnumerator Typing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //Writing the character
        dialogueText.text += currentDialogue[charIndex];
        //Increase the character index
        charIndex++;
        //Make sure you have reached the end of sentence
        if(charIndex < currentDialogue.Length)
        {
            //Wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //Restart the same process
            StartCoroutine(Typing());
        }
        else
        {
            //End this sentence and wait for the next one
            waitForNext = true;
        }
        
    }

    private void Update()
    {
        if(!started)
        {
            return;
        }

        if(waitForNext && Input.GetKeyDown(KeyCode.F))
        {
            waitForNext = false;
            index++;

            //Check if we are in the scope of dialogues List
            if(index < dialogues.Count)
            {
                Debug.Log("update get");
                //If so, fetch the next dialogue
                GetDialogue(index);
            }
            else
            {
                Debug.Log("update end");
                //If not, end the dialogue process
                ToggleIndicator(true);
                EndDialogue();

            }
        }
    }

}