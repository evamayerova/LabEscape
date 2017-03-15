using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LevelManager : MonoBehaviour {

    void createBlock(Vector2 position, string name = "block", string tag = "Ground")
    {
        GameObject newObject = new GameObject(name);
        SpriteRenderer sr = newObject.AddComponent<SpriteRenderer>();
        Texture2D tex = new Texture2D(100, 100);
        byte[] image = File.ReadAllBytes("Assets/Graphics/block.png");
        tex.LoadImage(image);
        Debug.Log(image);
        Debug.Log(tex.width + " " + tex.height);
        Sprite s = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.0f, 0.0f));
        sr.sprite = s;
        newObject.transform.position = position;
        newObject.AddComponent<BoxCollider2D>();
        newObject.tag = tag;
    }

    void createEnemy(Vector2 position, string type)
    {

    }

    ArrayList parseTerrainConfig(string configPath)
    {
        ArrayList al = new ArrayList();

        StreamReader reader = File.OpenText(configPath);
        if (!reader.ReadLine().Equals("size"))
            Debug.LogError("Missisng 'size' section in config");

        string[] sizeXY = reader.ReadLine().Split(';');
        float width = float.Parse(sizeXY[0]);
        float height = float.Parse(sizeXY[1]);
        for (int i = 0; i < height; i++)
        {
            createBlock(new Vector2(0.0f, i), "Start");
            createBlock(new Vector2(width, i), "Finish");
        }
        for (int i = 0; i < width; i ++)
        {
            createBlock(new Vector2(i, 0.0f));
        }

        if (!reader.ReadLine().Equals("blocks"))
            Debug.LogError("Missisng 'blocks' section in config");

        string line;
        Vector2 startPosVec, endPosVec;
        string[] startPos, endPos;
        int groundType;

        while ((line = reader.ReadLine()) != null)
        {
            string[] data = line.Split(';');
            if (data.Length != 3)
                Debug.LogError("Each 'blocks' entry must have three items.");
            startPos = data[0].Split(',');
            endPos = data[1].Split(',');
            groundType = int.Parse(data[2]);

            startPosVec = new Vector2(float.Parse(startPos[0]), float.Parse(startPos[1]));
            endPosVec = new Vector2(float.Parse(endPos[0]), float.Parse(endPos[1]));
            Debug.Log(startPosVec + " " + endPosVec);

            if (startPosVec.x > endPosVec.x || startPosVec.y > endPosVec.y)
                Debug.LogError("Bad order of start and end block positions");

            for (int i = 0; i <= endPosVec.y - startPosVec.y; i ++)
            {
                for (int j = 0; j <= endPosVec.x - startPosVec.x; j ++)
                {
                    Debug.Log(startPosVec.x + j + " " + startPosVec.y + i);
                    al.Add(new Vector2(startPosVec.x + j, startPosVec.y + i));
                }
            }
        }
        return al;
    }

    void createMap()
    {
        ArrayList blockPositions = parseTerrainConfig("Assets/Levels/level0.txt");
        foreach (Vector2 blockPos in blockPositions)
        {
            createBlock(blockPos);
        }
    }

    public void spawnPlayer()
    {
        GameObject.Find("Person").GetComponent<Transform>().position = new Vector3(1.0f, 3.0f, 0.0f);
    }

	// Use this for initialization
	void Start () {
        createMap();
        createEnemy(new Vector2(3.0f, -1.0f), "technician");
        createPlayer(new Vector2(1.0f, 3.0f), "cat");
        GameObject.Find("Main Camera").AddComponent<CharacterFollower>();
        spawnPlayer();
    }

    private void createPlayer(Vector2 position, string type)
    {
        Debug.Log(type);
        GameObject player = new GameObject("Person");
        Transform transform = player.GetComponent<Transform>();
        transform.position = position;
        player.AddComponent<Player>().CharacterType = type;
        Debug.Log("Player type " + player.GetComponent<Player>().CharacterType);
        addTexture(player, "Assets/Graphics/character.png", 30, 50);
        player.AddComponent<BoxCollider2D>();
        Rigidbody2D rb2d = player.AddComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        player.AddComponent<GunHolder>();
        player.tag = "Player";

        GameObject weapon = new GameObject("Weapon");
        addTexture(weapon, "Assets/Graphics/block.png", 100, 100);
        weapon.GetComponent<Transform>().parent = player.GetComponent<Transform>();
        GameObject firePoint = new GameObject("FirePoint");
        firePoint.GetComponent<Transform>().parent = weapon.GetComponent<Transform>();
        weapon.AddComponent<Shooter>();

    }

    private void addTexture(GameObject gameObject, string fileName, int w, int h)
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        Texture2D tex = new Texture2D(w, h);
        byte[] image = File.ReadAllBytes(fileName);
        tex.LoadImage(image);
        Sprite s = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.0f, 0.0f));
        sr.sprite = s;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
