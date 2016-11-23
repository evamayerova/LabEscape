using UnityEngine;
using System.Collections;

public class GunHolder : MonoBehaviour
{

    bool orientation; // true - right oriented, false - left oriented
    Transform weaponTransform;
    Transform firePointTransform;
    Character character;

    // Use this for initialization
    void Start()
    {
        character = gameObject.GetComponent<Character>();
        if (!character)
            Debug.LogError("No character");
        weaponTransform = transform.FindChild("Weapon");
        if (weaponTransform == null)
            Debug.Log("No weapon found");
        firePointTransform = weaponTransform.FindChild("FirePoint");
        if (firePointTransform == null)
            Debug.Log("No firepoint found");

        Debug.Log(firePointTransform.position);
        orientation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // player is now oriented left and right arrow is pressed or opposite
        //Character.MoveDi = Input.GetAxis("Horizontal");

        if (character.MoveDir < 0.0f && orientation || character.MoveDir > 0.0f && !orientation)
        // move left
        {
            orientation = !orientation;
            weaponTransform.position = transform.position - weaponTransform.position + transform.position;
            firePointTransform.position = weaponTransform.position - firePointTransform.position + weaponTransform.position;
        }

    }
}
