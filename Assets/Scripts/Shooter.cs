using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public Sprite sprite;
    public float bulletSpeed = 25.0f;
    public int damage = 10;
    public float range = 5.0f;
    public LayerMask toShoot;
    Transform firePointTransform;
    Vector2 playerPosition;

	void Start () {
        Debug.Log(toShoot.value);
        Debug.Log(LayerMask.GetMask("Enemy"));
        Debug.Log("defining firepoint transform");  
        firePointTransform = transform.FindChild("FirePoint");
    }

	void Update () {
        playerPosition = gameObject.GetComponentInParent<Transform>().position;
    }

    public void shoot()
    {
        Vector2 destination = new Vector2(firePointTransform.position.x > playerPosition.x ? firePointTransform.position.x + range : (-firePointTransform.position.x - range), playerPosition.y);
        Vector2 direction = destination - new Vector2(firePointTransform.position.x, firePointTransform.position.y);

        Bullet b = new Bullet(firePointTransform.position, direction.normalized, sprite, toShoot, range, bulletSpeed, damage);
    }
}
