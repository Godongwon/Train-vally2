using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


public class SecondBarCtrol : MonoBehaviour
{
    public List<GameObject> ObjectList = new List<GameObject>();//오브젝트 리스트
    public List<GameObject> RailList = new List<GameObject>();//기차길 리스트
    public BarButton barButton;
    Vector2 scrollPos;
    public List<GameObject> SecondBarList=new List<GameObject>();
    public List<Texture2D> PrefabsRailTextures = new List<Texture2D>();
    public List<Texture2D> PrefabsObjTextures = new List<Texture2D>();
    Texture2D button;


    

    private void OnEnable()
    {
        barButton = GameObject.Find("Bar").GetComponent<BarButton>();
        PrefabsRailTextures = Resources.LoadAll<Texture2D>("RailImg").ToList();
        PrefabsObjTextures = Resources.LoadAll<Texture2D>("ObjectImg").ToList();


        Refresh();
        
    }
    private void OnDisable()
    {
        SecondBarList.Clear();
    }

    public void Refresh()
    {
       
        if (barButton.selectBtn == SelectBtn.Rain)
        {
            RailList = Resources.LoadAll<GameObject>("Rail").ToList();
            SecondBarList = RailList;
        }
        else if(barButton.selectBtn == SelectBtn.Object)
        {
            ObjectList = Resources.LoadAll<GameObject>("Object").ToList();
            SecondBarList = ObjectList;
        }
    }
    private void Update()
    {
     
    }

    private void OnGUI()
    {
        int columns = Mathf.FloorToInt(Screen.width / 900);
        GUI.color = new Color(100.3f, 0.3f, 0.3f);
        GUILayout.BeginArea(new Rect(100, 100, 430, 980));
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginHorizontal();
        
        for (int i = 0; i < SecondBarList.Count; i++)
        {
            if (SecondBarList[i] == null)
            {
                Refresh();
            }
       
            try
            {
                if (i % columns == 0)
                {
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }
                //if (AssetPreview.GetAssetPreview(SecondBarList[i]) == null)
                //{
                //    //button = AssetPreview.GetMiniThumbnail(SecondBarList[i]);
                //}
                //else
                {
                    if (barButton.selectBtn == SelectBtn.Rain)
                    {
                        button = PrefabsRailTextures[i];
                    }
                    else if (barButton.selectBtn == SelectBtn.Object)
                    {
                        button = PrefabsObjTextures[i];
                    }
                   
                }
    
                GUI.color = new Color(1, 1, 1, 1.0f);
                if (GUILayout.Button(button, GUILayout.Width(190), GUILayout.Height(190)))//버튼크기
                {
                    
                    MapTool.currentObj = SecondBarList[i];
                   
                }
                GUI.color = Color.white;
               
            }
            catch { }
        }
        GUILayout.EndHorizontal();
        GUI.color = Color.white;
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
}
