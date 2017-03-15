using UnityEngine;
using System.Collections;
using System.IO;

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

	// Use this for initialization
	void Start () {
        createMap();
        createEnemy(new Vector2(3.0f, -1.0f), "technician");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
