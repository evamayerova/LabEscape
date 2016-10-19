using UnityEngine;
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
		if (grounded)
		{
			character.AddForce(Vector2.up * jumpForce);
			grounded = false;
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis("Horizontal");
		character.velocity = new Vector2 (move * speed, character.velocity.y);

		if (character.velocity.x > maxSpeed)
			character.velocity = new Vector2 (maxSpeed, character.velocity.y);

		if (character.velocity.x < -maxSpeed)
			character.velocity = new Vector2 (-maxSpeed, character.velocity.y);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground" && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)))
			grounded = true;
	}
}
