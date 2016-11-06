using UnityEngine;
using System.Collections;
using System;

public class CharacterFollower : MonoBehaviour {

    private Transform camTransform, playerTransform;
    private Vector2 sceneBounds;
    private Vector2 screenBounds;
    private float sceneBoundOffset = 0.5f;

	// Use this for initialization
	void Start () {
        camTransform = GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        sceneBounds = new Vector2(GameObject.Find("Start").GetComponent<Transform>().position.x +
                                        GameObject.Find("Start").GetComponent<Transform>().localScale.x * 0.5f,
                                  GameObject.Find("Finish").GetComponent<Transform>().position.x -
                                        GameObject.Find("Finish").GetComponent<Transform>().localScale.x * 0.5f);
    }
	
	// Update is called once per frame
	void Update () {

        if (playerTransform.position.x - screenBounds.x * sceneBoundOffset >= sceneBounds.x && playerTransform.position.x + screenBounds.x * sceneBoundOffset <= sceneBounds.y)
        {
            camTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, camTransform.position.z);
        }
        else if (playerTransform.position.x - screenBounds.x * sceneBoundOffset < sceneBounds.x)
        {
            camTransform.position = new Vector3(sceneBounds.x + screenBounds.x * sceneBoundOffset, playerTransform.position.y, camTransform.position.z);
        }
        else if (playerTransform.position.x + screenBounds.x * sceneBoundOffset > sceneBounds.y)
        {
            camTransform.position = new Vector3(sceneBounds.y - screenBounds.x * sceneBoundOffset, playerTransform.position.y, camTransform.position.z);
        }


    }
}
