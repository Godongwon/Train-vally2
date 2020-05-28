using UnityEngine;

using System;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

public class Texture2DPNG : MonoBehaviour
{
    //public List<GameObject> _ObjectList = new List<GameObject>();//오브젝트 리스트
    //public List<GameObject> _RailList = new List<GameObject>();//오브젝트 리스트
    //Texture2D RainTexture;
    //Texture2D ObjTexture;
    //private void Start()
    //{
        
    //    _ObjectList = Resources.LoadAll<GameObject>("Object").ToList();
    //    _RailList = Resources.LoadAll<GameObject>("Rail").ToList();

    //}

    //public void ObjectintoPng()
    //{
    //    for (int i = 0; i < _ObjectList.Count; i++)
    //    {
    //        ObjTexture = AssetPreview.GetAssetPreview(_ObjectList[i]);
    //        byte[] bytes = ObjTexture.EncodeToPNG();
    //        string path = _ObjectList[i].name + ".png";

    //       System.IO.File.WriteAllBytes(path, bytes);

    //    }
    //}
    //public void RainintoPng()
    //{
    //    for (int i = 0; i < _RailList.Count; i++)
    //    {
    //        RainTexture = AssetPreview.GetAssetPreview(_RailList[i]);
    //        byte[] bytes = RainTexture.EncodeToPNG();
          
    //        string path = _RailList[i].name + ".png";
    //        System.IO.File.WriteAllBytes(path, bytes);
            
    //    }
    //}
}
