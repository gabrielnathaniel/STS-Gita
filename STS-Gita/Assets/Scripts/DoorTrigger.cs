using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject playerDoorIndicator;
    public SceneFader sceneFader;
    public string sceneToLoad = "Chapter 1 - Classroom";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDoorIndicator.SetActive(true);
            Debug.Log("Door Detected");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDoorIndicator.SetActive(false);
        }
    }

    private void Update()
    {
        if(playerDoorIndicator.activeInHierarchy && Input.GetKeyDown(KeyCode.UpArrow))
        {
            sceneFader.FadeTo(sceneToLoad);
        }
    }
}
