using UnityEngine;
using System.Collections;

public class Enemy : Character {

    const string defaultCharType = "technican";

	private GameObject hearing, shooting;
	private CircleCollider2D rangeToWatch;
    private BoxCollider2D rangeToShoot;
    // Use this for initialization
    void Start () {
        MoveDir = 1.0f;
        CharacterType = defaultCharType;
        setDefaultStats();

		hearing = new GameObject ();
		shooting = new GameObject ();
		setRangeParams(hearing, "c", HearingRange, "Watch Range Collider");
		setRangeParams(shooting, "b", ShootingRange, "Shoot Range Collider");
	}

	void setRangeParams(GameObject go, string type, float range, string name)
	{
		go.transform.parent = gameObject.transform;
		go.transform.position = gameObject.transform.position;
		go.name = name;
		switch(type)
		{
		case "c":
		{
			// hearing area
			rangeToWatch = go.AddComponent<CircleCollider2D>();
			rangeToWatch.radius = HearingRange;
			rangeToWatch.isTrigger = true;
			go.AddComponent<WatchRange>();
		}
			break;
		case "b":
		{
			// shooting area
			rangeToShoot = go.AddComponent<BoxCollider2D>();
			rangeToShoot.size = new Vector2(ShootingRange, 1.0f);
			rangeToShoot.isTrigger = true;
			go.AddComponent<ShootRange>();
		}
			break;
		}
	}
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponentInChildren<Shooter>().shoot();
	}

    public override void die()
    {
        Debug.Log("Enemy died");
    }
}
