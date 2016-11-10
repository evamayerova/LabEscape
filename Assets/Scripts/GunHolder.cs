using UnityEngine;
using System.Collections;

public class GunHolder : MonoBehaviour
{

    bool orientation; // true - right oriented, false - left oriented
    Transform weaponTransform;
    Transform firePointTransform;

    // Use this for initialization
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.RightArrow) && !orientation ||
            Input.GetKeyDown(KeyCode.LeftArrow) && orientation)
        {
            orientation = !orientation;
            weaponTransform.position = transform.position - weaponTransform.position + transform.position;
            Debug.Log(firePointTransform.position);
            firePointTransform.position = weaponTransform.position - firePointTransform.position + weaponTransform.position;
        }

    }
}
