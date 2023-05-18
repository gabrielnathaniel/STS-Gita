using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScale : MonoBehaviour
{
    public GameObject parent;
    public float FixScale = 0.75f;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(FixScale/parent.transform.localScale.x,FixScale/parent.transform.localScale.y,FixScale/parent.transform.localScale.z);
    }
}
