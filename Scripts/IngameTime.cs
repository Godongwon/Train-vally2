using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class IngameTime : MonoBehaviour
{
    public Text textTime;
    BackGroundbutton pauseButton;
    float timeMinutes=0;
    float timeSecounds=0;

    void Start()
    {
        pauseButton = GameObject.Find("Pause").GetComponent<BackGroundbutton>();
    }

    void Update()
    {
        if(!pauseButton.Click())
        {
            timeSecounds += Time.deltaTime;
            if(timeSecounds > 59.5f)
            {
                timeMinutes += 1;
                timeSecounds = 0;
            }
        }

        textTime.text = timeMinutes.ToString("F0") + " : " + timeSecounds.ToString("F0");
    }
}
