using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    [SerializeField] GameObject playerDoorIndicator;
    public GameObject glimpse;

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
            glimpse.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}