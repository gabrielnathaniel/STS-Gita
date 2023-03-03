// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     [SerializeField]
//     GameObject player;

//     [SerializeField]
//     float timeOffset;

//     [SerializeField]
//     Vector2 posOffset;

//     [SerializeField]
//     float leftLimit;
//     [SerializeField]
//     float rightLimit;
//     [SerializeField]
//     float topLimit;
//     [SerializeField]
//     float bottomLimit;

//     private Vector3 velocity;

//     // Update is called once per frame
//     void Update()
//     {
//         //Camera current position
//         Vector3 startPos = transform.position;

//         //Player current position
//         Vector3 endPos = player.transform.position;

//         endPos.x = posOffset.x;
//         endPos.y = posOffset.y;
//         endPos.z = -10;

//         //Smoothly move the camera toward player position
//         transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);


//         transform.position = new Vector3
//         (
//             Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
//             Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
//             transform.position.z
//         );
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public Transform target;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float topLimit;
    [SerializeField]
    float bottomLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }
}