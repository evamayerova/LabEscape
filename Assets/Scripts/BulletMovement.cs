using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float distance = 5.0f;
    public float speed;
    public int damage;
    public Vector2 startPosition, direction;
    public LayerMask toShoot;
    Vector2 destination;
    Rigidbody2D rb2d;
    float remaining;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        remaining = distance;
        rb2d.position = startPosition;
        rb2d.gravityScale = 0.0f;
        destination = startPosition + direction * distance;
	}
	
	// Update is called once per frame
	void Update () {
        if (remaining < 0.1f) {
            Destroy(gameObject);
        }
        
        Vector2 newPos = Vector2.MoveTowards(rb2d.position, destination, speed * Time.deltaTime);
        rb2d.MovePosition(newPos);
        remaining = direction.x > 0 ? destination.x - newPos.x : newPos.x - destination.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (toShoot == (toShoot | 1 << contact.collider.gameObject.layer)) {
                // TODO target object has to take damage
                Debug.Log(collision.gameObject.name);
                Character hitChar = collision.gameObject.GetComponent<Character>();

                hitChar.changeHealth(-damage);
                Debug.Log("COLISION");
            }
            Destroy(gameObject);
        }
    }
}
