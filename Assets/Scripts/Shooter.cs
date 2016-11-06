﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public Sprite sprite;
    public float bulletSpeed = 25.0f;
    public float damage = 10.0f;
    public float range = 5.0f;
    public LayerMask toShoot;
    Transform firePointTransform;
    Vector2 playerPosition;
    float epsilon = 0.01f;

	void Start () {
        Debug.Log("defining firepoint transform");  
        firePointTransform = transform.FindChild("FirePoint");
    }

	void Update () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        if (firePointTransform == null)
        {
            Debug.LogError("No firepoint");
        }
        if (Input.GetKeyDown(KeyCode.RightControl)) {
            Vector2 destination = new Vector2(playerPosition.x + firePointTransform.position.x > playerPosition.x ? firePointTransform.position.x + range : (-firePointTransform.position.x -range), playerPosition.y);
            Vector2 direction = destination - new Vector2(firePointTransform.position.x, firePointTransform.position.y);

            Bullet b = new Bullet(firePointTransform.position, direction, sprite, range, bulletSpeed);
        }
    }
}
