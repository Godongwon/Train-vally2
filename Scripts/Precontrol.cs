using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Precontrol : MonoBehaviour
{
    public List<GameObject> ObjectList = new List<GameObject>();//오브젝트 리스트
    public List<GameObject> RailList = new List<GameObject>();//기차길 리스트
    
    void Awake()
    {
        ObjectList = Resources.LoadAll<GameObject>("Object").ToList();
        RailList = Resources.LoadAll<GameObject>("Rail").ToList();
    }

}
