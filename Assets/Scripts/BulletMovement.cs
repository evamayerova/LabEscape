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
        destination = startPosition + direction * distance;
	}
	
	// Update is called once per frame
	void Update () {
        if (remaining < 0.1f)
        {
            Debug.Log("Destroying bullet");
            Destroy(gameObject);
        }
        
        Vector2 newPos = Vector2.MoveTowards(rb2d.position, destination, speed * Time.deltaTime);
        rb2d.MovePosition(newPos);
        remaining = direction.x > 0 ? destination.x - newPos.x : newPos.x - destination.x;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
