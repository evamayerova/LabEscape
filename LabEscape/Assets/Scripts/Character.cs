using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private Rigidbody2D character;
	public float maxSpeed = 10f;
	public bool jumpPushed = false;
	// Use this for initialization
	void Start () 
	{
		character = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis("Horizontal");
		character.velocity = new Vector2 (move * maxSpeed, character.velocity.y); 
		/*if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) 
		{

			if (!jumpPushed) 
			{
				character.AddForce(Vector2.up * 300);
				jumpPushed = true;
				return;
			}

		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.UpArrow)) {
			jumpPushed = false;
		}*/
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground" && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)))
		{
			character.AddForce(Vector2.up * 450);
		}
	}
}
