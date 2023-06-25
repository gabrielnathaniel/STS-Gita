using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to fix flipped dialog when character is flipped
public class FixedScale : MonoBehaviour
{
    public GameObject parent;
    public float FixScale = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(FixScale/parent.transform.localScale.x,FixScale/parent.transform.localScale.y,FixScale/parent.transform.localScale.z);
    }
}
