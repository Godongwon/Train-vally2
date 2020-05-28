using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanalOnoff : MonoBehaviour
{
    BarButton barButton;



    void Start()
    {
        barButton = GameObject.Find("Bar").GetComponent<BarButton>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(barButton.selectBtn==SelectBtn.Save|| barButton.selectBtn == SelectBtn.Load)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
