﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovementController : MonoBehaviour
{

	private Rigidbody2D rigidboy;

	public float maxSpeed = 2f;
	public float jumpForce = 2f;

	public Transform fallDeathCheck;
	public Transform finishCheck;

	public bool facingRight = true;

	private GameObject gameManager;
	private DogRespawnableController respawnController;

	public bool isGrounded = false;

	private Animator animationController;

	private AudioManager audioManager;

	// Use this for initialization
	void Start()
	{
		this.rigidboy = gameObject.GetComponent<Rigidbody2D>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		respawnController = gameManager.GetComponent<DogRespawnableController>();
		animationController = gameObject.GetComponent<Animator>();

		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("No audiomanager found in Scene.");
		}

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		animationController.SetBool("Grounded", isGrounded);

		if (!isGrounded && rigidboy.velocity.y == 0f)
		{
			isGrounded = true;
		}

		if (gameObject.transform.position.y <= fallDeathCheck.position.y)
		{
			respawnController.resetGame();
		}
		else if (gameObject.transform.position.x >= finishCheck.position.x)
		{
			++DogScore.dogScore;			
			respawnController.resetGame();
		}

		//If there's any vertical movement (e.g: right of left arrow pressed
		float move = Input.GetAxis("HorizontalDog");

		//Add vertical velocity
		this.rigidboy.velocity = new Vector2(move * maxSpeed, this.rigidboy.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if (move > 0 && !facingRight)
		{
			// ... flip the player.
			flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0 && facingRight)
		{
			// ... flip the player.
			flip();
		}

		//if Jump button is pressed
		if (Input.GetButtonDown("JumpDog") && isGrounded)
		{

			//Add vertical force to the character
			rigidboy.velocity = new Vector2(0, jumpForce);
			isGrounded = false;

		}

	}
	protected void flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("OnCollisionEnter2D called.");
		if (coll.gameObject.tag == "Death")
		{
			respawnController.resetGame();
		}
	}
}
