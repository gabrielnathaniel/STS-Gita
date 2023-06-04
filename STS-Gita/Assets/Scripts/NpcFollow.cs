using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFollow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float targetDistance;
    [SerializeField] GameObject player;
    Rigidbody2D npcRigidBody;
    Animator animator;
    Transform target;

    void Start()
    {
        animator = GetComponent<Animator>();
        npcRigidBody = GetComponent<Rigidbody2D>();
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        FlipSprite();
    }

    void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > targetDistance)
        {
            // To trigger npc animation
            float horizontalMove = Input.GetAxisRaw("Horizontal") * 40f;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // else
        // {
        //     animator.SetBool("isWalking", false);
        // }
    }

    void FlipSprite()
    {
        if (player.transform.position.x > transform.position.x)
        {
            // Face right
            transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        }   
        else
        {
            // Face left
            transform.localScale = new Vector3(-1.7f, 1.7f, 1.7f);
        }
    }
}
