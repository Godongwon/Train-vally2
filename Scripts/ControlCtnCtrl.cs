using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCtnCtrl : MonoBehaviour
{

    BackGroundbutton railWay;
    BackGroundbutton railCreat;
    BackGroundbutton railDelete;

    public int index;
    
   
    void Start()
    {
        railWay     = GameObject.Find("RailWay").GetComponent<BackGroundbutton>(); 
        railCreat   = GameObject.Find("RailCreat").GetComponent<BackGroundbutton>();
        railDelete   = GameObject.Find("RailDelete").GetComponent<BackGroundbutton>();
    
        railWay.SetClick(true);
    }
    void Update()
    {

        if(railWay.isClick && railWay.index == 0)
        {
            index = 1;
            railWay.index = 1;

        }
        if (railCreat.isClick && railCreat.index == 0)
        {
           index = 2;
            railCreat.index = 1;
  
        }
        if (railDelete.isClick && railDelete.index == 0)
        {
            index = 3;
            railDelete.index = 1;
           
        }

        switch (index)
        {
            case 1:
                railCreat.SetClick(false);
                railDelete.SetClick(false);
                railCreat.index = 0;
                railDelete.index = 0;
                break;
            case 2:
                railWay.SetClick(false);
                railDelete.SetClick(false);
                railWay.index = 0;
                railDelete.index = 0;
                break;
            case 3:
                railCreat.SetClick(false);
                railWay.SetClick(false);
                railCreat.index = 0;
                railWay.index = 0;
                break;
        }

    }
}
