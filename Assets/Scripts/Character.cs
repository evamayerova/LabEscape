using System;
using System.IO;
using System.Collections.Generic;
using System.Web.Helpers;

public class Character
{
    private class Stats
    {
        private int maxHitpoints;
        private float jumpForce;
        private float speed;
    }
    private int currHitpoints;

	public Character(float jumpForce, int maxHitpoints, float speed) 
	{
        // read configuration file
        using (StreamReader r = new StreamReader("Conf/characters.json"))
        {
            string json = r.ReadToEnd();
            dynamic data = Json.Decode(json);
        }
    }
}
