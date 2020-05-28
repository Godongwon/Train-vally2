using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SelectBtn
{
    Save,
    Load,
    Object,
    Rain,
    Paint,
    Empty
}
public class BarButton : MonoBehaviour
{
    public  SelectBtn selectBtn;
    ButtonClick Save;
    ButtonClick Load;
    ButtonClick Object;
    ButtonClick Rain;
    ButtonClick Paint;
    public GameObject SecondBar;
    public Text SelectText;
    public GameObject ColorImg;
    public GameObject SceneList;



  
    void Start()
    {
        selectBtn = SelectBtn.Empty;
        Save = GameObject.Find("Save").GetComponent<ButtonClick>();
        Load = GameObject.Find("Load").GetComponent<ButtonClick>();
        Object = GameObject.Find("Object").GetComponent<ButtonClick>();
        Rain = GameObject.Find("Rain").GetComponent<ButtonClick>();
        Paint = GameObject.Find("Paint").GetComponent<ButtonClick>();
        
        SecondBar.SetActive(false);
        SelectText.text = "Unselct";

    }

    void Update()
    {
        if(Save.isclick&&Save.isMouse)
        {
            selectBtn = SelectBtn.Save;
        }//save
        if(Load.isclick && Load.isMouse)
        {
            selectBtn = SelectBtn.Load;
        }//load
        if (Object.isclick && Object.isMouse)
        {
            selectBtn = SelectBtn.Object;
        }
        if (Rain.isclick && Rain.isMouse)
        {
            selectBtn = SelectBtn.Rain;
        }
        if (Paint.isclick && Paint.isMouse)
        {
            selectBtn = SelectBtn.Paint;
        }
        if (!Save.isclick&&!Load.isclick&&!Object.isclick&&!Rain.isclick&& !Paint.isclick)
        {
            selectBtn = SelectBtn.Empty;
        }
        StartCoroutine(FalseClick());
        if(selectBtn == SelectBtn.Paint)
        {
            ColorImg.SetActive(true);
        }
        else
        {
            ColorImg.SetActive(false);
        }
        if(selectBtn == SelectBtn.Save|| selectBtn == SelectBtn.Load)
        {
            SceneList.SetActive(true);
        }
        else
        {
            SceneList.SetActive(false);
        }

        Select();
    }
    IEnumerator FalseClick()
    {
        switch (selectBtn)
        {
            case SelectBtn.Save:
                if(Load.isclick)
                {
                    Load.isclick = false;
                }
                if (Object.isclick)
                {
                    Object.isclick = false;
                }
                if (Rain.isclick)
                {
                    Rain.isclick = false;
                }
                if(Paint.isclick)
                {
                    Paint.isclick = false;
                }
                break;
            case SelectBtn.Load:
                if (Save.isclick)
                {
                    Save.isclick = false;
                }
                if (Object.isclick)
                {
                    Object.isclick = false;
                }
                if (Rain.isclick)
                {
                    Rain.isclick = false;
                }
                if (Paint.isclick)
                {
                    Paint.isclick = false;
                }
                break;
            case SelectBtn.Object:
                if (Load.isclick)
                {
                    Load.isclick = false;
                }
                if (Save.isclick)
                {
                    Save.isclick = false;
                }
                if (Rain.isclick)
                {
                    Rain.isclick = false;
                }
                if (Paint.isclick)
                {
                    Paint.isclick = false;
                }
                break;
            case SelectBtn.Rain:
                if (Save.isclick)
                {
                    Save.isclick = false;
                }
                if (Object.isclick)
                {
                    Object.isclick = false;
                }
                if (Load.isclick)
                {
                    Load.isclick = false;
                }
                if (Paint.isclick)
                {
                    Paint.isclick = false;
                }
                break;
            case SelectBtn.Paint:
                if (Save.isclick)
                {
                    Save.isclick = false;
                }
                if (Object.isclick)
                {
                    Object.isclick = false;
                }
                if (Load.isclick)
                {
                    Load.isclick = false;
                }
                if (Rain.isclick)
                {
                    Rain.isclick = false;
                }
                break;
         
        }
        yield return null;
    }

    void Select()
    {
        switch(selectBtn)
        {
            case SelectBtn.Save:
                SelectText.text = "Save";
                SecondBar.SetActive(true);
 
                break;
            case SelectBtn.Load:
                SelectText.text = "Load";
                SecondBar.SetActive(true);
 
                break;
            case SelectBtn.Object:
                SelectText.text = "Object";
                SecondBar.SetActive(true);
     
                break;
            case SelectBtn.Rain:
                SelectText.text = "Rain";
                SecondBar.SetActive(true);
       
                break;
            case SelectBtn.Paint:
                SelectText.text = "Paint";
                SecondBar.SetActive(true);
              
                break;
            case SelectBtn.Empty:
                SelectText.text = "Unselct";
                SecondBar.SetActive(false);
               
                break;
        }
    }
    

    
    
}
