﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private Rigidbody2D character;
	private bool grounded = false;
	public float maxSpeed;
	public float speed;
	public float jumpForce;
	// Use this for initialization
	void Start () 
	{
		character = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		// enable jump if player is on ground
		if (grounded)
		{
			character.AddForce(Vector2.up * jumpForce);
			grounded = false;
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis ("Horizontal");
		// immediate stop
		if (!Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			move = 0.0f;
			character.velocity = Vector2.zero;
		}
		// movement
		else {
			character.velocity = new Vector2 (move * speed, character.velocity.y);
			character.velocity = Vector2.ClampMagnitude (character.velocity, maxSpeed);
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		// player on ground
		if (coll.gameObject.tag == "Ground" && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)))
			grounded = true;
	}
}
