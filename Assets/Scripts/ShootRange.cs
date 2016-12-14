using UnityEngine;
using System.Collections;

public class ShootRange : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Player")
			Debug.Log ("player is in shoot range");
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.tag == "Player")
			Debug.Log ("player exit shoot range");
	}
}
