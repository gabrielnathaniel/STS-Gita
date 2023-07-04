using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TorchTrigger3 : MonoBehaviour
{
    [SerializeField] GameObject playerDoorIndicator;
    public GameObject glimpse3;
    public GameObject glimpseDialogue3;

    void Start()
    {

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
            glimpse3.SetActive(true);
            glimpseDialogue3.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}