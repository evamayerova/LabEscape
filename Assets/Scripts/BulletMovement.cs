using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float distance = 5.0f;
    public float speed;
    public Vector2 startPosition, direction;
    Vector2 destination;
    Rigidbody2D rb2d;
    float remaining;

    // Use this for initialization
    void Start () {
        Debug.Log("Start of BulletMovement component");
        rb2d = GetComponent<Rigidbody2D>();
        remaining = distance;
        rb2d.position = startPosition;
        rb2d.gravityScale = 0.0f;
        destination = startPosition + direction.normalized * distance;
	}
	
	// Update is called once per frame
	void Update () {
        if (remaining < 0.1f)
        {
            Debug.Log("Destroying bullet");
            Destroy(gameObject);
        }

        Debug.Log("Rigid body position " + rb2d.position + ", destination " + destination);
        Vector2 newPos = Vector2.MoveTowards(rb2d.position, destination, speed * Time.deltaTime);
        rb2d.MovePosition(newPos);
        remaining = destination.x - newPos.x;
    }
}
