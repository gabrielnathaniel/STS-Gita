using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueController : MonoBehaviour
{
    public SceneFader sceneFader;
    public Monologue currentScene;
    public MonologueController monologueBox;
    public BackgroundController backgroundController;

    public string sceneToLoad = "PrologCreditScene";
    // Start is called before the first frame update
    void Start()
    {
        monologueBox.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
        {
            if(monologueBox.IsCompleted())
            {
                if(monologueBox.IsLastSentence())
                {
                    if(currentScene.nextScene == null)
                    {
                        SoundManager.instance.StopSound();
                        sceneFader.FadeTo(sceneToLoad);
                    }
                    currentScene = currentScene.nextScene;
                    monologueBox.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                }
                else
                {
                    monologueBox.PlayNextSentence();
                }
            }
            else 
            {
                monologueBox.CompleteSentence();
            }
        }
    }
}
