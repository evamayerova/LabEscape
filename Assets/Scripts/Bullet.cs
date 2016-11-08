﻿using UnityEngine;
using System.Collections;

public class Bullet {

    // Use this for initialization
    public SpriteRenderer bulet_spriteRenderer;
    public GameObject bullet;

    public Bullet(Vector2 orig, Vector2 dir, Sprite sprite, float distance = 5.0f, float speed = 10.0f)
    {
        bullet = new GameObject();
        SpriteRenderer sr = bullet.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        bullet.AddComponent<Rigidbody2D>();
        BulletMovement bm = bullet.AddComponent<BulletMovement>();
        bm.distance = distance;
        bm.speed = speed;
        bm.startPosition = orig;
        bm.direction = dir;
    }
}