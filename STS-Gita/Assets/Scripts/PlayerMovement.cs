using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public Rigidbody2D rb;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	private bool canDash = true;
	private bool isDashing;
	private float dashingPower = 15f;
	private float dashingTime = 0.2f;
	private float dashingCooldown = 1f;

	public bool isInDialogue = false;
	[SerializeField] private PlayableDirector timeline;

	
	// Update is called once per frame
	void Update () {
		if (isInDialogue == true)
			return;
		
		if (timeline != null) 
		{
			if (timeline.state == PlayState.Playing) 
				return;
		}

		if(isDashing)
		{
			return;
		}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
		{
			StartCoroutine(Dash());
		}
	}

	void FixedUpdate ()
	{
		if(isDashing)
		{
			return;
		}

		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	private IEnumerator Dash()
	{
		animator.SetTrigger("Dash");
		canDash = false;
		isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

		yield return new WaitForSeconds(dashingTime);

		rb.gravityScale = originalGravity;
		isDashing = false;

		yield return new WaitForSeconds(dashingCooldown);
		canDash = true;
	}
}