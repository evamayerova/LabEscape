using System;
using System.IO;
using UnityEngine;

public class Character
{
    private int maxHitpoints;
    private float jumpForce;
    private float speed;
    private int currHitpoints;
    private string characterType;


    private JSONObject readConfig()
    {
        using (StreamReader r = new StreamReader("Assets/Conf/characters.json"))
        {
            string json = r.ReadToEnd();
            JSONObject j = new JSONObject(json);

            if (!j[characterType])
            {
                Debug.LogError("No entry named " + characterType);
            }
            return j[characterType];
        }
    }

	public Character(string charType)//float jumpForce, int maxHitpoints, float speed) 
	{
        characterType = charType;

        // read configuration file
        JSONObject entry = readConfig();
        maxHitpoints = Int32.Parse(entry["maxHitpoints"].ToString());
        jumpForce = float.Parse(entry["jumpForce"].ToString());
        speed = float.Parse(entry["speed"].ToString());
        currHitpoints = maxHitpoints;
    }

    void changeHealth(int offset)
    {
        currHitpoints += offset;
    }
}
