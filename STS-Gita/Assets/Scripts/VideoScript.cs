using System.Collections;
using UnityEngine;
using UnityEngine.Video;
 
public class VideoScript : MonoBehaviour
{
 
     public VideoPlayer video;
     public SceneFader sceneFader;
     public string sceneToLoad = "MainMenu";
 
    void Awake()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        yield return new WaitForSeconds(2);
        video.loopPointReached += CheckOver;
    }
 
     void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        sceneFader.FadeTo(sceneToLoad);//the scene that you want to load after the video has ended.
    }
}