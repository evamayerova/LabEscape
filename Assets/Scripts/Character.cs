using System;
using System.IO;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int maxHitpoints;
    private float jumpForce;
    private float speed;
	private int currHitpoints;
	private string texName;
	private float hearingRange;
	private float shootingRange;
    private string characterType;
    private float moveDir;
    private bool grounded = false;

    private JSONObject readConfig()
    {

        using (StreamReader r = new StreamReader("Assets/Conf/characters.json"))
        {
            string json = r.ReadToEnd();
            JSONObject j = new JSONObject(json);

            if (!j[CharacterType])
            {
                Debug.LogError("No entry named " + CharacterType);
            }
            return j[CharacterType];
        }
    }

    protected void setDefaultStats()
    {
        JSONObject entry = readConfig();
        MaxHitpoints = Int32.Parse(entry["maxHitpoints"].ToString());
        JumpForce = float.Parse(entry["jumpForce"].ToString());
        Speed = float.Parse(entry["speed"].ToString());
		TexName = entry ["texture"].ToString ();
		HearingRange = float.Parse(entry["hearingRange"].ToString());
		ShootingRange = float.Parse(entry["shootingRange"].ToString());
        //Debug.Log("Speed " + Speed);
        CurrHitpoints = MaxHitpoints;
    }

	public Character()//float jumpForce, int maxHitpoints, float speed) 
	{
                
    }

    public void changeHealth(int offset)
    {
        CurrHitpoints += offset;
        if (CurrHitpoints <= 0)
        {
            die();
            Destroy(gameObject);
        }
    }

    void die()
    {
        Debug.Log("I am dead");
    }

    public int MaxHitpoints
    {
        get
        {
            return maxHitpoints;
        }

        set
        {
            maxHitpoints = value;
        }
    }

    public float JumpForce
    {
        get
        {
            return jumpForce;
        }

        set
        {
            jumpForce = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int CurrHitpoints
    {
        get
        {
            return currHitpoints;
        }

        set
        {
            currHitpoints = value;
        }
    }

    public string CharacterType
    {
        get
        {
            return CharacterType1;
        }

        set
        {
            CharacterType1 = value;
        }
    }

    public float MoveDir
    {
        get
        {
            return moveDir;
        }

        set
        {
            moveDir = value;
        }
    }

    public bool Grounded
    {
        get
        {
            return grounded;
        }

        set
        {
            grounded = value;
        }
    }

    public string CharacterType1
    {
        get
        {
            return characterType;
        }

        set
        {
            characterType = value;
        }
    }
	public string TexName
	{
		get
		{
			return texName;
		}
		
		set
		{
			texName = value;
		}
	}
	public float HearingRange
	{
		get
		{
			return hearingRange;
		}
		
		set
		{
			hearingRange = value;
		}
	}
	public float ShootingRange
	{
		get
		{
			return shootingRange;
		}
		
		set
		{
			shootingRange = value;
		}
	}
}
