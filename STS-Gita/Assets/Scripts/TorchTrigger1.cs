using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TorchTrigger1 : MonoBehaviour
{
    [SerializeField] GameObject playerDoorIndicator;
    public GameObject glimpse1;
    public PlayableDirector timeline1;

    void Start()
    {
        timeline1 = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDoorIndicator.SetActive(true);
            Debug.Log("Torch Detected");
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
        if(playerDoorIndicator.activeInHierarchy && Input.GetKeyDown(KeyCode.F))
        {
            glimpse1.SetActive(true);
            timeline1.Play();
            this.gameObject.SetActive(false);
        }
    }
}