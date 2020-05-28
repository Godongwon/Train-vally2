using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundbutton : MonoBehaviour
{
    Image buttonimg;
    public int index;
    public Sprite[] images;
    public bool isClick;

   public bool Click()
    {
        return isClick;
    }
    public void SetClick(bool click)
    {
        isClick = click;
    }



    void Start()
    {
        buttonimg = gameObject.GetComponent<Image>();
        buttonimg.sprite = images[0];
    }
    private void OnMouseOver()
    {
        Debug.Log("dfij");
        if (images.Length==3)
        {
            buttonimg.sprite = images[1];
        }

    }
    private void OnMouseExit()
    {
        buttonimg.sprite = images[0];
    }

    public void OnMouseDown()
    {
        isClick = !isClick;
    }

    

    private void Update()
    {
        if(isClick)
        {
            buttonimg.sprite = images[images.Length-1];
        }
        else
        {
            buttonimg.sprite = images[0];
        }
    }



}
