using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSetting : MonoBehaviour
{
    public string pathName = "";
    public Color pathColor = Color.cyan;
    public List<Vector3> nodes = new List<Vector3>();
    public int nodeCount;
    public static Dictionary<string, PathSetting> paths = new Dictionary<string, PathSetting>();
    public bool initalized = false;
    public string initaName = "";
    public bool pathVisible = true;
    public GameObject obj;
    public GameObject startObj;
    public GameObject endObj;
    // Start is called before the first frame update
    private void OnEnable()
    {
        obj = GameObject.Find("Rails");
        
        for(int i = 4; i < startObj.transform.childCount; i++)
        {
            nodes.Add(startObj.transform.GetChild(i).GetChild(1).position);
        }

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            nodes.Add(obj.transform.GetChild(i).GetChild(1).position);

            if (obj.transform.GetChild(i).childCount > 2)
            {
                nodes.Add(obj.transform.GetChild(i).GetChild(2).position);
                nodes.Add(obj.transform.GetChild(i).GetChild(3).position);
            }
        }

        for(int i = 3; i < endObj.transform.childCount; i++)
        {
            nodes.Add(endObj.transform.GetChild(i).GetChild(1).position);
        }

        if (!paths.ContainsKey(pathName))
        {
            paths.Add(pathName.ToLower(), this);
        }
    }

    private void OnDisable()
    {
        paths.Remove(pathName.ToLower());
    }

    private void OnDrawGizmosSelected()
    {
        if (pathVisible)
        {
            if(nodes.Count > 0)
            {
                iTween.DrawPath(nodes.ToArray(), pathColor);
            }
        }
    }

    public static Vector3[] GetPath(string requestName)
    {
        requestName = requestName.ToLower();

        if(paths.ContainsKey(requestName))
        {
            return paths[requestName].nodes.ToArray();
        }
        else
        {
            Debug.Log("해당 이름의 경로가 없습니다, ( " + requestName + " ) 정확하게 작성 해주세요");
            return null;
        }
    }

    public static Vector3[] GestQathRecersed(string requestName)
    {
        requestName = requestName.ToLower();

        if(paths.ContainsKey(requestName))
        {
            List<Vector3> revNodes = paths[requestName].nodes.GetRange(0, paths[requestName].nodes.Count);
            revNodes.Reverse();
            return revNodes.ToArray();
        }
        else
        {
            Debug.Log("해당 이름의 경로가 없습니다, ( " + requestName + " ) 정확하게 작성 해주세요");
            return null;
        }
    }
}
