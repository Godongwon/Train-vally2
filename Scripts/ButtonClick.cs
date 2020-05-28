using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    BarButton barButton;
    public bool isclick;
    public bool isMouse;
    void Start()
    {
        barButton = GetComponent<BarButton>();
        isclick = false;
    }
  
    public void overSystem()
    {
        isMouse = true;
    }
    public void exitSystem()
    {
        isMouse = false;
    }
    public void OnMouseDown()
    {
        isclick = !isclick;   
    }
}
