using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RailInstallation : MonoBehaviour
{
    public List<GameObject> TileList = new List<GameObject>();
    public List<GameObject> RailList = new List<GameObject>();

    public GameObject tiles;
    public GameObject[] Rails;

    Transform RailTransfom;

    bool _isListAdd = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._isGameOver) return;

        listAdd();
        Installation();
    }

    void listAdd()
    {
        if (_isListAdd) return;
    
        tiles = GameObject.Find("MapTile");

        for (int i = 0; i < tiles.transform.childCount; i++)
        {
            TileList.Add(tiles.transform.GetChild(i).gameObject);
        }

        _isListAdd = true;
    }

    void Installation()
    {

    }
}
