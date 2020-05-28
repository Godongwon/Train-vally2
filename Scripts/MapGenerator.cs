using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapGenerator : MonoBehaviour
{
    BarButton barButton;
    public InputField Xnum;
    public InputField Ynum;

    public Vector2 mapSize;

    public GameObject tilePrebs;
    GameObject newTile;
    int tileNum;


    [Range(0, 1)]
    public float outlinePercent;
    List<GameObject> TileList = new List<GameObject>();


    int x = 10;
    int y = 10;


    private void Start()
    {
        barButton = GameObject.Find("Bar").GetComponent<BarButton>();
        mapSize.x = 10;
        mapSize.y = 10;

        GenerateMap();
    }

    public void GenerateMap()
    {
        string holderName = "Generated Map";

        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                newTile = Instantiate(tilePrebs) as GameObject;
                newTile.name = "Tile" + tileNum.ToString();
                newTile.transform.position = tilePosition;
                //newTile.transform.rotation = Quaternion.Euler(Vector3.right * 90);
                newTile.transform.localScale = Vector3.one * (1 - outlinePercent);
                newTile.transform.parent = mapHolder;
                TileList.Add(newTile);
                tileNum++;
            }
        }
    }

    public void input()
    {
        mapSize.x =  int.Parse(Xnum.text);
        mapSize.y = int.Parse(Ynum.text);
    }
}
