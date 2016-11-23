using UnityEngine;
using System.Collections;

public class Enemy : Character {

    const string defaultCharType = "technican";
    public float watchRange;

    // private CircleCollider2D rangeToWatch;
    // private BoxCollider2D rangeToShoot;
    // Use this for initialization
    void Start () {
        MoveDir = 1.0f;
        CharacterType = defaultCharType;
        setDefaultStats();
        // rangeToWatch = gameObject.AddComponent<CircleCollider2D>();
        // rangeToWatch.isTrigger = true;
        // rangeToWatch.radius = 5.0f;// watchRange;
        // rangeToShoot = gameObject.AddComponent<BoxCollider2D>();
        // rangeToShoot.size = new Vector2(2.0f, 1.0f);
        // rangeToShoot.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponentInChildren<Shooter>().shoot();
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("Circle collider " + c.name);
    }
}
