using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueController : MonoBehaviour
{
    public Text monologueText;

    private int sentenceIndex = -1;
    public Monologue currentScene;

    [SerializeField] private AudioClip sound;

    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(Monologue scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }
    
    // Start is called before the first frame update
    public void PlayNextSentence()
    {
        if(currentScene.nextScene != null)
        {
            SoundManager.instance.PlaySound(sound);   
        }
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    public void CompleteSentence()
    {
        StopAllCoroutines();
        monologueText.text = currentScene.sentences[sentenceIndex].text;
        SoundManager.instance.StopSound();
        state = State.COMPLETED;
    }

    private IEnumerator TypeText(string text)
    {
        monologueText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while(state != State.COMPLETED)
        {
            monologueText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                SoundManager.instance.StopSound();
                break;
            }
        }
    }
}
