using UnityEngine;
using System.Collections;
using System;

public class Player : Character {

	private Rigidbody2D rigidBody2D;

    const string defaultCharType = "cat";

	// Use this for initialization
	void Start () 
	{
        rigidBody2D = GetComponent<Rigidbody2D> ();
        CharacterType = defaultCharType;
        setDefaultStats();
    }

	void Update()
	{
		// enable jump if player is on ground
		if (Grounded)
		{
			rigidBody2D.AddForce(Vector2.up * JumpForce);
			Grounded = false;
		}

        if (Input.GetButtonDown("Simple Bullet"))
        {
            gameObject.GetComponentInChildren<Shooter>().shoot();
        }
    }
	// Update is called once per frame
	void FixedUpdate () 
	{
		MoveDir = Input.GetAxis ("Horizontal");
        // static movement
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody2D.velocity = new Vector2(MoveDir * Speed, rigidBody2D.velocity.y);
        }
        else
            rigidBody2D.velocity = new Vector2(0.0f, rigidBody2D.velocity.y);

		// fluent start, immediate stop
		/*if (!Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) 
		{
			move = 0.0f;
			rigidBody2D.velocity = new Vector2 (0.0f, rigidBody2D.velocity.y);
		}
		// movement
		else {
			rigidBody2D.velocity = new Vector2 (move * speed, rigidBody2D.velocity.y);
			rigidBody2D.velocity = Vector2.ClampMagnitude (rigidBody2D.velocity, maxSpeed);
		}*/
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		// player on ground
		if (coll.gameObject.tag == "Ground" && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)))
			Grounded = true;
	}

    void OnTriggerEnter2D(Collider2D c)
 	{
 		// if trigger object is pickable, add item to inventory
 		if (c.gameObject.tag == "Pick Up") {
 			c.gameObject.SetActive (false);
            // TODO add object into inventory class
 			//rigidBody2D.GetComponent<Inventory>().AddObject(c.name);
 		}
 	}
}
