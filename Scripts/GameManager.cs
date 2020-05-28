using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using LitJson;

public class ObjectList
{
    public int index;
    public int x, y, z;
    public int rotX, rotY, rotZ;
    public string tag;
    public string r, g, b;
   

    public ObjectList(string tagname, int pX, int pY, int pZ, int oRotX, int oRotY, int oRotZ)
    {
        tag = tagname;
        //index = objIndex;   // 리스트에서 오브젝트 순서 찾기용 인덱스
        x = pX;             // 포지션 x
        y = pY;             // 포지션 y
        z = pZ;             // 포지션 z
        rotX = oRotX;
        rotY = oRotY;
        rotZ = oRotZ;
        
    }
    public ObjectList(string tagname, int pX, int pY, int pZ, string red, string green, string blue)
    {
        tag = tagname;
        //index = objIndex;   // 리스트에서 오브젝트 순서 찾기용 인덱스
        x = pX;             // 포지션 x
        y = pY;             // 포지션 y
        z = pZ;             // 포지션 z
        r = red;
        g = green;
        b = blue;
    }

}

public class GameManager : MonoBehaviour
{
    
    public bool _isGameOver = false;   //게임이 종료되었는지

    //오브젝트 리스트
    public List<GameObject> objList = new List<GameObject>();
    public List<GameObject> RailList = new List<GameObject>();
    public List<ObjectList> objectLists = new List<ObjectList>();

    public GameObject tile;
    public GameObject TilePrant;
    public GameObject objectPrant;
    public GameObject map;


    public Dictionary<int, GameObject> objListD = new Dictionary<int, GameObject>();

    // 맵오브젝트를 불러오기 위한 변수
    public string tagN;
    public float objX, objY, objZ;
    public float rotX, rotY, rotZ;
    public float r, g, b;

    // 전역변수
    public static GameManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        objList = Resources.LoadAll<GameObject>("Object").ToList();
        RailList = Resources.LoadAll<GameObject>("Rail").ToList();

        for (int i = 0; i < objList.Count; i++)
        {
            objListD.Add(i, objList[i]);
        }

        map = GameObject.Find("Map");

    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    private void Update()
    {
        if(!_isGameOver)
        {

        }
        else
        {

        }
    }


    public void MapLoad(string name)
    {
        string jsonString = File.ReadAllText(Application.streamingAssetsPath + "/MapData/" + name+".json");
        Debug.Log(jsonString);
      
        JsonData jsonData = JsonMapper.ToObject(jsonString);

        TilePrant = GameObject.Find("Generated Map");
        objectPrant = GameObject.Find("Plain");

        for (int i = 0; i < jsonData.Count; i++)
        {
            tagN = jsonData[i]["tag"].ToString();
            objX = float.Parse(jsonData[i]["x"].ToString());
            objY = float.Parse(jsonData[i]["y"].ToString());
            objZ = float.Parse(jsonData[i]["z"].ToString());
            rotX = float.Parse(jsonData[i]["rotX"].ToString());
            rotY = float.Parse(jsonData[i]["rotY"].ToString());
            rotZ = float.Parse(jsonData[i]["rotZ"].ToString());

            if (tagN == "floor")
            {
                GameObject Tile = Instantiate(tile, new Vector3(objX, objY, objZ), new Quaternion(0, 0, 0, 0), TilePrant.transform);
                r = float.Parse(jsonData[i]["r"].ToString());
                g = float.Parse(jsonData[i]["g"].ToString());
                b = float.Parse(jsonData[i]["b"].ToString());
                Tile.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
            }
            else
            {
                for (int j = 0; j < objList.Count; j++)
                {

                    if (objList[j].tag == tagN)
                    {
                        Instantiate(objList[j], new Vector3(objX, objY, objZ), new Quaternion(rotX, rotY, rotZ, 0),objectPrant.transform);
                        break;
                    }
                }
            }
        }
    }
}
