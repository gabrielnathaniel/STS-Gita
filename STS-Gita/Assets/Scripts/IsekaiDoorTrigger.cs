using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsekaiDoorTrigger : MonoBehaviour
{
    public GameObject isekaiDoorTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isekaiDoorTrigger.SetActive(true);
        }
    }
}
