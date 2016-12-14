using UnityEngine;
using System.Collections;

public class WatchRange : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Player")
			Debug.Log ("player is in watch range");
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.tag == "Player")
			Debug.Log ("player exit watch range");
	}
}
