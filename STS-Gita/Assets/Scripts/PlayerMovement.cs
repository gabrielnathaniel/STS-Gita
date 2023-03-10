// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     private float horizontal;
//     private float speed = 8f;
//     private float jumpingPower = 16f;
//     private bool isFacingLeft = false;

//     [SerializeField] private Rigidbody2D rb;
//     [SerializeField] private Transform groundCheck;
//     [SerializeField] private LayerMask groundLayer;

//     void Update()
//     {
//         horizontal = Input.GetAxisRaw("Horizontal");

//         if (Input.GetButtonDown("Jump") && IsGrounded())
//         {
//             rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
//         }

//         if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
//         {
//             rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
//         }

//         Flip();
//     }

//     private void FixedUpdate()
//     {
//         rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
//     }

//     private bool IsGrounded()
//     {
//         return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
//     }

//     private void Flip()
//     {
//         if (isFacingLeft && horizontal > 0f || !isFacingLeft && horizontal < 0f)
//         {
//             isFacingLeft = !isFacingLeft;
//             Vector3 localScale = transform.localScale;
//             localScale.x *= -1f;
//             transform.localScale = localScale;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
            Debug.Log("jump");
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}