using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIfAchReached : MonoBehaviour {

	Rigidbody2D rigidboy;

	bool isGrounded = false;

	Animator animationController;

	public string achiName;

	public float jumpForce;

	// Use this for initialization
	void Start () {
		animationController = gameObject.GetComponent<Animator>();
		rigidboy = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		animationController.SetBool("Grounded", isGrounded);

		if (!isGrounded && rigidboy.velocity.y == 0f)
		{
			isGrounded = true;
		}

		if (isGrounded == true && PlayerPrefs.GetInt(achiName) != 0)
		{
			rigidboy.velocity = new Vector2(0, jumpForce);
			isGrounded = false;
		}
	}
}
