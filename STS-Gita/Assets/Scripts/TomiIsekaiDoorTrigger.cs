using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomiIsekaiDoorTrigger : MonoBehaviour
{
    public GameObject tomiIsekaiDoorTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameObject.FindGameObjectsWithTag("Glimpse").Length == 3)
        {
            tomiIsekaiDoorTrigger.SetActive(true);
        }
    }
}
