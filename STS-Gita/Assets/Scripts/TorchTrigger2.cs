using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TorchTrigger2 : MonoBehaviour
{
    [SerializeField] GameObject playerDoorIndicator;
    public GameObject glimpse2;
    public PlayableDirector timeline2;

    void Start()
    {
        timeline2 = GetComponent<PlayableDirector>();
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
            glimpse2.SetActive(true);
            timeline2.Play();
            this.gameObject.SetActive(false);
        }
    }
}