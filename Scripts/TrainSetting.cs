using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrainSetting : MonoBehaviour
{
    public GameObject Rail_StratightPrefab;
    public GameObject Rail_CurvePrefab;
    GameObject Rail;
    GameObject target;
    GameObject prvTarget;
    GameObject thrTarget;    
    List<GameObject> RailList = new List<GameObject>();
    Vector2 mapSize;
    Transform railStrHolder;
    Transform railCurveHolder;
    string subFirstHolderName;
    string subSecondHolderName;
    GameObject[] Tile;
    int tilePositonNum;
     
    void Start()
    {
        subFirstHolderName = "curve";
        subSecondHolderName = "straiht";
        railStrHolder = new GameObject(subSecondHolderName).transform;
        railStrHolder.parent = transform;
        railCurveHolder = new GameObject(subFirstHolderName).transform;
        railCurveHolder.parent = transform;
        Tile = GetComponent<MapTool>().tiles;
        mapSize = GetComponent<MapGenerator>().mapSize;
    }
   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (target != prvTarget && target != null)
            {
                if (prvTarget != null && prvTarget != thrTarget)
                {
                    thrTarget = prvTarget;
                }
            }

            if (target != prvTarget && target != null)
            {
                prvTarget = target;
                for (int i = 0; i < Tile.Length; i++)
                {
                    if (Tile[i] == prvTarget)
                    {
                        tilePositonNum = i;
                    }
                }
            }
            
            GetClickedObject();

            for (int i = 0; i < Tile.Length; i++)
            {
                if ((target == Tile[i]) && Tile[tilePositonNum].GetComponent<Ground>().index != 1)
                {
                    if (((i > 0 && i != Tile.Length - 1)) && ((prvTarget == Tile[i - 1]) || (prvTarget == Tile[i + 1])))
                    {
                        if ((thrTarget == (Tile[i - (int)mapSize.y - 1])))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveLB ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 90);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x - 0.3f, prvTarget.transform.position.y, prvTarget.transform.position.z - 0.5f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;                           
                        }
                        else if ((thrTarget == (Tile[i + (int)mapSize.y - 1])))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveRB ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 180);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x + 0.5f, prvTarget.transform.position.y, prvTarget.transform.position.z + 0.29f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                        }
                        else if (thrTarget == (Tile[i - (int)mapSize.y + 1]))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveLT ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 0);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x + +0.5f, prvTarget.transform.position.y, prvTarget.transform.position.z - 0.29f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                        }
                        else if (thrTarget == (Tile[i + (int)mapSize.y + 1]))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveRT ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 270);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x + 0.29f, prvTarget.transform.position.y, prvTarget.transform.position.z + 0.5f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                        }
                        else
                        {
                            Rail = Instantiate(Rail_StratightPrefab) as GameObject;
                            Rail.name = "Rail Straight";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 90);
                            Rail.transform.position = prvTarget.transform.position;
                            Rail.transform.parent = railStrHolder;
                            Rail.transform.localScale = new Vector3(1.35f, 1.0f, 1.0f);
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;                        
                            break;
                        }
                    }

                    if ((i > (int)mapSize.y && i < Tile.Length - (int)mapSize.y) && ((prvTarget == Tile[i - (int)mapSize.y]) || (prvTarget == Tile[i + (int)mapSize.y])))
                    {
                        if ((thrTarget == (Tile[i - (int)mapSize.y - 1])))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveRT ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 270);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x + 0.29f, prvTarget.transform.position.y, prvTarget.transform.position.z + 0.5f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                            
                        }
                        else if ((thrTarget == (Tile[i + (int)mapSize.y - 1])))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveLT ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 0);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x + 0.5f, prvTarget.transform.position.y, prvTarget.transform.position.z - 0.29f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                            
                        }
                        else if (thrTarget == (Tile[i - (int)mapSize.y + 1]))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveRB ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 180);
                            Rail.transform.position = new Vector3(prvTarget.transform.position.x + 0.5f, prvTarget.transform.position.y, prvTarget.transform.position.z + 0.29f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                        }
                        else if (thrTarget == (Tile[i + (int)mapSize.y + 1]))
                        {
                            Rail = Instantiate(Rail_CurvePrefab) as GameObject;
                            Rail.name = "Rail CurveLB ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 90);
                            Rail.transform.position = Rail.transform.position = new Vector3(prvTarget.transform.position.x - 0.3f, prvTarget.transform.position.y, prvTarget.transform.position.z - 0.5f);
                            Rail.transform.parent = railCurveHolder;
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum - 1].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y].GetComponent<Ground>().index += 2;
                            Tile[tilePositonNum + (int)mapSize.y - 1].GetComponent<Ground>().index += 2;
                            break;
                        }
                        else
                        {
                            Rail = Instantiate(Rail_StratightPrefab) as GameObject;
                            Rail.name = "Rail Straight ";
                            Rail.GetComponent<BoxCollider>().enabled = false;
                            Rail.transform.rotation = Quaternion.Euler(Vector3.up * 0);
                            Rail.transform.position = prvTarget.transform.position;
                            Rail.transform.parent = railStrHolder;
                            Rail.transform.localScale = new Vector3(1.35f, 1.0f, 1.0f);
                            RailList.Add(Rail);
                            Tile[tilePositonNum].GetComponent<Ground>().index += 2;
                            
                            break;
                        }
                    }
                }
            }
            
        }
        else
        {
            thrTarget = null;
            prvTarget = null;
        }

        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < Tile.Length; i++)
            {
                if (Tile[i].GetComponent<Ground>().index == 2)
                {
                    Removed();
                }
            }
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    private void Removed()
    {
        for (int i = 0; i < RailList.Count; i++)
        {
            RailList[i].GetComponent<BoxCollider>().enabled = true;
        }
        GetClickedObject();
        Debug.Log(target.name);
        for (int i = 0; i < RailList.Count; i++) {
            if (target.transform.position == RailList[i].transform.position)
            {
                Destroy(RailList[i]);
                RailList.RemoveAt(i);
            }
            RailList[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}
